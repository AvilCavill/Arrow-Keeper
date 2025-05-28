using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class EnemyIA : MonoBehaviour
{
    public float speed = 2f;
    public float damage = 1;
    public int health = 3;
    public Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Tower").transform;
    }

    void Update()
    {
        if (target == null) return;

        Vector3 dir = (target.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;

    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tower"))
        {
            TowerHealth.Instance.TakeDamage(damage);
            Destroy(gameObject);

        }
    }
}
