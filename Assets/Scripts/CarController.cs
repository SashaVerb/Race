using UnityEngine;
public class CarController : MonoBehaviour
{
    private float horizontalInput = 0f;
    private float verticalInput = 0f;
    private float steerAngle;
    private bool isBreaking = false;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;
    
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    public float maxSteeringAngle = 30f;
    public float motorForce = 50f;
    public float brakeForce = 3000f;


    private void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    public void SetInput(float horizontalInput, float verticalInput, bool isBreaking)
    {
        this.horizontalInput = Mathf.Clamp(horizontalInput, -1f, 1f);
        this.verticalInput = Mathf.Clamp(verticalInput, -1f, 1f);
        this.isBreaking = isBreaking;
    }

    public void Reset()
    {
        frontLeftWheelCollider.motorTorque = 0;
        frontRightWheelCollider.motorTorque = 0;

        frontLeftWheelCollider.rotationSpeed = 0;
        frontRightWheelCollider.rotationSpeed = 0;
        rearLeftWheelCollider.rotationSpeed = 0;
        rearRightWheelCollider.rotationSpeed = 0;
    }

    private void HandleSteering()
    {
        steerAngle = maxSteeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;

        if(isBreaking)
        {
            SetBrakeTorque(brakeForce);
        }
        else
        {
            SetBrakeTorque(0f);
        }

    }

    private void SetBrakeTorque(float brakeTorque)
    {
        frontLeftWheelCollider.brakeTorque = brakeTorque;
        frontRightWheelCollider.brakeTorque = brakeTorque;
        rearLeftWheelCollider.brakeTorque = brakeTorque;
        rearRightWheelCollider.brakeTorque = brakeTorque;
    }

    private void UpdateWheels()
    {
        UpdateWheelPos(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPos(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPos(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPos(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateWheelPos(WheelCollider wheelCollider, Transform trans)
    {
        wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
        trans.rotation = rot;
        trans.position = pos;
    }

}
