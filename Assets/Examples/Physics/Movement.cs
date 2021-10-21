using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {
    private Rigidbody _rigidbody;
    public float speed = 10;
    public float rotationSpeed = 10;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        var vertical = Input.GetAxis("Vertical");
        var hor = Input.GetAxis("Horizontal");
        Debug.Log(new Vector2(hor, vertical));
        
        _rigidbody.AddForce(new Vector3(0, 0, vertical * speed), ForceMode.Acceleration);
        _rigidbody.AddTorque(new Vector3(0, vertical, 0) * rotationSpeed);
    }
}
