 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    public Monster [] Monsters = new Monster[2];
    private static List<Monster> Spawner;
    private Monster MonsterInit;
    public Transform Plane;
    public LifeManager LifeManager;

    private float sizeX;
    private float sizeZ;
    private float randX;
    private float randZ;

    public int randmin = 0;
    public int randmax = 1;
    private float spawnDelay;
    
    public bool canSpawn;
    // Start is called before the first frame update
    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            Spawn();
        }
    }
    void Start()
    {
        canSpawn = true;
        spawnDelay = 4;
        Spawner = new List<Monster>();
        LifeManager.onLevelUp += PlayerLavelUp;
        sizeX = Plane.localScale.x * 10;
        sizeZ = Plane.localScale.z * 10;
        StartCoroutine(SpawnRoutine());
    }

    private void Spawn()
    {
        Spawner.RemoveAll(obj => obj == null);
        if (Spawner.Count >= 10)
        {
            Debug.LogWarning("최대 10마리의 몬스터만 소환 가능합니다!");
            return;
        }
        randX = UnityEngine.Random.Range(-sizeX / 2f + 10, sizeX / 2f - 10);
        randZ = UnityEngine.Random.Range(-sizeZ / 2f + 10, sizeZ / 2f - 10);
        switch (UnityEngine.Random.Range(randmin, randmax+1))
        {
            case 0:
                Spawning(0);
                break;
            case 1:
                Spawning(1);
                break;
        }
    }
    private void Spawning(int index)
    {
        MonsterInit = Instantiate(Monsters[index], new Vector3(randX, 5, randZ), Quaternion.identity);
        MonsterInit.Init();
        Spawner.Add(MonsterInit);
    }
    // Update is called once per frame
    public void PlayerLavelUp(int Level)
    {
        if (spawnDelay > 1.6f)
        {
            spawnDelay -= 0.2f; 
        }
    }
}
