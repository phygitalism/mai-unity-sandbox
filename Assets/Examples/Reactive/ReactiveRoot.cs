using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Examples.Reactive {
    public class ReactiveRoot : MonoBehaviour {
        [SerializeField] private Button button;
        [SerializeField] private Panel1 panel1;
        [SerializeField] private Panel2 panel2;
        [SerializeField] private Panel3 panel3;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        private readonly IReactiveProperty<Color> _color = new ReactiveProperty<Color>(Color.black);
        private readonly ReactiveCommand<int> _changeColorCount = new ReactiveCommand<int>();
        private void Start() {
            panel1.Initialize(_color, _changeColorCount);
            panel2.Initialize(_color.ToReadOnlyReactiveProperty());
            panel3.Initialize(_color.ToReadOnlyReactiveProperty(), _changeColorCount);
        }
    }
}