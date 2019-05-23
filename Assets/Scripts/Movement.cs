using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {

    Rigidbody rb;

	// Use this for initialization
	protected virtual void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	protected Vector3 Velocity
    {
        get { return rb.velocity; }
        set { rb.velocity = Velocity; }
    }

    protected float Mass
    {
        get { return rb.mass; }
        set { rb.mass = Mass; }
    }

    protected void Move (Vector3 force, ForceMode forceMode)
    {
        rb.AddForce(force, forceMode);
    }
}
