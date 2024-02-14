using _Framework;
using _Framework.Pool.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : GameUnit
{
    [SerializeField] private GameUnit target;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float damage = 1f;
    [SerializeField] private SpriteRenderer img;
    [SerializeField] private TrailRenderer trail;

    private bool isHit = false;

    public void OnInit(GameUnit target)
    {
        trail.Clear();
        img.enabled = true;
        isHit = false;
        this.target = target;
    }

    private void Update()
    {
        if(!isHit) Move();
    }

    private void Move()
    {
        TF.position = Vector3.MoveTowards(TF.position, target.TF.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.TAG_ENEMY)) 
        {
            OnDespawn();
            Enemy enemy = Cache<Enemy>.GetComponent(collision);
            isHit = true;
            enemy.OnHit(damage);
        }
    }

    private void OnDespawn()
    {
        img.enabled = false;
        StartCoroutine(DelayDespawn());
    }

    private IEnumerator DelayDespawn()
    {
        yield return new WaitForSeconds(0.1f);
        SimplePool.Despawn(this);
    }
}

