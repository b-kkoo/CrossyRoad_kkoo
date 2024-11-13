using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public List<ItemObject> pools;
    public Dictionary<int, Queue<GameObject>> poolDict;

    private void Awake()
    {
        Manager.instance.PoolManager = this;

        poolDict = new Dictionary<int, Queue<GameObject>>();
        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < 3; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDict.Add(pool.id, objectPool);
        }
    }

    public GameObject SpawnFromPool(int id)
    {
        if (!poolDict.ContainsKey(id)) return null;

        if (poolDict[id].Count > 0)
        {
            GameObject obj = poolDict[id].Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            Debug.Log("Create Item");
            var newObj = Instantiate(pools.Find(x => x.id == id).prefab);
            newObj.SetActive(false);
            poolDict[id].Enqueue(newObj);
            return newObj;
        }
    }

    public void ReturnObject(GameObject obj, int id)
    {
        if (!poolDict.ContainsKey(id)) return;

        obj.SetActive(false);
        poolDict[id].Enqueue(obj);
    }
}
