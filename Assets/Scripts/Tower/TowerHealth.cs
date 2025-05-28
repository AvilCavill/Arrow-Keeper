using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{

    public static TowerHealth Instance;
    public float health = 10;

    private void Awake()
    {
        Instance = this;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("La torre ha caido!");
        }
        {
            
        }
    }
}
