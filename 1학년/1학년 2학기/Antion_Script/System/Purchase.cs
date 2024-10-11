using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Tkfkadlsi
{
    public class Purchase : MonoBehaviour
    {
        public Action PurchaseBuilding;

        public void OnPurchaseBuilding()
        {
            PurchaseBuilding?.Invoke();
        }
    }
}
