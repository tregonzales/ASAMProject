using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userController : MonoBehaviour {

    public float walkSpeed;

    public float walkBounce;

    Transform camTrans;

    RaycastHit hit;

    Rigidbody body;

    bool moving;

    public float bounceTime;

    float timer;

    // Use this for initialization
    void Start () {
        // Cursor.lockState = CursorLockMode.Locked; 
		camTrans = Camera.main.transform;
        body = GetComponent<Rigidbody>();
        moving = false;
        timer = bounceTime;
	}

    //to do:
    //create pause menu and deal with showing and hiding cursor
	
	// Update is called once per frame
	void Update () {
        moving = false;
        if (Input.GetKey(KeyCode.W)) {
            body.velocity = Vector3.ClampMagnitude(body.velocity + transform.forward, walkSpeed);
            moving = true;
        }
        if (Input.GetKey(KeyCode.D)) {
           body.velocity = Vector3.ClampMagnitude(body.velocity + transform.right, walkSpeed);
            moving = true;
        }
        if (Input.GetKey(KeyCode.A)) {
           body.velocity = Vector3.ClampMagnitude(body.velocity + -1*transform.right, walkSpeed);
            moving = true;
        }
        if (Input.GetKey(KeyCode.S)) {
            body.velocity = Vector3.ClampMagnitude(body.velocity + -1*transform.forward, walkSpeed);
            moving = true;
        }
        if (moving) {
            timer -= Time.deltaTime;
            if (timer < 0) {
                Debug.Log("bounce");
                body.velocity += Vector3.up*walkBounce;
                timer = bounceTime;
            }
        }
        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(camTrans.position, camTrans.forward, out hit, 500)) {
                if (hit.transform.CompareTag("audio")) {
                    hit.transform.gameObject.GetComponent<AudioSource>().Play();
                }
            }
        }
		
	}
}
