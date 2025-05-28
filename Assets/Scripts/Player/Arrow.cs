
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
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Aquí hay otro error: deberías obtener el EnemyIA del objeto colisionado, no de la flecha
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
