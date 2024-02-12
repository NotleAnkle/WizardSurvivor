using _Framework.Pool.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : GameUnit
{
    [SerializeField] private GameUnit target;
    [SerializeField] private AnimationCurve curve = new AnimationCurve();
    [SerializeField] private float speed = 1f;
    private float timer = 0f;
    private void Update()
    {
        Move();
    }

    private void Start()
    {

    }

    private void Move()
    {
        float curveValue = curve.Evaluate(timer);
        TF.position = Vector3.MoveTowards(TF.position, target.TF.position, speed * Time.deltaTime * curveValue);
        timer += Time.deltaTime;
    }
}

