using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerMoves : MonoBehaviour {
    public float speed;
    private Rigidbody rb;
    private float horizontal;
    private float vertical;
    // private bool run;
    // [SerializeField] private Text speedText;

    PhotonView view;

    // Start is called before the first frame update
    private void Start() {
        rb = GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update() {
        if (view.IsMine) {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            // speed = vertical * horizontal * 10;
            // speedText.text = speed.ToString();
            if (horizontal != 0) 
                rb.AddForce(Vector3.right * horizontal * 10, ForceMode.Acceleration);
            if (vertical != 0) 
                rb.AddForce(Vector3.forward * vertical * 10, ForceMode.Acceleration);
        }
    }
    
}
