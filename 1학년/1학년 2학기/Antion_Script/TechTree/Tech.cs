using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Karin;
using UnityEngine.UI;
using TMPro;

namespace Tkfkadlsi
{
    public class Tech : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private enum TechType
        {
            Evolution = 0,
            Enforce = 1
        }

        [SerializeField] TechType techtype;

        [SerializeField] private List<string> necessary_Tech = new List<string>();
        [SerializeField] private string mustNot_Tech;
        [SerializeField] private string this_Tech;
        [SerializeField] private string visible_String;

        [SerializeField] private int necessary_Bone;
        [SerializeField] private int necessary_Branch;
        [SerializeField] private int necessary_Rock;

        private Image image;

        private EvolutionTech evolutionTech;
        private EnforceTech enforceTech;

        private TextMeshProUGUI branchCostText;
        private TextMeshProUGUI rockCostText;
        private TextMeshProUGUI boneCostText;
        private GameObject costPanel;
        private TextMeshProUGUI nameText;

        private bool IsNecessaryTechOn;
        private bool IsMuchNotTechOn;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (TechMaster.Instance.TechConditions[this_Tech]) return;

            AudioManager.Instance.PlaySound("UIClick", AudioType.SFX);

            if (IsMuchNotTechOn == true)
            {
                StartCoroutine(TechMaster.Instance.ConditionNotMet);
                return;
            }

            if (IsNecessaryTechOn == false)
            {
                StartCoroutine(TechMaster.Instance.ConditionNotMet);
                return;
            }

            if (CheckMoreMoney() == false)
            {
                StartCoroutine(TechMaster.Instance.LackResource);
                return;
            }

            TechMaster.Instance.TechConditions[this_Tech] = true;
            image.color = new Color(1, 1, 1, 1);
            TechMaster.Instance.OnChangeTech();

            switch (techtype)
            {
                case TechType.Evolution:
                    evolutionTech.Activated();
                    break;
                case TechType.Enforce:
                    enforceTech.Activated();
                    break;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (TechMaster.Instance.TechConditions[this_Tech])
                return;

            costPanel.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            costPanel.SetActive(false);
        }

        private void Awake()
        {
            image = GetComponent<Image>();
            evolutionTech = GetComponent<EvolutionTech>();
            enforceTech = GetComponent<EnforceTech>();

            nameText = transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
            branchCostText = transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            rockCostText = transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            boneCostText = transform.GetChild(1).transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            costPanel = transform.GetChild(1).gameObject;

            nameText.text = visible_String;

            branchCostText.text = necessary_Branch.ToString();
            rockCostText.text = necessary_Rock.ToString();
            boneCostText.text = necessary_Bone.ToString();

            costPanel.SetActive(false);
        }

        private void Start()
        {
            TechMaster.Instance.ChangeTech += CheckPossible;

            if (necessary_Tech.Contains("None"))
            {
                TechMaster.Instance.TechConditions.Add(this_Tech, true);
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                TechMaster.Instance.TechConditions.Add(this_Tech, false);
                image.color = new Color(0.2f, 0.2f, 0.2f, 1);
            }

            TechMaster.Instance.OnChangeTech();
        }

        private void CheckPossible()
        {
            if (TechMaster.Instance.TechConditions[this_Tech]) return;
            else
            {
                try
                {

                    if (mustNot_Tech != "None")
                    {
                        if (TechMaster.Instance.TechConditions[mustNot_Tech])
                        {
                            IsMuchNotTechOn = true;
                            image.color = new Color(0.2f, 0.2f, 0.2f, 1);
                            return;
                        }
                    }

                    foreach (string necessary in necessary_Tech)
                    {
                        if (TechMaster.Instance.TechConditions[necessary])
                        {
                            IsNecessaryTechOn = true;
                            image.color = new Color(0.5f, 0.5f, 0.5f, 1);
                            return;
                        }
                    }
                }
                catch { }
            }

        }

        private bool CheckMoreMoney()
        {
            if (ResourceManager.Instance.BranchCount < necessary_Branch) return false;
            if (ResourceManager.Instance.RockCount < necessary_Rock) return false;
            if (ResourceManager.Instance.BoneCount < necessary_Bone) return false;

            return true;
        }

        private void OnDestroy()
        {
            try
            {

                TechMaster.Instance.ChangeTech -= CheckPossible;
            }
            catch { }
        }
    }
}
