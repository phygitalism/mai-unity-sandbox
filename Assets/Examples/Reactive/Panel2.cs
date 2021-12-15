using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class Panel2 : MonoBehaviour {
    public Image image;

    public void Initialize(ReadOnlyReactiveProperty<Color> color) {
        color
            .Subscribe(x => image.color = x)
            .AddTo(this);
    }
}
