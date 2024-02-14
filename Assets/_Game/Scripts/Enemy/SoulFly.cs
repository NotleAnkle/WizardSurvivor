using _Framework;
using _Framework.Pool.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulFly : GameUnit
{
    private GameUnit target;
    [SerializeField] private float speed = 5f;
    public void OnInit(Player target)
    {
        this.target = target;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        TF.position = Vector3.MoveTowards(TF.position, target.TF.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.TAG_PLAYER))
        {
            Player player = Cache<Player>.GetComponent(collision);
            player.OnCollectExp();
            OnDeSpawn();
        }
    }

    private void OnDeSpawn()
    {
        SimplePool.Despawn(this);
    }
}
