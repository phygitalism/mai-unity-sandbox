using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace Examples {
    public class ColorChanger : MonoBehaviour {
        [SerializeField] private float Border = 3;
        public Color[] colors;
        [SerializeField] private MeshRenderer renderer;
        private bool InTopLeft => transform.position.x < 0 && transform.position.z > 0;
        private float? bb;
        
        public static event EventHandler Event;
        public static Action action;

        private void Awake() {
            var material = renderer.material;
            Assert.IsNotNull(material, "Material is null!");
            
            renderer ??= GetComponent<MeshRenderer>();

            Event += OnEvent;
        }

        private void OnEvent(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private int Func(int arg) {
            return arg * 2;
        }
        

        private void ONAwake(float f) {
            Debug.Log("1");
        }

        public float GetBorder() {
            return Border;
        }

        private void Update() {
            var position = transform.localPosition;

            if (position.x > Border) {
                renderer.material.color = colors[0];
            }
            
            if (position.z > Border) {
                renderer.material.color = colors[1];
            }
        }
    }
}
