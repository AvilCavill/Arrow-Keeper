using UnityEngine;

public class PlayerArcher : MonoBehaviour
{
    public Transform[] positions; // [0] = abajo, [1] = medio, [2] = arriba
    private int currentIndex = 1; // empieza en el medio

    public GameObject arrowPrefab;
    public Transform shootPoint;
    public float arrowSpeed = 30f;

    void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    void HandleMovement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Move(1); // subir
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Move(-1); // bajar
        }
    }

    void Move(int direction)
    {
        int newIndex = Mathf.Clamp(currentIndex + direction, 0, positions.Length - 1);
        if (newIndex != currentIndex)
        {
            currentIndex = newIndex;
            transform.position = positions[currentIndex].position;
        }
    }

    void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0)) // Click derecho
        {

            GameObject arrow = Instantiate(
                arrowPrefab,
                shootPoint.position,
                shootPoint.rotation);

            Arrow arrowScript = arrow.GetComponent<Arrow>();
            arrowScript.speed = arrowSpeed;
        }
    }
}