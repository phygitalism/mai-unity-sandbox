using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Panel1 : MonoBehaviour {
    public Button randomizeButton;
    public Text displayText;
    public Text countDarkColors;

    public void Initialize(IReactiveProperty<Color> color, ReactiveCommand<int> changeColorCount) {
        color
            .Subscribe(x => displayText.text = $"New color: {x.ToString()}")
            .AddTo(this);

        randomizeButton
            .OnClickAsObservable()
            .Subscribe(_ => color.Value = Random.ColorHSV())
            .AddTo(this);

        changeColorCount
            .Subscribe(count => countDarkColors.text = $"Darkness in count: {count}")
            .AddTo(this);
    }
}
