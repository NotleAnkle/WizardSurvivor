using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private new Camera camera;

    private Vector3 offset;

    private void Awake()
    {
        offset = transform.position - target.transform.position;
    }

    public void OnInit()
    {
    }


    void Update()
    {
        transform.position = target.transform.position + offset;
    }

}
