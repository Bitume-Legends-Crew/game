using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using Photon.Pun;

public class PlayerMoves : MonoBehaviour {
    public float speed;
    private Rigidbody rb;
    private float horizontal;
    private float vertical;

    PhotonView view;

    // Start is called before the first frame update
    private void Start() {
        rb = GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update() {
        if (view.IsMine)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical"); 
            if (horizontal != 0) 
                rb.AddForce(Vector3.right * horizontal * 10, ForceMode.Acceleration);
            if (vertical != 0) 
                rb.AddForce(Vector3.forward * vertical * 10, ForceMode.Acceleration);
        }
        
    }
}
