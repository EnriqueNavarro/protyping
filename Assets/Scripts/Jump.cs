using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
    public float megaJump = 20;
    public bool doubleJump = true;
    public bool grounded = true;
    public float distToGround = 0;
    public Vector3 dir;
    public Quaternion angle;
    public bool angleJumping = false;
    public bool enableDoubleJumping = false;
    // Use this for initialization
    void Start() {
        distToGround = this.GetComponent<Collider>().bounds.extents.y;
    }
    private void FixedUpdate()
    {
        grounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
        angle = this.GetComponent<PlayerPlatformerController>().angle;

    }
    // Update is called once per frame
    void Update() {
        if (grounded && enableDoubleJumping) doubleJump = true;
        dir = angle * Vector3.right;
        dir = new Vector3(dir.x * -1, dir.y, dir.z);
        if (Input.GetButtonDown("Fire1") && doubleJump || grounded && !enableDoubleJumping && Input.GetButtonDown("Fire1")) {
            doubleJump = false;
            if (angleJumping) {
                this.GetComponent<PlayerPlatformerController>().fallMultiplier = 2.5f;
                if (dir.y == 0) dir = new Vector3(0, 1, 0);
                this.GetComponent<Rigidbody>().AddForce(dir * megaJump, ForceMode.Impulse);
            } else {
                this.GetComponent<Rigidbody>().AddForce(new Vector3(0,megaJump,0), ForceMode.Impulse);
            }
            
        }
        
	}
}
