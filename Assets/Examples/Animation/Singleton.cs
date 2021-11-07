using UnityEngine;

namespace Examples.Animation {
    public class Singleton : MonoBehaviour {
        public static Singleton Instance;
        [SerializeField] private Transform user;

        public Transform User => user;

        private void Awake() {
            Instance = this;
            
            DontDestroyOnLoad(gameObject);
            
            if (FindObjectsOfType<Singleton>().Length > 1) {
                Destroy(gameObject);
            }
        }
        
        void Update()
        {
            
        }
    }
}
