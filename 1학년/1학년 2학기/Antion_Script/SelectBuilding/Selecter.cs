using Karin;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tkfkadlsi
{
    public class Selecter : MonoBehaviour
    {
        [SerializeField] private LayerMask selectMask;
        private BuildModes buildModes;
        [SerializeField] private InputReaderSO inputReader;

        public PSpawner pSpawner;

        Camera cam;

        private void Start()
        {
            cam = Camera.main;
            buildModes = FindObjectOfType<BuildModes>();
        }

        private void OnEnable()
        {
            inputReader.SelectEvent += ClickMouse;
        }
        private void OnDisable()
        {
            inputReader.SelectEvent -= ClickMouse;
        }

        private void ClickMouse(Vector2 vec)
        {
            Vector2 mousePosition
                = cam.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitcol = Physics2D.OverlapCircle(mousePosition, 0.05f, selectMask);

            if (hitcol != null)
            {
                CheckBuildingType(hitcol.gameObject);
            }
        }

        private void CheckBuildingType(GameObject selectBuilding)
        {
            string buildingType = selectBuilding.name;

            if (buildingType.Contains("PSpawner"))
            {
                pSpawner = selectBuilding.GetComponent<PSpawner>();

                AudioManager.Instance.PlaySound("UIClick", AudioType.SFX);

                if (buildModes.buildMode == BuildModes.BuildMode.None)
                    buildModes.OnUnitSelectMode();
            }
        }

        public void ClickLapButton()
        {

            if (buildModes.buildMode == BuildModes.BuildMode.None)
            {
                AudioManager.Instance.PlaySound("UIClick", AudioType.SFX);
                buildModes.OnTechTreeMode();
            }
        }
    }
}
