using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovePoint : MonoBehaviour, IPointerClickHandler
{
    PlayerPieces rootPiece;

    private void Start()
    {
        rootPiece = transform.root.GetComponent<PlayerPieces>();
        float scale = TMananger.instance.tileScale;
        transform.localPosition = new Vector3(transform.localPosition.x * scale, transform.localPosition.y * scale);
    }

    public void SelectedParentPiece()
    {
        bool isXout = false;
        bool isYout = false;

        isXout = Clamp(
            TMananger.instance.minPos.x - 0.1f,
            TMananger.instance.maxPos.x + 0.1f,
            transform.position.x);
        isYout = Clamp(
            TMananger.instance.minPos.y - 0.1f,
            TMananger.instance.maxPos.y + 0.1f,
            transform.position.y);

        if(isXout || isYout)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (TMananger.instance.CurrnetState != GameState.PlayerTurn) return;
        if (rootPiece.playerEnergy.GetEnergy() - rootPiece.SubEnergy < 0) return;

        rootPiece.transform.position = transform.position;
        rootPiece.MovePiece();
        if (rootPiece.playerEnergy.GetEnergy() - rootPiece.SubEnergy < 0)
        {
            rootPiece.MovePointONOFF(true);
        }
    }

    private bool Clamp(float min, float max, float value)
    {
        if(value < min || max < value)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
