using _Framework.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] private Player player;
    [SerializeField] private float offset = 10f;
    [SerializeField] private List<Enemy> enemies;

    private float cooldown = 2f;

    private void Update()
    {
        if(cooldown < 0.0001f)
        {
            SpawnSkull();
            cooldown = 2f;
        }
        cooldown -= Time.deltaTime;
    }

    private void SpawnSkull()
    {
        Skull skull = SimplePool.Spawn<Skull>(PoolType.Skull, GetRandomPosition(), Quaternion.identity);
        skull.OnInit(player);
    }

    private Vector2 GetRandomPosition()
    {
        float randomAngle = Random.Range(0f, 360f);

        float radianAngle = randomAngle * Mathf.Deg2Rad;

        float x = player.TF.position.x + offset * Mathf.Cos(radianAngle);
        float y = player.TF.position.y + offset * Mathf.Sin(radianAngle);

        return new Vector2(x, y);
    }
}
