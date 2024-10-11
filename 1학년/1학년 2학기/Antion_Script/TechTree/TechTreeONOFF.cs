using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tkfkadlsi
{
    public class TechTreeONOFF : MonoBehaviour
    {
        [SerializeField] private GameObject techTreePanel;

        [SerializeField] private GameObject unitTechTree;
        [SerializeField] private GameObject buildingTechTree;

        private void Awake()
        {
            unitTechTree.SetActive(true);
            buildingTechTree.SetActive(false);
        }

        public void TechTreeON()
        {
            techTreePanel.SetActive(true);
        }

        public void TechTreeOFF()
        {
            techTreePanel.SetActive(false);
        }

        public void UnitTechTree()
        {
            unitTechTree.SetActive(true);
            buildingTechTree.SetActive(false);
        }

        public void BuildingTechTree()
        {
            buildingTechTree.SetActive(true);
            unitTechTree.SetActive(false);
        }
    }
}
