using DG.Tweening.CustomPlugins;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tkfkadlsi
{
    public class BuildButtons : MonoBehaviour
    {
        
        [SerializeField] private List<BuildingBuild> buildings = new List<BuildingBuild>();
        private BuildModes buildModes;
        private SelectTileForBuild selectTileForBuild;
        private Purchase purchase;

        private void Awake()
        {
            buildModes = GetComponent<BuildModes>();
            selectTileForBuild = FindObjectOfType<SelectTileForBuild>();
            purchase = FindObjectOfType<Purchase>();
        }

        private void Start()
        {
            selectTileForBuild.gameObject.SetActive(false);
        }

        public void SelectBuilding(string buildName, int cost)
        {
            foreach (BuildingBuild build in buildings)
            {
                if(build.BuildingName == buildName)
                {
                    SelectComplete(build, cost);
                    purchase.OnPurchaseBuilding();
                    return;
                }
            }

            Debug.Log($"Not Found {buildName}");
        }

        public void SelectComplete(BuildingBuild buildingBuild, int cost)
        {
            selectTileForBuild.gameObject.SetActive(true);

            selectTileForBuild.ChangeBuilding(
                buildingBuild.buildingTile, buildingBuild.buildingSprite, buildingBuild.buildingSize, buildingBuild.buildingPrefab, cost);

            buildModes.OnBuildMode();
        }
    }
}