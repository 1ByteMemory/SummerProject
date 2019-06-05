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
    private KeyCode jumpKey = KeyCode.Space;
    [SerializeField]
    private KeyCode fire = KeyCode.Mouse0;
    [SerializeField]
    private KeyCode altFire = KeyCode.Mouse1;

    [Header("")]
    [Range(0.5f, 2)]
    public float sensitivity = 1.6f;

    [Header("Player Properties")]
    [SerializeField]
    private float moveSpeed = 2;

    [SerializeField]
    private float jumpHieght = 1.5f;
    [SerializeField]
    private float longJump = 0.5f;

    private float longJumpDecay = 1;

    [SerializeField]
    [Range(0, 1)]
    private float strafMultiplier;

    [SerializeField]
    [Range(0, 1)]
    private float backMultiplier;
    
    private float maxStrafSpeed;
    private float maxBackSpeed;


    private Camera cam;
    private Camera HUDCam;
    private GroundCheck ground;

    // Use this for initialization
    protected override void Start () {
        base.Start();

        maxStrafSpeed = moveSpeed / 1.5f;
        maxBackSpeed = moveSpeed / 2;

        cam = Camera.main;
        HUDCam = GameObject.FindGameObjectWithTag("hudCam").GetComponent<Camera>();
        ground = GetComponentInChildren<GroundCheck>();
	}

    
	// Update is called once per frame
	void Update () {
        MovePlayer();

        LookAround();

        Jump();

        //Debug.Log(Velocity);
	}
    
    void MovePlayer()
    {
        // Convert the velocity fro world space to local space
        Vector3 localVelocity = transform.InverseTransformVector(Velocity);

        // Move
        if (localVelocity.z < moveSpeed)
            if (Input.GetKey(forward))
                Move(Vector3.forward, ForceMode.Impulse, Orientation.local);


        if (Mathf.Abs(localVelocity.z) < maxBackSpeed)
            if (Input.GetKey(backward))
                Move(Vector3.back * backMultiplier, ForceMode.Impulse, Orientation.local);


        if (Mathf.Abs(localVelocity.x) < maxStrafSpeed)
        {
            if (Input.GetKey(strafRight))
                Move(Vector3.right * strafMultiplier, ForceMode.Impulse, Orientation.local);
            if (Input.GetKey(strafLeft))
                Move(Vector3.left * strafMultiplier, ForceMode.Impulse, Orientation.local);
        }
    }

    void LookAround()
    {
        Vector3 lookAngle = cam.transform.localEulerAngles;

        if (!Cursor.visible)
        {
            lookAngle.x -= Input.GetAxis("Mouse Y") * sensitivity;
            lookAngle.y += Input.GetAxis("Mouse X") * sensitivity;
        }

        // Rotates player left and right.
        transform.eulerAngles += new Vector3(0, lookAngle.y);

        // Look up and Down limits

        //Stops the player from bending over backwards.
        if (lookAngle.x > 88 && lookAngle.x < 180)
        {
            cam.transform.localEulerAngles = new Vector3(88, 0);
            HUDCam.transform.localEulerAngles = new Vector3(88, 0);
        }

        // Stops the player from bending over forwards to far.
        else if (lookAngle.x < 278 && lookAngle.x > 180)
        {
            cam.transform.localEulerAngles = new Vector3(278, 0);
            HUDCam.transform.localEulerAngles = new Vector3(278, 0);
        }

        // If the player is just looking straight on, then just set that as the look angle.
        else
        {
            cam.transform.localEulerAngles = new Vector3(lookAngle.x, 0);
            HUDCam.transform.localEulerAngles = new Vector3(lookAngle.x, 0);
        }
    }

    void Jump()
    {
        if (ground.isGrounded)
            longJumpDecay = 1;

        if (Input.GetKey(jumpKey) && ground.isGrounded)
            Move(Vector3.up * jumpHieght, ForceMode.Impulse, Orientation.world);

        // Allow the player to hold down the jump key for longer jump.
        if (Input.GetKey(jumpKey) && !ground.isGrounded && longJumpDecay > 0)
        {
            Move(Vector3.up * longJump, ForceMode.Impulse, Orientation.world);
            longJumpDecay -= 0.01f;
            //Debug.Log(longJumpDecay);
        }
    }
}
