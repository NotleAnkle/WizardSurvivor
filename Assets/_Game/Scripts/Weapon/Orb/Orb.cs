using _Framework;
using _Framework.Event.Scripts;
using _Framework.Pool.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : GameUnit
{
    [SerializeField] private List<Enemy> targets;
    [SerializeField] private float range = 5f;
    private int targetCount => targets.Count;

    private float cooldown = Constant.ORB_COOLDOWN;

    private void Awake()
    {
        this.RegisterListener(EventID.OnEnemyDie, (param) => RemoveTarget((Enemy)param));
    }

    private void Start()
    {
        OnInit();
    }

    private void OnInit()
    {
        range = Constant.ORB_RANGE_DEFAULT;
        TF.localScale = range * Vector3.one;
    }

    private void Update()
    {
        if(targetCount > 0 && cooldown < 0.0001f)
        {
            Attack(targets[0]);
            cooldown = Constant.ORB_COOLDOWN;
        }
        cooldown -= Time.deltaTime;
    }

    private void Attack(Enemy target)
    {
        SimplePool.Spawn<Bullet>(PoolType.Bullet_Direct, transform.position, Quaternion.identity).OnInit(target);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(Constant.TAG_ENEMY))
        {
            Enemy enemy = Cache<Enemy>.GetComponent(collision);
            if (!targets.Contains(enemy))
            {
                targets.Add(enemy);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.TAG_ENEMY))
        {
            Enemy enemy = Cache<Enemy>.GetComponent(collision);
            if (targets.Contains(enemy))
            {
                targets.Remove(enemy);
            }
        }
    }

    private void RemoveTarget(Enemy target)
    {
        targets.Remove(target);
    }
}
