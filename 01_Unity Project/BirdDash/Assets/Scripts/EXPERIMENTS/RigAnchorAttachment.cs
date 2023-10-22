using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody))]
public class RigAnchorAttachment : MonoBehaviour
{
    private Rigidbody rb;

    public Rigidbody wheelBody;
    public bool useBodyRotation = false;

    public float upwardOffset;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        Vector3 upwardDirection = (useBodyRotation) ? wheelBody.transform.up : Vector3.up;



        rb.MovePosition(wheelBody.position + upwardDirection * upwardOffset);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            rb = GetComponent<Rigidbody>();

            Vector3 upwardDirection = (useBodyRotation) ? wheelBody.transform.up : Vector3.up;

            transform.position = wheelBody.position + upwardDirection * upwardOffset;

            Gizmos.DrawLine(transform.position, transform.position + transform.up * 10);
        }
    }
#endif
}
