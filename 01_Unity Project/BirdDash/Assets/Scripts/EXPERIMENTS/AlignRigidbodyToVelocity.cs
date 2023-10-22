using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AlignRigidbodyToVelocity : MonoBehaviour
{
    private Rigidbody rb;

    public Rigidbody rigidbodyToAlignTo;

    public float acceleration = 2;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 velocity = rigidbodyToAlignTo.velocity.normalized;

        if(velocity.magnitude > 0)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(velocity, Vector3.up);

            rb.rotation = desiredRotation;
        }
    }
}
