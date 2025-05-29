using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemyTarget : MonoBehaviour
{
    public float speed = 0.75f;
    public Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("ReachPoint1").transform;
    }

    void Update()
    {
        if (target == null) return;

        Vector3 dir = (target.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;

    }
}
