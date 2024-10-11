using Karin;
using System.Collections;
using System.Collections.Generic;
using Tkfkadlsi;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Tkfkadlsi
{
    public class BuildingButton : MonoBehaviour
    {
        [SerializeField] private int costCount;
        [SerializeField] private string buildingName;

        private Purchase purchase;
        private BuildButtons buildButtons;
        private TextMeshProUGUI costText;
        private GameObject Ximage;

        private void Awake()
        {
            costText = transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
            Ximage = transform.GetChild(2).gameObject;

            costText.text = costCount.ToString();
        }

        private void OnEnable()
        {
            CheckX();
        }

        private void Start()
        {
            purchase = FindObjectOfType<Purchase>();
            buildButtons = FindObjectOfType<BuildButtons>();

            purchase.PurchaseBuilding += CheckX;
        }

        private void CheckX()
        {
            if (ResourceManager.Instance == null) return;

            if (costCount > ResourceManager.Instance.RockCount)
            {
                Ximage.SetActive(true);
            }
            else
            {
                Ximage.SetActive(false);
            }
        }

        public void ButtonClick()
        {
            AudioManager.Instance.PlaySound("UIClick", AudioType.SFX);

            if(costCount > ResourceManager.Instance.RockCount)
            {
                return;
            }

            purchase.OnPurchaseBuilding();
            buildButtons.SelectBuilding(buildingName, costCount);
        }
    }
}
