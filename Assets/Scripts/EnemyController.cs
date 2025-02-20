using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform target;

    private CarController carController;
    Vector3 vectorToTarget;
    private void Start()
    {
        carController = GetComponent<CarController>();
    }

    private void Update()
    {
        vectorToTarget = target.position - transform.position;
        vectorToTarget = transform.InverseTransformDirection(vectorToTarget);

        carController.SetInput(vectorToTarget.x, 1f, false);
    }
}
