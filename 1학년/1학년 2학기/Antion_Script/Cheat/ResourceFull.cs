using Karin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tkfkadlsi
{
    public class ResourceFull : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            if (ResourceManager.Instance == null) return;

            ResourceManager.Instance.BranchCount = 999;
            ResourceManager.Instance.RockCount = 999;
            ResourceManager.Instance.BoneCount = 999;
        }
    }
}
