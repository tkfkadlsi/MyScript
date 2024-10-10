using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Select : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;
    [SerializeField] private GameObject nowSelectEffect;
    [SerializeField] private GameObject text;

    [SerializeField] private TextMeshProUGUI selectText;

    public GameObject selectedCharacter;

    public bool isAction = false;

    int key;

    private void Start()
    {
        key = 0;
        selectedCharacter = characters[key];
        nowSelectEffect.transform.position = selectedCharacter.transform.position;

        selectText.text = selectedCharacter.name;
    }

    KeyCode changeKey = KeyCode.Space;
    KeyCode selectKey = KeyCode.Return;

    private void Update()
    {
        if(isAction == false)
        {
            if (Input.GetKeyDown(changeKey))
            {
                ChangeCharacter();
            }
            if (Input.GetKeyDown(selectKey))
            {
                SelectCharacter();
            }

            if(text.activeSelf == false)
                text.SetActive(true);
        }
        else
        {
            if (text.activeSelf == true)
                text.SetActive(false);
        }
    }

    void ChangeCharacter()
    {
        if(key >= characters.Length - 1)
        {
            key = 0;
        }
        else
        {
            key++;
        }

        selectedCharacter = characters[key];
        nowSelectEffect.transform.position = selectedCharacter.transform.position;

        selectText.text = selectedCharacter.name;
    }

    void SelectCharacter()
    {
        isAction = true;
        Selected selected = selectedCharacter.GetComponent<Selected>();
        selected.SelectThis();
    }
}
