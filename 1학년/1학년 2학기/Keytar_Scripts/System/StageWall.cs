using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StageWall : MonoBehaviour
{
    [SerializeField] private Vector3 exitPosition;
    private Vector3 playerPos;

    private GameObject player;
    private TilemapRenderer tilemapRenderer;
    private TilemapCollider2D tilemapCollider2D;

    private bool isWallOn;

    public bool IsWallOn
    {
        get
        {
            return isWallOn;
        }
        set
        {
            if(value == true)
            {
                tilemapCollider2D.enabled = true;
                tilemapRenderer.enabled = true;
            }
            else
            {
                tilemapCollider2D.enabled = false;
                tilemapRenderer.enabled = false;
            }
        }
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        tilemapRenderer = this.GetComponent<TilemapRenderer>();
        tilemapCollider2D = this.GetComponent<TilemapCollider2D>();
    }

    private void Update()
    {
        if (isWallOn) return;
        playerPos = new Vector3(Mathf.Round(player.transform.position.x), Mathf.Round(player.transform.position.y));

        if(playerPos == exitPosition)
        {
            IsWallOn = true;
        }
    }
}
