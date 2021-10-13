using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour {
    [SerializeField] private Toggle toggle;

    private void Start() {
        toggle.onValueChanged.AddListener(PrintWithBool);
    }

    public void PrintWithBool(bool isOn) {
        Debug.Log(isOn);
    }
    
    public void Print(string text) {
        Debug.Log(text);
    }
}
