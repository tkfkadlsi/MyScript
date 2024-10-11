using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject OnThisTileObject;


    public void OnPointerClick(PointerEventData eventData)
    {
        if(TMananger.instance.CurrnetState == GameState.Set)
        {
            if(OnThisTileObject != null)
            {
                return;
            }

            OnThisTileObject = TMananger.instance.StartPieces[0];
            OnThisTileObject.transform.position = transform.position;

            //김현준이 추가한 코드
            EnemyManager.Instance.TileList.Remove(transform);

            OnThisTileObject.SetActive(true);
            PlayerPieces piece = OnThisTileObject.GetComponent<PlayerPieces>();
            TMananger.instance.StartPieces.RemoveAt(0); 
        }
    }
}
