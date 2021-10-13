using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class Element : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public float size = 2;
    private float _initialSize;
    private RectTransform _transform;
    public float duration = 2f;
    public AnimationCurve curve;
    private bool _needAnimation;

    private void Start() {
        _transform = GetComponent<RectTransform>();
        _initialSize = _transform.sizeDelta.x;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        var side = _initialSize * size;
        //_transform.sizeDelta = new Vector2(side, side);
        //StartCoroutine(Animate(new Vector2(side, side)));
        //_transform.DOSizeDelta(new Vector2(side, side), duration).SetEase(curve);
        _needAnimation = true;

    }

    public void OnPointerExit(PointerEventData eventData) {
        //_transform.sizeDelta = new Vector2(_initialSize, _initialSize);
        //StartCoroutine(Animate(new Vector2(_initialSize, _initialSize)));
        //_transform.DOSizeDelta(new Vector2(_initialSize, _initialSize), duration);
    }

    private void Update() {
        throw new NotImplementedException();
    }
}
