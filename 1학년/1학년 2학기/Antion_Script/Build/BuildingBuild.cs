using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace Tkfkadlsi
{
    [CreateAssetMenu(fileName = "", menuName = "SO/Building")]
    public class BuildingBuild : ScriptableObject
    {
        public float maxHealth;
        public string BuildingName;
        public TileBase buildingTile;
        public Sprite buildingSprite;
        public int buildingSize;
        public GameObject buildingPrefab;
    }
}
