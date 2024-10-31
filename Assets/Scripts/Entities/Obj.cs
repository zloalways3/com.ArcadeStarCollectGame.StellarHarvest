using UnityEngine;

namespace Entities
{
    public abstract class Obj : MonoBehaviour
    {
        [SerializeField] private float speed;

        public bool IsStopped { get; set; } = false;

        private void FixedUpdate()
        {
            if (IsStopped)
                return;
            
            transform.position += Vector3.down * (speed * Time.fixedDeltaTime);
        }
    }
}