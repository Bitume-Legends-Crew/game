using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public Transform centerOfMass;
    public float motorTorque = 1200f;
    public float maxSteer = 20f;
    public string inputSteerAxis = "Horizontal";
    public string inputThrottleAxis = "Vertical";

    public float Steer { get; set; }
    public float Throttle { get; set; }

    private Rigidbody _rigidbody;
    private WheelController[] wheels;
    PhotonView _view;

    private void Awake()
    {
        _view = GetComponent<PhotonView>();
        _rigidbody = GetComponentInChildren<Rigidbody>();
        wheels = GetComponentsInChildren<WheelController>();
        _rigidbody.centerOfMass = centerOfMass.localPosition;
    }

    private void Start()
    {
        if (!_view.IsMine)
        {
            Camera[] cameras = GetComponentsInChildren<Camera>();
            foreach (var cam in cameras)
            {
                Destroy(cam.gameObject);
            }

            //Destroy(_rigidbody);
        }
    }

    void Update()
    {
        if (!_view.IsMine)
            return;
        Steer = Input.GetAxis(inputSteerAxis);
        Throttle = Input.GetAxis(inputThrottleAxis);
        foreach (var wheel in wheels)
        {
            wheel.SteerAngle = Steer * maxSteer;
            wheel.Torque = Throttle * motorTorque;
        }
    }
}