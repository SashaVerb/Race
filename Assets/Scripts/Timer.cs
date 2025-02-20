using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI _label;
    private float _sec = 0f;
    private int _min = 0;
    private void Awake()
    {
        _label = GetComponent<TextMeshProUGUI>();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        _label.text = "00:00";
    }

    private void Update()
    {
        Tick();
    }

    private void Tick()
    {
        _sec += Time.deltaTime;
        if (_sec >= 60f)
        {
            ++_min;
            _sec -= 60f;
        }

        _label.text = getTime();
    }

    public string getTime()
    {
        return (_min < 10 ? "0" : "") + _min.ToString() + ":" + ((int)_sec < 10 ? "0" : "") + ((int)_sec).ToString();
    }
}
