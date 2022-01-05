using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float verticalInput;
    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical1");

        // move the plane forward at a constant rate
        rigidbody.velocity = Vector3.forward * speed;

        // tilt the plane up/down based on up/down arrow keys
        transform.Translate(Vector3.up * rotationSpeed * Time.deltaTime*verticalInput);
    }
}
