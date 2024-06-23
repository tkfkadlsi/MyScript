using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public static BlockManager Instance;
    private Queue<GameObject> blockPool = new Queue<GameObject>();

    [SerializeField] private GameObject block;

    private void Awake()
    {
        Instance = this;

        for(int i = 0; i < 30; i++)
        {
            blockPool.Enqueue(CreateBlock());
        }
    }

    private GameObject CreateBlock()
    {
        GameObject newObj = Instantiate(block);
        newObj.transform.SetParent(transform);
        newObj.SetActive(false);

        return newObj;
    }

    public GameObject GetBlock(Transform trm = null)
    {
        if(blockPool.Count > 0)
        {
            GameObject outObj = blockPool.Dequeue();
            outObj.transform.SetParent(trm);
            outObj.SetActive(true);

            return outObj;
        }
        else
        {
            GameObject outObj = CreateBlock();
            outObj.transform.SetParent(trm);
            outObj.SetActive(true);

            return outObj;
        }
    }

    public void SetBlock(GameObject inObj)
    {
        inObj.SetActive(false);
        inObj.transform.SetParent(transform);
        blockPool.Enqueue(inObj);
    }

    private void Start()
    {
        StartCoroutine(SpawnBlock());
    }

    private IEnumerator SpawnBlock()
    {
        float delay = 0.05f;
        GameObject currentBlock = GetBlock();


        Vector3 scale =
            new Vector3(
                Random.Range(2.0f, 5.0f),
                Random.Range(1.0f, 5.0f),
                Random.Range(2.0f, 5.0f));

        Vector3 position =
            new Vector3(
                Random.Range(-15 + scale.x, 15 - scale.x),
                Random.Range(0 + scale.y, 2000 - scale.y),
                Random.Range(-15 + scale.z, 15 - scale.z));

        Vector3 rotation = new Vector3(
            Random.Range(-30.0f, 30.0f),
            Random.Range(-180.0f, 180.0f),
            Random.Range(-30.0f, 30.0f));

        currentBlock.transform.position = position;
        currentBlock.transform.rotation = Quaternion.Euler(rotation);
        currentBlock.transform.localScale = scale;

        yield return new WaitForSeconds(delay);
        StartCoroutine(SpawnBlock());
    }
}
