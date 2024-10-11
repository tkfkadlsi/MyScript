using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tkfkadlsi
{
    public class SelectTileForDestory : SelectTile
    {
        [SerializeField] private Tilemap buildTilemap;
        [SerializeField] private Tilemap buildTilemap2;

        [SerializeField] private Sprite DefaultCursor;
        [SerializeField] private Sprite CanDestroyCursor;

        [SerializeField] private LayerMask selectLayer;

        [SerializeField] private GameObject destroyPanel;

        private bool canDestroy;

        private void Awake()
        {
            destroyPanel.SetActive(false);
        }

        private void OnEnable()
        {
            if (CursorPosition.Instance == null)
            {
                return;
            }

            CursorPosition.Instance.SetCursorSprite(CanDestroyCursor);
        }

        private void Start()
        {
            CursorPosition.Instance.SetCursorSprite(DefaultCursor);
        }

        private void Update()
        {
            SetMousePosition();

            canDestroy = CheckHereBuilding(CheckType());

            if(Input.GetMouseButtonDown(0))
            {
                DestroyBuilding();
            }
        }

        private void SetMousePosition()
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition = new Vector3(Mathf.Round(mousePosition.x), Mathf.Round(mousePosition.y));
            mousePositionInt = new Vector3Int((int)mousePosition.x, (int)mousePosition.y);
            transform.position = new Vector3(mousePositionInt.x + 0.5f, mousePosition.y + 0.5f);
        }

        private bool CheckHereBuilding(GroundType type)
        {
            if(type == GroundType.BuildingCenter || type == GroundType.BuildingCenter3X3)
                return true;
            else
                return false;
        }

        private GroundType CheckType()
        {
            return tiles[$"{mousePositionInt.x},{mousePositionInt.y}"];
        }

        private void DestroyBuilding()
        {
            if (!canDestroy) return;

            AudioManager.Instance.PlaySound("UIClick", AudioType.SFX);
            buildTilemap.SetTile(mousePositionInt, null);
            buildTilemap2.SetTile(mousePositionInt, null);

            switch (CheckType())
            {
                case GroundType.BuildingCenter:
                    ChangeTileToGround1X1(mousePositionInt);
                    break;
                case GroundType.BuildingCenter3X3:
                    ChangeTileToGround3X3(mousePositionInt);
                    break;
            }

            Collider2D buildingCollider = Physics2D.OverlapCircle(mousePosition, 0.25f, selectLayer);
            if(buildingCollider != null)
            {
                GameObject selectBuilding = buildingCollider.gameObject;

                Debug.Log(selectBuilding);

                Destroy(selectBuilding);
            }
        }

        private void ChangeTileToGround1X1(Vector3Int vector)
        {
            tiles[$"{vector.x},{vector.y}"] = GroundType.Ground;
        }

        private void ChangeTileToGround3X3(Vector3Int vector)
        {
            for(int x = -1; x <= 1; x++)
            {
                for(int y = -1; y <= 1; y++)
                {
                    tiles[$"{vector.x + x},{vector.y + y}"] = GroundType.Ground;
                }
            }
        }

        private void OnDisable()
        {
            try
            {

                destroyPanel.SetActive(false);
                CursorPosition.Instance.SetCursorSprite(DefaultCursor);
            }
            catch { }
        }
    }
}
