using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    [SerializeField]
    public UnityEvent OnFinish;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController _))
        {
            OnFinish.Invoke();
            gameObject.SetActive(false);
        }
    }
}
