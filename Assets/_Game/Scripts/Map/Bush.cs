using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    [SerializeField] private SpriteRenderer render;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(Constant.TAG_PLAYER_CLONE))
        {
            render.sortingOrder = 20;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.TAG_PLAYER_CLONE))
        {
            render.sortingOrder = 9;
        }
    }
}
