using UnityEngine;

namespace Sandbox {
    public class Cube : MonoBehaviour {
        [SerializeField]
        private MeshRenderer meshRenderer;

        [SerializeField]
        private Vector3 movementDirection = Vector3.right;

        [Range(-0.1f, 0.1f), SerializeField]
        private float speedFactor = 0.001f;

        private Camera _camera;
        private RaycastHit _hit;
        private Ray _ray;

        private void Start() {
            _camera = Camera.main;
        }

        private void Update() {
            MoveAccordingToDirection(movementDirection, speedFactor);

            if (IsClickedOnCube()) {
                ChangeColor();
            }
        }

        private void ChangeColor() {
            var material = meshRenderer.material;
            material.color = Color.blue;
            meshRenderer.material = material;
        }

        private void MoveAccordingToDirection(Vector3 direction, float speed) {
            transform.localPosition += direction * speed;
        }

        private bool IsClickedOnCube() {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit)) {
                if (Input.GetMouseButtonDown(0)) {
                    Debug.Log($"IsClickedOnCube: {_hit.collider.gameObject == gameObject}");
                    return _hit.collider.gameObject == gameObject;
                }
            }
            return false;
        }
    }
}