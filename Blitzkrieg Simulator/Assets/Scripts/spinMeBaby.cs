using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinMeBaby : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddTorque(0, 1, 0);
    }
}
