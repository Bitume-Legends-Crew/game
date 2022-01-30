using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    
    public Vector3 offset;
    //public Vector3 eulerRotation;
    public float translateSpeed;
    public float rotationSpeed;

    PhotonView _view;
    
    void Start()
    {
        _view = GetComponent<PhotonView>();
        //transform.eulerAngles = eulerRotation;
    }

    private void FixedUpdate()
    {
        if (_view.IsMine)
        {
            HandleTranslation();
            HandleRotation();
        }
    }

    private void HandleRotation()
    {
        var direction = Target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, (Vector3.up));
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    private void HandleTranslation()
    {
        var targetPosition = Target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
    }

    // void Update()
    // {
    //     // if (_view.IsMine)
    //     // {
    //         if (Target == null)
    //             return;
    //         
    //         transform.position = Vector3.Lerp(transform.position, Target.position + offset, damper * Time.time);
    //     // }
    // }
}
