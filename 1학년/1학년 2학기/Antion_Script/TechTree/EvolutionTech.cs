using Karin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tkfkadlsi
{
    public class EvolutionTech : MonoBehaviour
    {
        [SerializeField] private GameObject ChangePrefab;
        [SerializeField] private UnitSelectButton unitSelectButton;

        public void Activated()
        {
            if(ChangePrefab == null) 
            {
                Debug.Log("πŸ≤‹ «¡∏Æ∆’¿ª æ»≥÷æ˙¿›æ∆!!!!");
                return;
            }
            if(unitSelectButton == null)
            {
                Debug.Log("πŸ≤‹ ∞˜¿ª æ»¡§«ÿ¡·¿›æ∆!!!!");
                return;
            }


            unitSelectButton.ChangeUnit(ChangePrefab);
        }
    }
}
