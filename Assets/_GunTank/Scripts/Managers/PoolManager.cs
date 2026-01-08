using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PoolData
{
    public GameObject obj;
    public int count;
    public PoolType type;
}
public class ObjectPool
{
    public PoolData data;
    public Queue<GameObject> pool;

    public ObjectPool(PoolData _data,GameObject obj)
    {
        pool = new Queue<GameObject>();
        data = _data;
        Init(obj);
    }
    public void Init(GameObject obj)
    {
        for(int i = 0; i < data.count; i++)
        {
            GameObject newObj = GameObject.Instantiate(data.obj);
            pool.Enqueue(newObj);
            newObj.SetActive(false);
            newObj.transform.SetParent(obj.transform);
        }
    }
    public GameObject UsePool(Vector3 pos, Quaternion rot)
    {
        if (pool.Count <= 0)
        {
            Debug.Log("풀 최대 갯수 제한");
            return null;
        }
        GameObject newObj = pool.Dequeue();
        newObj.transform.position = pos;
        newObj.transform.rotation = rot;
        newObj.SetActive(true);
        return newObj;
    }
    public void ReturnPool(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
public class PoolManager : MonoBehaviour
{
    public MonsterSpawner spawner;
    public List<PoolData> data;
    public static Dictionary<PoolType, ObjectPool> poolDic;
    private void Awake()
    {
        poolDic = new Dictionary<PoolType, ObjectPool>();
        for(int i = 0; i < data.Count; i++)
        {
            AddDictionary(data[i]);
        }
        Debug.Log("풀 생성 완료");
        spawner.Init(poolDic);
    }
    public void AddDictionary(PoolData data)
    {
        poolDic.Add(data.type, new ObjectPool(data,gameObject));
    }
}
