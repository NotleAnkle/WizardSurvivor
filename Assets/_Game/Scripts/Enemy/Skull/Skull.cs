using _Framework;
using _Framework.Pool.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : GameUnit
{
    [SerializeField] private Player target;
    [SerializeField] private float speed = 0.8f;

    private int count = 0;
    [SerializeField]private float floatStep = 0.001f;

    // Update is called once per frame
    void Update()
    {
        Floating();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.TAG_PLAYER))
        {
            Player player = Cache<Player>.GetComponent(collision);
            player.OnHit();
            this.Despawn();
        }
    }

    private void Despawn()
    {
        Destroy(gameObject);
    }

    private void Floating()
    {
        TF.position = Vector3.MoveTowards(TF.position, target.TF.position, speed * Time.deltaTime);
        if (count < 100)
        {
            TF.position -= Vector3.up * floatStep;
        }
        else
        {
            TF.position += Vector3.up * floatStep;
        }
        count++;
        if (count > 200) { count = 0; };
    }
}
