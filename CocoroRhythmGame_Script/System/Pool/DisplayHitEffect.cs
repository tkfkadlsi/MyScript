using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHitEffect : MonoBehaviour
{
    [SerializeField] private List<GameObject> poolObjects;
    [SerializeField] private List<int> poolCounts;

    private Dictionary<JudgementType, Stack<GameObject>> hitEffectDictionary = new Dictionary<JudgementType, Stack<GameObject>>();



    private void Awake()
    {
        int i = 0;
        foreach (JudgementType type in Enum.GetValues(typeof(JudgementType)))
        {
            Stack<GameObject> newPoolStack = new Stack<GameObject>();
            for (int j = 0; j < poolCounts[i]; j++)
            {
                GameObject newObj = Instantiate(poolObjects[i]);
                newObj.transform.SetParent(transform);
                newObj.SetActive(false);
                newPoolStack.Push(newObj);
            }
            hitEffectDictionary.Add(type, newPoolStack);
            i++;
        }
    }

    public void DisplayEffect(Vector3 position, JudgementType judgementType)
    {
        GameObject displayEffect = hitEffectDictionary[judgementType].Pop();
        displayEffect.transform.position = position;
        displayEffect.SetActive(true);

        StartCoroutine(ReturnEffect(displayEffect, judgementType));
    }

    private IEnumerator ReturnEffect(GameObject inObj, JudgementType judgementType)
    {
        yield return new WaitForSeconds(1.5f);
        inObj.SetActive(false);
        hitEffectDictionary[judgementType].Push(inObj);
    }
}
