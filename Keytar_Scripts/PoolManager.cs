using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.EventSystems;

[System.Serializable]
public class PoolingObject
{
    public string objectName;
    public int objectAmount;
    public GameObject objectPrefab;
}

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    public List<PoolingObject> poolingObjects = new List<PoolingObject>();
    public Dictionary<string, Queue<GameObject>> pools = new Dictionary<string, Queue<GameObject>>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (PoolingObject @object in poolingObjects)
        {
            pools.Add(@object.objectName, new Queue<GameObject>());

            CreateObjectInPool(@object.objectName, @object.objectAmount, @object.objectPrefab, transform);
        }
    }

    private void CreateObjectInPool(string objectName, int count, GameObject objectPrefab, Transform location)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newObj = Instantiate(objectPrefab, location);
            newObj.SetActive(false);
            pools[objectName].Enqueue(newObj);

        }
    }

    private GameObject CreateObject(string objectName, Transform location = null)
    {
        foreach(PoolingObject @object in poolingObjects)
        {
            if(@object.objectName == objectName)
            {
                GameObject newObj = Instantiate(@object.objectPrefab, location);
                return newObj;
            }
        }

        return null;
    }

    public GameObject GetObject(string objectName)
    {
        if (!pools.ContainsKey(objectName)) return null;

        if (pools[objectName].Count > 0)
        {
            GameObject outObj = pools[objectName].Dequeue();
            outObj.SetActive(true);
            return outObj;
        }
        else
        {
            GameObject outObj = CreateObject(objectName);
            outObj.SetActive(true);
            return outObj;
        }
    }
    public GameObject GetObject(string objectName, Vector3 position)
    {
        if (!pools.ContainsKey(objectName)) return null;

        if(pools[objectName].Count > 0)
        {
            GameObject outObj = pools[objectName].Dequeue();
            outObj.transform.position = position;
            outObj.SetActive(true);
            return outObj;
        }
        else
        {
            GameObject outObj = CreateObject(objectName);
            outObj.transform.position = position;
            outObj.SetActive(true);
            return outObj;
        }
        
    }
    public GameObject GetObject(string objectName, Vector3 position, Transform parent)
    {
        if (!pools.ContainsKey(objectName)) return null;

        if(pools[objectName].Count > 0)
        {
            GameObject outObj = pools[objectName].Dequeue();
            outObj.transform.SetParent(parent);
            outObj.transform.position = position;
            outObj.SetActive(true);
            return outObj;
        }
        else
        {
            GameObject outObj = CreateObject(objectName, parent);
            outObj.transform.SetParent(parent);
            outObj.transform.position = position;
            outObj.SetActive(true);
            return outObj;
        }
    }
    public GameObject GetObjectUI(string objectName, Vector3 position, Transform parent)
    {
        if (!pools.ContainsKey(objectName)) return null;

        if(pools[objectName].Count > 0)
        {
            GameObject outObj = pools[objectName].Dequeue();
            outObj.transform.SetParent(parent);
            RectTransform rect = outObj.GetComponent<RectTransform>();
            rect.anchoredPosition3D = position;
            outObj.SetActive(true);
            return outObj;
        }
        else
        {
            GameObject outObj = CreateObject(objectName, parent);
            outObj.transform.SetParent(parent);
            RectTransform rect = outObj.GetComponent<RectTransform>();
            rect.anchoredPosition3D = position;
            outObj.SetActive(true);
            return outObj;
        }
    }

    public void ReturnObject(string objectName, GameObject inObj)
    {
        inObj.SetActive(false);
        inObj.transform.SetParent(transform);
        inObj.transform.position = Vector3.zero;

        pools[objectName].Enqueue(inObj);
    }
}
