using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CarController carController;

    private void Start()
    {
        carController = GetComponent<CarController>();
    }

    private void Update()
    {
        carController.SetInput(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"),
            Input.GetKey(KeyCode.Space)
            );
    }

    public void StopCar()
    {
        carController.SetInput(0f, 0f, true);
    }
}
