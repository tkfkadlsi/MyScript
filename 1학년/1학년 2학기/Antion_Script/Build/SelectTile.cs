using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tkfkadlsi
{
    public class SelectTile : MonoBehaviour
    {
        private Vector3 mousePosition_private;
        protected Vector3Int mousePositionInt;

        protected Vector3 mousePosition
        {
            get
            {
                return mousePosition_private;
            }
            set
            {
                value = new Vector3(
                    Mathf.Clamp(value.x, minMapPos.x, maxMapPos.x),
                    Mathf.Clamp(value.y, minMapPos.y, maxMapPos.y));

                mousePosition_private = value;
            }
        }

        [SerializeField] protected Vector2Int minMapPos;
        [SerializeField] protected Vector2Int maxMapPos;

        protected enum GroundType
        {
            Empty = 0,
            Ground = 1,
            Terrain = 2,
            BuildingCenter = 3,
            BuildingCenter3X3 =4,
            Building = 5
        }

        protected static Dictionary<string, GroundType> tiles = new Dictionary<string, GroundType>();
    }
}
