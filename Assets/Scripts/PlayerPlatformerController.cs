using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : MonoBehaviour {

    public float maxSpeed = 7;
    public float jump = 7;
    public float velocity;
    public Rigidbody rb;
    public float forceModifier = 1;
    public bool grounded=true;
    public float distToGround = 0;
    public Quaternion angle;
    public float fallMultiplier=2;
    private bool falling=false;
    public bool MakeFallFaster = false;
    private void Start()
    {
        distToGround = this.GetComponent<Collider>().bounds.extents.y;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        velocity = Input.GetAxis("Horizontal");
        this.transform.position +=new Vector3( velocity * forceModifier * Time.deltaTime,0,0);
        if (MakeFallFaster)
        {
            if (rb.velocity.y < 0 && falling)
            {
                falling = false;
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * fallMultiplier, rb.velocity.z);
            }
            if(rb.velocity.y > 0 || grounded) {
                fallMultiplier = 2;
            }
        }
        
    }
    private void FixedUpdate()
    {
        
        grounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
        if (Input.GetButtonDown("Jump") && grounded) {
            rb.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
        } 
        
    }
    private void OnTriggerEnter(Collider other)
    {

        angle = other.transform.rotation;
    }
}
