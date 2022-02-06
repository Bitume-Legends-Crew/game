using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public string inputSteerAxis = "Horizontal";
    public string inputThrottleAxis = "Vertical";
    
    public float ThrottleInput { get; private set; }
    public float SteerInput { get; private set; }

    PhotonView _view;
    
    void Awake()
    {
        _view = GetComponentInParent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_view.IsMine)
            return;
        SteerInput = Input.GetAxis(inputSteerAxis);
        ThrottleInput = Input.GetAxis(inputThrottleAxis);
    }
}
