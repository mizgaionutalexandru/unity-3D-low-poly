using System;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] private WheelCollider frontLeftCollider, frontRightCollider;
    [SerializeField] private WheelCollider rearLeftCollider, rearRightCollider;

    [SerializeField] private Transform frontLeftTransform, frontRightTransform;
    [SerializeField] private Transform rearLeftTransform, rearRightTransform;

    [SerializeField] private float motorForce, brakeForce, maxSteerAngle;

    private bool isBreaking;
    private float accelerationInput;
    private float steeringInput;
    private float currentSteerAngle;
    private float currentBrakeForce;

    public void Update()
    {
        accelerationInput = Input.GetAxis("Vertical"); 
        steeringInput = Input.GetAxis("Horizontal");
        isBreaking = Input.GetKey(KeyCode.Space);

        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void HandleMotor()
    {
        frontLeftCollider.motorTorque = accelerationInput * motorForce;
        frontRightCollider.motorTorque = accelerationInput * motorForce;
        currentBrakeForce = isBreaking ? brakeForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        frontLeftCollider.brakeTorque = currentBrakeForce;
        frontRightCollider.brakeTorque = currentBrakeForce;
        rearLeftCollider.brakeTorque = currentBrakeForce;
        rearRightCollider.brakeTorque = currentBrakeForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * steeringInput;
        frontLeftCollider.steerAngle = currentSteerAngle;
        frontRightCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftCollider, frontLeftTransform);
        UpdateSingleWheel(frontRightCollider, frontRightTransform);
        UpdateSingleWheel(rearLeftCollider, rearLeftTransform);
        UpdateSingleWheel(rearRightCollider, rearRightTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
