using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageLanguage : MonoBehaviour
{
    [SerializeField] private Sprite sprite_Kor;
    [SerializeField] private Sprite sprite_Eng;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if(Information.Instance.Language == "ÇÑ±¹¾î")
        {
            spriteRenderer.sprite = sprite_Kor;
        }
        else if(Information.Instance.Language == "English")
        {
            spriteRenderer.sprite = sprite_Eng;
        }
    }
}
