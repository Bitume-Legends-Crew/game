using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine.UI;

public class CarController : MonoBehaviour {
    // Version 1.0
    // //public float speed;
    // //private Rigidbody rb;
    //
    // private float horizontalInput;
    // private float verticalInput;
    // private bool isBreaking;
    // private float steerAngle; 
    //
    // [SerializeField] private float motorForce;
    // [SerializeField] private float brakeForce;
    // [SerializeField] private float maxSteerAngle;

    
    // Version 2.0
    // public WheelCollider frontLeftWheelCollider;
    // public WheelCollider frontRightWheelCollider;
    // public WheelCollider rearLeftWheelCollider;
    // public WheelCollider rearRightWheelCollider;
    //
    // public Transform frontLeftWheelTransform;
    // public Transform frontRightWheelTransform;
    // public Transform rearLeftWheelTransform;
    // public Transform rearRightWheelTransform;

    public Transform centerOfMass;
    public float motorTorque = 1200f;
    public float maxSteer = 20f;

    public float Steer { get; set; }
    public float Throttle { get; set; }

    private Rigidbody _rigidbody;
    private WheelController[] wheels;
    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        wheels = GetComponentsInChildren<WheelController>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerOfMass.localPosition;
    }

    void Update()
    {
        if (view.IsMine)
        {
            Steer = GameManagerScript.Instance.InputController.SteerInput;
            Throttle = GameManagerScript.Instance.InputController.ThrottleInput;
            foreach (var wheel in wheels) 
            {
                wheel.SteerAngle = Steer * maxSteer; 
                wheel.Torque = Throttle * motorTorque;
            }
        }
        
    }

    // Version 2.0
    // void FixedUpdate()
    // {
    //     rearLeftWheelCollider.motorTorque = Input.GetAxis("Vertical") * motorTorque;
    //     rearRightWheelCollider.motorTorque = Input.GetAxis("Vertical") * motorTorque;
    //     frontLeftWheelCollider.steerAngle = Input.GetAxis("Horizontal") * maxSteer;
    //     frontRightWheelCollider.steerAngle = Input.GetAxis("Horizontal") * maxSteer;
    // }
    //
    // void Update()
    // {
    //     var pos = Vector3.zero;
    //     var rot = Quaternion.identity;
    //     
    //     frontLeftWheelCollider.GetWorldPose(out pos, out rot);
    //     frontLeftWheelTransform.position = pos;
    //     frontLeftWheelTransform.rotation = rot;
    //
    //     frontRightWheelCollider.GetWorldPose(out pos, out rot);
    //     frontRightWheelTransform.position = pos;
    //     frontRightWheelTransform.rotation = rot;
    //
    //     rearLeftWheelCollider.GetWorldPose(out pos, out rot);
    //     rearLeftWheelTransform.position = pos;
    //     rearLeftWheelTransform.rotation = rot;
    //
    //     rearRightWheelCollider.GetWorldPose(out pos, out rot);
    //     rearRightWheelTransform.position = pos;
    //     rearRightWheelTransform.rotation = rot;
    // }

    
    // Versions 0.1 and 1.0
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

    // private void FixedUpdate()
    // {
    //     if (view.IsMine)
    //     {
    //         GetInput();
    //         HandleMotor();
    //         HandleSteering();
    //         UpdateWheels();
    //     }
    // }
    //
    // private void GetInput()
    // {
    //     horizontalInput = Input.GetAxis("Horizontal");
    //     verticalInput = Input.GetAxis("Vertical");
    //     isBreaking = Input.GetKey(KeyCode.Space);
    // }
    //
    // private void HandleSteering()
    // {
    //     steerAngle = maxSteerAngle * horizontalInput;
    //     frontLeftWheelCollider.steerAngle = steerAngle;
    //     frontRightWheelCollider.steerAngle = steerAngle;
    // }
    //
    // private void HandleMotor()
    // {
    //     frontLeftWheelCollider.motorTorque = verticalInput * motorForce * 10;
    //     frontRightWheelCollider.motorTorque = verticalInput * motorForce * 10;
    //     
    //     brakeForce = isBreaking ? 3000f : 0f;
    //     frontLeftWheelCollider.brakeTorque = brakeForce;
    //     frontRightWheelCollider.brakeTorque = brakeForce;
    //     rearLeftWheelCollider.brakeTorque = brakeForce;
    //     rearRightWheelCollider.brakeTorque = brakeForce;
    // }
    //
    // private void UpdateWheels()
    // {
    //     UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
    //     UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
    //     UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    //     UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
    // }
    //
    // private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    // {
    //     Vector3 pos;
    //     Quaternion rot;
    //     wheelCollider.GetWorldPose(out pos, out rot);
    //     wheelTransform.rotation = rot;
    //     wheelTransform.position = pos;
    // }
}
