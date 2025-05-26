using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArcher : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootpoint;
    public float arrowForce;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootArrow();
        }
    }

    public void ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, shootpoint.position, Quaternion.identity);
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        rb.velocity = arrow.transform.forward * arrowForce;
    }
}
