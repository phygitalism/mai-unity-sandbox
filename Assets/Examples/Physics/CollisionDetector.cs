using UnityEngine;

namespace Examples.Physics {
    public class CollisionDetector : MonoBehaviour {
        private void OnCollisionEnter(Collision other) {
            Debug.Log($"Collision: {gameObject.name} with {other.gameObject.name}");
        }

        private void OnTriggerEnter2D(Collider2D other) {
            Debug.Log($"Trigger Enter: {gameObject.name} with {other.gameObject.name}");
        }

        private void OnTriggerExit(Collider other) {
            Debug.Log($"Trigger Exit: {gameObject.name} with {other.gameObject.name}");
        }

        private void OnTriggerStay(Collider other) {
            Debug.Log($"Trigger Stay: {gameObject.name} with {other.gameObject.name}");
        }
    }
}