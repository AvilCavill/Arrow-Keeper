using UnityEngine;

namespace Enemy
{
    public class FlyingEnemyTarget : MonoBehaviour
    {
        public float speed = 4f;
        public Transform target;

        private void Start()
        {
            target = GameObject.FindGameObjectWithTag("ReachPoint2").transform;
        }

        void Update()
        {
            if (target == null) return;

            Vector3 dir = (target.position - transform.position).normalized;
            transform.position += dir * speed * Time.deltaTime;

        }
    }
}
