using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform playerRespawnPoint;
    [SerializeField] private Transform enemyRespawnPoint;

    LayerMask mask = new LayerMask();

    private void Start()
    {
        mask.value = LayerMask.NameToLayer("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == mask.value)
        {
            other.transform.position = playerRespawnPoint.position;
            other.transform.rotation = playerRespawnPoint.rotation;
        }
        else
        {
            other.transform.position = enemyRespawnPoint.position;
            other.transform.rotation = enemyRespawnPoint.rotation;
        }
        

        if(other.TryGetComponent<CarController>(out CarController carController))
        {
            carController.Reset();
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
