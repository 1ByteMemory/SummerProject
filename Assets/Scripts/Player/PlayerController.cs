using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Movement {

    // Movement Inputs
    [Header("Inputs")]
    [SerializeField]
    private KeyCode forward = KeyCode.W;
    [SerializeField]
    private KeyCode backward = KeyCode.S;
    [SerializeField]
    private KeyCode strafLeft = KeyCode.A;
    [SerializeField]
    private KeyCode strafRight = KeyCode.D;
    [SerializeField]
    private KeyCode jump = KeyCode.Space;
    [SerializeField]
    private KeyCode fire = KeyCode.Mouse0;
    [SerializeField]
    private KeyCode altFire = KeyCode.Mouse1;

    [Header("Player Properties")]
    [SerializeField]
    private float moveSpeed = 2;

    [SerializeField]
    [Range(0, 1)]
    private float strafMultiplier;

    [SerializeField]
    [Range(0, 1)]
    private float backMultiplier;
    
    private float maxStrafSpeed;
    private float maxBackSpeed;

    // Use this for initialization
    protected override void Start () {
        base.Start();

        maxStrafSpeed = moveSpeed / 1.5f;
        maxBackSpeed = moveSpeed / 2;

        
	}

    
	// Update is called once per frame
	void Update () {
        MovePlayer();

        Debug.Log(Velocity);
	}
    
    void MovePlayer()
    {
        // Move
        if (Velocity.z < moveSpeed)
            if (Input.GetKey(forward))
                Move(Vector3.forward, ForceMode.Impulse);


        if (Mathf.Abs(Velocity.z) < maxBackSpeed)
            if (Input.GetKey(backward))
                Move(Vector3.back * backMultiplier, ForceMode.Impulse);


        if (Mathf.Abs(Velocity.x) < maxStrafSpeed)
        {
            if (Input.GetKey(strafRight))
                Move(Vector3.right * strafMultiplier, ForceMode.Impulse);
            if (Input.GetKey(strafLeft))
                Move(Vector3.left * strafMultiplier, ForceMode.Impulse);
        }
    }
}
