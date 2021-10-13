using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Sandbox {
    public class Spawner : MonoBehaviour {
        [SerializeField]
        private Button spawnButton, stopButton;

        [SerializeField]
        private GameObject spawnObject;

        [SerializeField]
        private float spawnDelay = 1f;

        private Coroutine _coroutine;

        private void Start() {
            spawnButton.onClick.AddListener(StartSpawn);
            stopButton.onClick.AddListener(StopSpawn);
        }

        private void StartSpawn() {
            Debug.Log("StartSpawn");
            _coroutine = StartCoroutine(Spawn(spawnObject));
        }

        private void StopSpawn() {
            Debug.Log("StopSpawn");
            StopCoroutine(_coroutine);
        }

        private IEnumerator Spawn(GameObject obj) {
            while (true) {
                yield return new WaitForSeconds(spawnDelay);
                Instantiate(spawnObject);
            }
        }
    }
}