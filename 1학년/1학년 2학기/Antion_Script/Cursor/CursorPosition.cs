using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tkfkadlsi
{
    public class CursorPosition : MonoBehaviour
    {
        public static CursorPosition Instance;

        public Vector2 plusPosition;
        Vector2 mousePosition;
        SpriteRenderer spriteRenderer;

        public void SetPlusPosition(Vector2 position)
        {
            plusPosition = position;
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            mousePosition
                = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition = mousePosition - (Vector2)Camera.main.transform.position;

            transform.position = mousePosition + plusPosition;
            Cursor.visible = false;
        }

        public void SetCursorSprite(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }
    }
}