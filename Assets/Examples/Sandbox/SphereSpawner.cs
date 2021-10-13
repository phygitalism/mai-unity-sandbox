using System.Collections;
using UnityEngine;

namespace Sandbox {
    public class SphereSpawner : MonoBehaviour {
        [SerializeField] 
        private Sphere sphere;
        
        [SerializeField] 
        private float spawnDelay = 3f;

        private void Start() {
            StartCoroutine(SpawnObject());
        }

        private IEnumerator SpawnObject() {
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(sphere);
        }
    }
}