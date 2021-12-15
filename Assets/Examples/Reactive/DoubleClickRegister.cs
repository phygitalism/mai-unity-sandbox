using System;
using System.Diagnostics;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using Debug = UnityEngine.Debug;

namespace Examples.Reactive {
    public class DoubleClickRegister : MonoBehaviour
    {
        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        private const float INTERVAL_THRESHOLD = 250;
        
        private int _clickCount;
        private readonly Stopwatch _stopwatch = new Stopwatch();
        public bool isTracking = true;

        private void Start() {
            var clickStream = Observable
                .EveryUpdate()
                .Where(_ => Input.GetMouseButtonDown(0));

            clickStream
                .Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(INTERVAL_THRESHOLD)))
                .Where(clicks => clicks.Count >= 2)
                .Subscribe(xs => Debug.Log("DoubleClick Detected via UniRx!"))
                .AddTo(_disposable);
            
            _stopwatch.Start();
        }
        
        private void Update() {
            TrackDoubleClick();
        }

        private void TrackDoubleClick() {
            if (!isTracking) {
                return;
            }

            if (Input.GetMouseButtonDown(0)) {
                _clickCount++;
            }

            if (_stopwatch.ElapsedMilliseconds > INTERVAL_THRESHOLD) {
                if (_clickCount > 1) {
                    Debug.Log("DoubleClick Detected via Update!");
                }
                _clickCount = 0;
                _stopwatch.Restart();
            }
        }

        private void RegisterDragOnce() {
            var signal = this.OnMouseDownAsObservable()
                .SelectMany(_ => this.UpdateAsObservable())
                .TakeUntil(this.OnMouseUpAsObservable())
                .Select(_ => Input.mousePosition)
                .Subscribe(x => Debug.Log(x))
                .AddTo(_disposable);
        }
    }
}
