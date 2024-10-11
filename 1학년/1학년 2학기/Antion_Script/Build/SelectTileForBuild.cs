using Karin;
using Karin.AStar;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tkfkadlsi
{
    public class SelectTileForBuild : SelectTile
    {
        [SerializeField] private Tilemap groundTilemap;
        [SerializeField] private Tilemap buildTilemap;
        [SerializeField] private Tilemap buildTilemap2;

        [SerializeField] private Color CanBuildColor;
        [SerializeField] private Color DontBuildColor;

        private SpriteRenderer spriteRenderer;
        private BuildModes buildModes;

        private TileBase buildTile;
        private int buildingSize = 1;
        private GameObject buildingObject;
        private int cost;

        private bool canBuild = false;

        public void ChangeBuilding(TileBase tileBase, Sprite buildingSprite, int buildingSize, GameObject buildingPrefab, int cost)
        {
            buildTile = tileBase;
            spriteRenderer.sprite = buildingSprite;
            this.buildingSize = buildingSize;
            buildingObject = buildingPrefab;
            this.cost = cost;
        }

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            buildModes = FindObjectOfType<BuildModes>();
            try
            {
                tiles.Clear();


                for (int x = minMapPos.x; x <= maxMapPos.x; x++)
                {
                    for (int y = minMapPos.y; y <= maxMapPos.y; y++)
                    {
                        if (-1 <= x && x <= 1)
                        {
                            if (-1 <= y && y <= 1)
                            {
                                tiles.Add($"{x},{y}", GroundType.Terrain); continue;
                            }
                        }

                        tiles.Add($"{x},{y}", MakeTileType(new Vector3Int(x, y)));
                    }
                }
            }
            catch { }
        }

        private void Update()
        {
            SetMousePosition();

            switch (buildingSize)
            {
                case 1:
                    canBuild = Check1X1Building();
                    break;
                case 3:
                    canBuild = Check3X3Building();
                    break;
            }

            SetColor();
            if (Input.GetMouseButtonDown(0))
            {
                Build();
            }
        }

        private void SetMousePosition()
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition = new Vector3(Mathf.Round(mousePosition.x), Mathf.Round(mousePosition.y));
            mousePositionInt = new Vector3Int((int)mousePosition.x, (int)mousePosition.y);
            transform.position = new Vector3(mousePositionInt.x + 0.5f, mousePosition.y + 0.5f);
        }

        private GroundType MakeTileType(Vector3Int vector3)
        {
            TileBase ground = null;
            TileBase building = null;
            TileBase building2 = null;

            ground = groundTilemap.GetTile(vector3);
            building = buildTilemap.GetTile(vector3);
            building2 = buildTilemap2.GetTile(vector3);

            if (ground == null)
                return GroundType.Empty;

            if (building != null || building2)
            {
                return GroundType.Terrain;
            }

            return GroundType.Ground;
        }

        private GroundType CheckTileType(Vector3Int vector3)
        {
            var var = MapManager.Instance.GetTilePos(mousePosition);
            if (MapManager.Instance.collisionMap.GetTile(var) != null)
                return GroundType.Terrain;

            return tiles[$"{vector3.x},{vector3.y}"];
        }

        private bool Check1X1Building()
        {
            if (GroundType.Ground == CheckTileType(mousePositionInt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Check3X3Building()
        {
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (GroundType.Ground != CheckTileType(new Vector3Int(mousePositionInt.x + x, mousePositionInt.y + y)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void SetColor()
        {
            if (canBuild)
            {
                spriteRenderer.color = CanBuildColor;
            }
            else
            {
                spriteRenderer.color = DontBuildColor;
            }
        }

        private void Build()
        {
            if (!canBuild) return;

            AudioManager.Instance.PlaySound("UIClick", AudioType.SFX);
            buildTilemap.SetTile(mousePositionInt, buildTile);

            ResourceManager.Instance.RockCount -= cost;

            switch (buildingSize)
            {
                case 1:
                    ChangeTileToBuilding1X1(mousePositionInt);
                    break;
                case 3:
                    ChangeTileToBuilding3X3(mousePositionInt);
                    break;
            }


            Instantiate(buildingObject, MapManager.Instance.GetWorldPos(mousePositionInt), Quaternion.identity);

            buildModes.BuildComplete();
        }

        private void ChangeTileToBuilding1X1(Vector3Int vector)
        {
            tiles[$"{vector.x},{vector.y}"] = GroundType.BuildingCenter;
        }

        private void ChangeTileToBuilding3X3(Vector3Int vector)
        {
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                        tiles[$"{vector.x + x},{vector.y + y}"] = GroundType.BuildingCenter3X3;
                    else
                        tiles[$"{vector.x + x},{vector.y + y}"] = GroundType.Building;
                }
            }
        }
    }
}