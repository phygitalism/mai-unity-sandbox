using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    private Camera _camera;
    private void Awake() {
        _camera = Camera.main;
    }

    private void Update() {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100)) {
            Debug.Log($"Hit: {hit.transform.gameObject.name}");
        }
    }
}
