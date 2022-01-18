using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private float horizontal;

    // Start is called before the first frame update
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.forward * speed);
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
            rb.AddForce(Vector3.right * horizontal * 10, ForceMode.Acceleration);
    }
}
