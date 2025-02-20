using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class StartCount : MonoBehaviour
{
    [SerializeField]
    public UnityEvent OnCountFinish;

    private TextMeshProUGUI _label;

    private float SCALE_DURATION = 1f;
    private float SCALE_TARGET = 0.6f;

    private void Start()
    {
        _label = GetComponent<TextMeshProUGUI>();

        Sequence count = DOTween.Sequence();
        count
            .SetLink(gameObject)
            .AppendCallback(() => ChangeText("3"))
            .AppendCallback(() => RefreshScale())
            .Append(_label.rectTransform.DOScale(SCALE_TARGET, SCALE_DURATION))
            .AppendCallback(() => ChangeText("2"))
            .AppendCallback(() => RefreshScale())
            .Append(_label.rectTransform.DOScale(SCALE_TARGET, SCALE_DURATION))
            .AppendCallback(() => ChangeText("1"))
            .AppendCallback(() => RefreshScale())
            .Append(_label.rectTransform.DOScale(SCALE_TARGET, SCALE_DURATION))
            .AppendCallback(() => ChangeText("GO"))
            .AppendCallback(() => RefreshScale())
            .AppendCallback(() =>
            {
                OnCountFinish.Invoke();
            })
            .AppendInterval(1f)
            .AppendCallback(() =>
            {
                ChangeText("");
                gameObject.SetActive(false);
            });
    }

    private void ChangeText(string text)
    {
        _label.text = text;
    }

    private void RefreshScale()
    {
        _label.rectTransform.localScale = Vector3.one;
    }
}
