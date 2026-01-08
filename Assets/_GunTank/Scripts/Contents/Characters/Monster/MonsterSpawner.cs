using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class MonsterFactory
{
    protected Dictionary<PoolType, ObjectPool> poolDic;
    protected Monster monster;
    public abstract Monster PoolingMonster(Vector3 pos);
}
public class DragonFactory : MonsterFactory
{
    public DragonFactory(Dictionary<PoolType, ObjectPool> dic)
    {
        poolDic = dic;
    }
    public override Monster PoolingMonster(Vector3 pos)
    {
        GameObject obj = poolDic[PoolType.Monster_Dragon].UsePool(pos, Quaternion.identity);
        if (!obj.TryGetComponent<Monster>(out monster))
        {
            Debug.LogWarning("오브젝트 풀 내 드래곤 다씀");
            return null;
        }
        monster.Init();
        monster.ApplySpawnContext(LifeManager.Level);
        monster.StartPattern();
        return monster;
    }
}
public class SlimeFactory : MonsterFactory
{
    public SlimeFactory(Dictionary<PoolType, ObjectPool> dic)
    {
        poolDic = dic;
    }
    public override Monster PoolingMonster(Vector3 pos)
    {
        GameObject obj = poolDic[PoolType.Monster_Slime].UsePool(pos, Quaternion.identity);
        if (!obj.TryGetComponent<Monster>(out monster))
        {
            Debug.LogWarning("오브젝트 풀 내 슬라임 다씀");
            return null;
        }
        monster.Init();
        monster.ApplySpawnContext(LifeManager.Level);
        monster.StartPattern();
        return monster;
    }
}
//스포너와 팩토리 중계자
public class FactoryProvider
{
    Dictionary<PoolType, MonsterFactory> factory;
    public FactoryProvider(Dictionary<PoolType, ObjectPool> dic)
    {
        factory = new Dictionary<PoolType, MonsterFactory>();
        factory.Add(PoolType.Monster_Dragon, new DragonFactory(dic));
        factory.Add(PoolType.Monster_Slime, new SlimeFactory(dic));
    }
    /// <summary>
    /// 풀 내부의 타입을 받아서 해당하는 타입의 몬스터 풀링 후 생성된 몬스터 반환
    /// </summary>
    /// <param name="type">생성하려는 몬스터</param>
    /// <returns>타입에 해당하는 몬스터</returns>
    public Monster SpawnMonster(PoolType type, Vector3 pos)
    {
        if (!factory.ContainsKey(type))
        {
            Debug.LogWarning("잘못된 몬스터 타입 입력");
            return null;
        }
        return factory[type].PoolingMonster(pos);
    }
}
public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Monster> Spawner;
    public LifeManager LifeManager;
    FactoryProvider provider;
    Monster monster;
    public bool canSpawn;

    public Transform Plane;
    private float sizeX;
    private float sizeZ;
    private float randX;
    private float randZ;
    private Vector3 spawnPosition;

    public int randmin = 0;
    public int randmax = 1;
    private float spawnDelay;
    public int rank = 0; //몬스터 등급 -> 높아질수록 새로운 스킬 해금

    //PoolManager에서 poolDic생성 완료시에만 실행(참조 1개인지 확인)
    public void Init(Dictionary<PoolType, ObjectPool> dic)
    {
        provider = new FactoryProvider(dic);
        canSpawn = true;
        spawnDelay = 4;
        Spawner = new List<Monster>();
        sizeX = Plane.localScale.x * 10;
        sizeZ = Plane.localScale.z * 10;
        StartCoroutine(SpawnRoutine());
        Debug.Log("스포너 초기화");
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            Spawn();
        }
    }

    void Spawn()
    {
        //스폰 절차 : Spawn함수에서 무작위 값 뽑아서 해당 값에 맞는 몬스터팩토리를 provider에서 받아온 후 pooling 
        Spawner.RemoveAll(obj => obj == null || !obj.isActiveAndEnabled);
        if(Spawner.Count >= 10)
        {
            Debug.Log("필드 내 최대 소환가능 객체 초과(10마리)");
            return;
        }
        randX = UnityEngine.Random.Range(-sizeX / 2f + 10, sizeX / 2f - 10);
        randZ = UnityEngine.Random.Range(-sizeZ / 2f + 10, sizeZ / 2f - 10);
        spawnPosition = new Vector3(randX, 3, randZ);
        switch (UnityEngine.Random.Range(randmin, randmax + 1))
        {
            case 0:
                monster = provider.SpawnMonster(PoolType.Monster_Dragon, spawnPosition);
                break;
            case 1:
                monster = provider.SpawnMonster(PoolType.Monster_Slime, spawnPosition);
                break;
            default:
                Debug.LogWarning("생성 범위 지정 오류");
                break;
        }
        if(monster!=null) Spawner.Add(monster);
    }
    public void PlayerLavelUp(int Level)
    {
        if (spawnDelay > 1.6f)
        {
            spawnDelay -= 0.2f;
        }
    }
    private void OnEnable()
    {
        LifeManager.OnLevelUp += PlayerLavelUp;
    }
    private void OnDisable()
    {
        LifeManager.OnLevelUp -= PlayerLavelUp;
    }

    //private void Spawn()
    //{
    //    Spawner.RemoveAll(obj => obj == null);
    //    if (Spawner.Count >= 10)
    //    {
    //        Debug.LogWarning("최대 10마리의 몬스터만 소환 가능합니다!");
    //        return;
    //    }
    //    randX = UnityEngine.Random.Range(-sizeX / 2f + 10, sizeX / 2f - 10);
    //    randZ = UnityEngine.Random.Range(-sizeZ / 2f + 10, sizeZ / 2f - 10);
    //    spawnPosition = new Vector3(randX, 3, randZ);
    //    switch (UnityEngine.Random.Range(randmin, randmax + 1))
    //    {
    //        case 0:
    //            Spawning(0);
    //            break;
    //        case 1:
    //            Spawning(1);
    //            break;
    //    }
    //}
    //private void Spawning(int index)
    //{
    //    MonsterInit = Instantiate(Monsters[index], new Vector3(randX, 5, randZ), Quaternion.identity);
    //    MonsterInit.Init();
    //    Spawner.Add(MonsterInit);
    //}

}
