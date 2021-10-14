using UnityEngine;

namespace Examples {
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour {
        public float speed;
        private Rigidbody _rigidbody;

        private void Awake() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update() {
            _rigidbody.velocity += GetDirection() * speed * Time.deltaTime;
        }

        private Vector3 GetDirection() {
            var vert = Input.GetAxis("Vertical");
            var hor = Input.GetAxis("Horizontal");
            var direction = new Vector3(hor, 0, vert);
            return direction;
        }
    }
}