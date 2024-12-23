using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarRating : MonoBehaviour
{
    [SerializeField] private Sprite noStar;
    [SerializeField] private Sprite defaultStar;
    [SerializeField] private Sprite FCStar;
    [SerializeField] private Sprite APStar;

    [SerializeField] private Image[] starsImage;

    private void Awake()
    {
        foreach(Image star in starsImage)
        {
            star.sprite = noStar;
        }
    }

    public void OneStar()
    {
        starsImage[0].sprite = defaultStar;
    }

    public void TwoStar()
    {
        starsImage[1].sprite = defaultStar;
    }

    public void ThreeStar()
    {
        starsImage[2].sprite = defaultStar;
    }

    public void FC()
    {
        foreach(Image star in starsImage)
        {
            if(star.sprite == defaultStar)
            {
                star.sprite = FCStar;
            }
        }
    }

    public void AP()
    {
        foreach (Image star in starsImage)
        {
            if (star.sprite == defaultStar)
            {
                star.sprite = APStar;
            }
        }
    }
}
