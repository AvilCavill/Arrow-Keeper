using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Camera mainCamera;

    void Update()
    {
        Move();
        RotateTowardsMouse();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(h, 0, v).normalized;

        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    void RotateTowardsMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 targetPoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            Vector3 direction = (targetPoint - transform.position).normalized;

            if (direction != Vector3.zero)
                transform.forward = direction;
        }
    }
}