using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine.UI;

public class CarController : MonoBehaviour {
    //public float speed;
    //private Rigidbody rb;

    private float horizontalInput;
    private float verticalInput;
    private bool isBreaking;
    private float steerAngle; 

    [SerializeField] private float motorForce;
    [SerializeField] private float brakeForce;
    [SerializeField] private float maxSteerAngle;
    //
    // // private bool run;
    // // [SerializeField] private Text speedText;
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;
    
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    // private void Start() {
    //     rb = GetComponent<Rigidbody>();
    //     view = GetComponent<PhotonView>();
    // }
    // Update is called once per frame
    // void Update() {
    //     if (view.IsMine) {
    //         horizontal = Input.GetAxis("Horizontal");
    //         vertical = Input.GetAxis("Vertical");
    //         // speed = vertical * horizontal * 10;
    //         // speedText.text = speed.ToString();
    //         if (horizontal != 0) 
    //             rb.AddForce(Vector3.right * horizontal * 10, ForceMode.Acceleration);
    //         if (vertical != 0) 
    //             rb.AddForce(Vector3.forward * vertical * 10, ForceMode.Acceleration);
    //     }
    // }

    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            GetInput();
            HandleMotor();
            HandleSteering();
            UpdateWheels();
        }
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleSteering()
    {
        steerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce * 10;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce * 10;
        
        brakeForce = isBreaking ? 3000f : 0f;
        frontLeftWheelCollider.brakeTorque = brakeForce;
        frontRightWheelCollider.brakeTorque = brakeForce;
        rearLeftWheelCollider.brakeTorque = brakeForce;
        rearRightWheelCollider.brakeTorque = brakeForce;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
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
