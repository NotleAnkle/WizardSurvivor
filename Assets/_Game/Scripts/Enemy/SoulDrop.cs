using _Framework;
using _Framework.Pool.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulDrop : GameUnit
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.TAG_PLAYER))
        {
            Player player = Cache<Player>.GetComponent(collision);
            SimplePool.Spawn<SoulFly>(PoolType.Soul_Fly, TF.position, Quaternion.identity).OnInit(player);
            OnDeSpawn();
        }
    }

    private void OnDeSpawn()
    {
        SimplePool.Despawn(this);
    }
}
