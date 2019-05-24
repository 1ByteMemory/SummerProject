using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {

    Rigidbody rb;

    protected enum Orientation { local, world }

	// Use this for initialization
	protected virtual void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	protected Vector3 Velocity
    {
        get { return rb.velocity; }
        set { rb.velocity = Velocity; }
    }

    protected Vector3 localVelocity(Vector3 relativePoint)
    {
        return rb.GetRelativePointVelocity(relativePoint);
    }

    protected float Mass
    {
        get { return rb.mass; }
        set { rb.mass = Mass; }
    }

    protected void Move (Vector3 force, ForceMode forceMode, Orientation orientation)
    {
        if (orientation == Orientation.world)
            rb.AddForce(force, forceMode);
        else
            rb.AddRelativeForce(force, forceMode);
    }
}
