using System;
using DG.Tweening;
using UnityEngine;

namespace Examples.Animation {
    public class ObjectRotation : MonoBehaviour {
        [SerializeField] private float speed = 1f;
        [SerializeField] private Vector3 velocity = Vector3.up;
        //[SerializeField] private AnimationCurve curve;
        [SerializeField] private Ease curve;
        
        private void Start() {
            transform
                .DOLocalRotate(Vector3.up * 180, 5f, RotateMode.Fast)
                .SetEase(curve)
                .SetDelay(5f)
                .OnComplete(() => Debug.Log("Rotate"));
        }

        private void Update() {
            //transform.localEulerAngles += velocity * speed * Time.deltaTime;
        }
    }
}
