using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {
    public Vector3 destination;
    public float speed = 1;
    public float distance = 2;
    public GameObject node;
    public GameObject player;
    public GameObject lastNode;
    public Vector3 pos;
    public bool done=false;
    public List<GameObject> nodes = new List<GameObject>();
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        lastNode = transform.gameObject;
        nodes.Add(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position,destination,speed);
        if(transform.position!=destination && !done) {
            if (Vector3.Distance(player.transform.position, lastNode.transform.position) >= distance) {
                createNode();
            }
        } else {
            if(!done) {
                done = true;
                lastNode.GetComponent<HingeJoint>().connectedBody = player.GetComponent<Rigidbody>();
            }
        }
	}
    void createNode() {
        pos = player.transform.position - lastNode.transform.position;
        pos.Normalize();
        pos *= distance;
        pos += lastNode.transform.position;
        GameObject aux= Instantiate(node, pos, Quaternion.identity);
        //aux.transform.SetParent(transform);
        lastNode.GetComponent<HingeJoint>().connectedBody = aux.GetComponent<Rigidbody>();
        lastNode = aux;
        nodes.Add(lastNode);
    }
    
    Vector3 OnMouseDown()
    {
        return transform.position;
    }
}
