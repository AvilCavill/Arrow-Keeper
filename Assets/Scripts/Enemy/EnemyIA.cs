using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class EnemyIA : MonoBehaviour
{
   
    public float damage = 1;
    public int health = 3;
    public Transform target;


    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        GameManager.GameManager.Instance.AddKill();
        Destroy(gameObject);
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
