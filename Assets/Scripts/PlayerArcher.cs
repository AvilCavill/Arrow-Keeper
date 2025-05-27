using UnityEngine;

public class PlayerArcher : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPoint;
    public float arrowSpeed = 30f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootArrow();
        }
    }

    void ShootArrow()
    {
        // Creamos la flecha con la rotación del shootPoint
        GameObject arrow = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);

        // Añadimos velocidad al Rigidbody
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        rb.velocity = shootPoint.forward * arrowSpeed;
    }
}