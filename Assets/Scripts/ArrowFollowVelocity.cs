using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ArrowFollowVelocity : MonoBehaviour
{
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (rb.velocity.sqrMagnitude > 0.1f)
        {
            // Apunta la flecha hacia su dirección de movimiento
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }
}