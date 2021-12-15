using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class Panel3 : MonoBehaviour {
    public Text text;
    private int _darkColors;

    public void Initialize(ReadOnlyReactiveProperty<Color> color, ReactiveCommand<int> changeColorCount) {
        color
            .Subscribe(x => {
                var factor = x.a * x.b * x.g;

                if (factor < 0.125) {
                    text.text = "Dark or Intense";
                    _darkColors++;
                    changeColorCount.Execute(_darkColors);
                } else if (factor > 0.2) {
                    text.text = "Light";
                } else {
                    text.text = "Medium";
                }
            })
            .AddTo(this);
    }
}