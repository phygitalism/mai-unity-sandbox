using UnityEngine;

namespace Sandbox {
    public class Sphere : MonoBehaviour {
        [SerializeField]
        private float speed = 0.001f;

        private void Update() {
            transform.localScale += Vector3.one * speed;
        }
    }
}