using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Examples.Profiling {
    public class ProfilingExample : MonoBehaviour {
        public MeshRenderer cubePrefab;
        public bool allocGameObject = true;
        public bool performSlowOperation = true;
        public int iterations = 10000;
        public bool lockTargetFPS;

        private void Start() {
            if (lockTargetFPS) {
                Application.targetFrameRate = 30;    
            }
        }

        private void Update() {
            if (allocGameObject) {
                var go = Instantiate(cubePrefab);
                //go.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            }

            if (performSlowOperation) {
                FindPrimeNumber(iterations);
            }
        }

        private long FindPrimeNumber(int n)
        {
            int count=0;
            long a = 2;
            while(count<n)
            {
                long b = 2;
                int prime = 1;// to check if found a prime
                while(b * b <= a)
                {
                    if(a % b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if(prime > 0)
                {
                    count++;
                }
                a++;
            }
            return (--a);
        }
    }
}
