using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tkfkadlsi
{
    public class TechMaster : MonoBehaviour
    {
        [SerializeField] private GameObject ConditionNotMetPanel;
        [SerializeField] private GameObject LackResourcePanel;

        public static TechMaster Instance;
        public Action ChangeTech;

        public Dictionary<string, bool> TechConditions = new Dictionary<string, bool>();

        public bool IsRunning = false;

        public IEnumerator ConditionNotMet;
        public IEnumerator LackResource;

        private IEnumerator DisplayConditionPanel()
        {
            IsRunning = true;
            ConditionNotMetPanel.SetActive(true);
            yield return new WaitForSeconds(1);
            ConditionNotMetPanel.SetActive(false);
            ConditionNotMet = DisplayConditionPanel();
            IsRunning = false;
        }

        private IEnumerator DisplayResourcePanel()
        {
            IsRunning = true;
            LackResourcePanel.SetActive(true);
            yield return new WaitForSeconds(1);
            LackResourcePanel.SetActive(false);
            LackResource = DisplayResourcePanel();
            IsRunning = false;
        }

        public void OnChangeTech()
        {
            StartCoroutine(ChangeDelat());
        }

        private IEnumerator ChangeDelat()
        {
            yield return null;
            ChangeTech?.Invoke();
        }

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            ConditionNotMetPanel.SetActive(false);
            LackResourcePanel.SetActive(false);
            ConditionNotMet = DisplayConditionPanel();
            LackResource = DisplayResourcePanel();
        }
    }
}
