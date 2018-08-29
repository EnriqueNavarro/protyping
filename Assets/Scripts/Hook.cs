using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {
    public GameObject hook;
    public GameObject curHook;
    public GameObject lastHook;
    public Vector3 mousePos;
    public Camera cam;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag=="Hook")
            {
                
                mousePos = hit.transform.position;
                curHook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);
                curHook.GetComponent<Rope>().destination = mousePos;
            }
        }


        if (Input.GetButtonDown("Fire1")) {
                        
            //curHook =(GameObject) Instantiate(hook, transform.position, Quaternion.identity);
            //curHook.GetComponent<Rope>().destination = mousePos;
        }
	}
    
}
