using _Framework.Event.Scripts;
using _Framework.Pool.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GameUnit
{
    [SerializeField] private SpriteRenderer render;
    private float hp;

    public void OnInit(float hp)
    {
        render.color = Color.white;
        this.hp = hp;
    }

    public void OnHit(float damage)
    {
        hp -= damage;
        StartCoroutine(OnHitEffect());
        if(hp < 0.001f)
        {
            OnDespawn();
        }
    }

    private IEnumerator OnHitEffect()
    {
        render.color = Color.black;
        yield return new WaitForSeconds(0.1f);
        render.color = Color.white;
    }

    public virtual void OnDespawn()
    {
        this.PostEvent(EventID.OnEnemyDie, this);
        SimplePool.Despawn(this);
    }
}
