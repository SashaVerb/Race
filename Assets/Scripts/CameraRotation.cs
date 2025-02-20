using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform targetObject;

    private void Update()
    {
        transform.LookAt(targetObject.position);
    }
}
