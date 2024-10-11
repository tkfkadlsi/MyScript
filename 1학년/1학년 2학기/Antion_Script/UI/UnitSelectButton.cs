using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Karin;
using UnityEngine.UI;

namespace Tkfkadlsi
{
    public class UnitSelectButton : MonoBehaviour
    {
        private int costCount;
        public GameObject unit;

        private BuildModes buildModes;
        private Purchase purchase;
        private Selecter selecter;
        private Image image;
        private TextMeshProUGUI costText;
        private GameObject Ximage;

        private void Awake()
        {
            image = transform.GetChild(0).GetComponent<Image>();
            costText = transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
            Ximage = transform.GetChild(2).gameObject;

        }

        private void OnEnable()
        {
            CheckX();
        }

        private void Start()
        {
            buildModes = FindObjectOfType<BuildModes>();
            selecter = FindObjectOfType<Selecter>();
            purchase = FindObjectOfType<Purchase>();

            if (unit == null)
            {
                costCount = 0;
                costText.text = costCount.ToString();
                return;
            }

            ControlableCharacter character = unit.GetComponent<ControlableCharacter>();
            image.sprite = character._characterData.Image;

            costCount = character._characterData.WoodCost;
            costText.text = costCount.ToString();

            purchase.PurchaseBuilding += CheckX;
        }

        private void CheckX()
        {
            if(ResourceManager.Instance == null) return;

            if (costCount > ResourceManager.Instance.BranchCount)
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

            if (costCount > ResourceManager.Instance.BranchCount)
            {
                return;
            }

            selecter.pSpawner.SummonPrefabs = unit;
            purchase.OnPurchaseBuilding();
            buildModes.CancleExceptionMode();
        }

        public void ChangeUnit(GameObject newUnit)
        {
            unit = newUnit;
            costCount = newUnit.GetComponent<ControlableCharacter>()._characterData.WoodCost;
            ControlableCharacter character = newUnit.GetComponent<ControlableCharacter>();
            costText.text = costCount.ToString();
            image.sprite = character._characterData.Image;

            purchase.OnPurchaseBuilding();

        }
    }
}
