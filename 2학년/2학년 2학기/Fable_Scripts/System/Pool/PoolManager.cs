using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private List<PoolObject> poolObjects = new List<PoolObject>();

    public Dictionary<string, Stack<GameObject>> PoolDictionary = new Dictionary<string, Stack<GameObject>>();

    private void Awake()
    {
        foreach(PoolObject poolObject in poolObjects)
        {
            PoolDictionary.Add(poolObject.ObjectName, new Stack<GameObject>());

            for(int i = 0; i < poolObject.PoolCount; i++)
            {
                PoolDictionary[poolObject.ObjectName].Push(CreateObject(poolObject.ObjectName, poolObject.Object));
            }
        }
    }

    private GameObject CreateObject(string objName, GameObject createObject)
    {
        GameObject newObj = Instantiate(createObject);
        newObj.name = objName;
        newObj.transform.SetParent(transform);
        newObj.SetActive(false);
        return newObj;
    }

    public GameObject GetObject(string objectName)
    {
        if (!PoolDictionary.ContainsKey(objectName))
        {
            Debug.LogWarning("아니 그 풀 없는디?");
            return null;
        }

        GameObject outObj = PoolDictionary[objectName].Pop();
        outObj.SetActive(true);
        outObj.transform.SetParent(null);
        return outObj;
    }

    public void SetObject(string objectName, GameObject inObj)
    {
        if (!PoolDictionary.ContainsKey(objectName))
        {
            Debug.LogWarning("아니 그 풀 없는디?");
            return;
        }

        inObj.SetActive(false);
        inObj.transform.SetParent(transform);
        PoolDictionary[objectName].Push(inObj);
    }
}
