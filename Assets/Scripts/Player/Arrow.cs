
using System;
using UnityEngine;


public class Arrow : MonoBehaviour
{
    public float speed = 10f;


    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }
    
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("EnemyBasic") || other.gameObject.CompareTag("EnemyFlying") || other.gameObject.CompareTag("EnemyGiant"))
        {
            EnemyIA enemyIa = other.gameObject.GetComponent<EnemyIA>();
            if(enemyIa != null)
            {
                enemyIa.TakeDamage(2);
            }
            
            // Destruye la flecha después del impacto
            Destroy(gameObject);
        }
    }
}
