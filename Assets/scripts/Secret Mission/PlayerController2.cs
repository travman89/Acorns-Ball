using UnityEngine;
using System.Collections;

public class PlayerController2 : MonoBehaviour {

    public GameObject camera;
    public AudioSource tyf;
	private Rigidbody rb;
	public float speed;
	public float jump;
	public string level;
	// Use this for initialization
	void Start () {
        Application.targetFrameRate = 60;
		rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate(){
		


		if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()){
			rb.AddForce(new Vector3(0,jump,0 ) , ForceMode.Impulse);

		}
        if(Input.GetKey(KeyCode.W)){
            Vector3 forceDirection = camera.GetComponent<Camera>().transform.forward;
            
            forceDirection.y = 0;
            rb.AddForce(forceDirection * speed);
        }
        if(Input.GetKey(KeyCode.S)){
            Vector3 forceDirection = camera.GetComponent<Camera>().transform.forward;
            forceDirection.y = 0;
            rb.AddForce(forceDirection*-1 * speed);
        }
        if(Input.GetKey(KeyCode.D)){
            Vector3 forceDirection = camera.GetComponent<Camera>().transform.right;
            rb.AddForce(forceDirection  * speed);
        }
        if(Input.GetKey(KeyCode.A)){
            Vector3 forceDirection = camera.GetComponent<Camera>().transform.right;
            rb.AddForce(forceDirection*-1 * speed);
        }
	}

	bool IsGrounded(){
        print(Physics.Raycast (transform.position, - Vector3.up, GetComponent<Collider>().bounds.extents.y+ 0.15f));
		return Physics.Raycast (transform.position, - Vector3.up, GetComponent<Collider>().bounds.extents.y+ 0.15f);
	}

	void OnTriggerEnter(Collider collisionObject){
		if (collisionObject.gameObject.CompareTag("Death")){
			Application.LoadLevel(level);
			}
        if(collisionObject.gameObject.CompareTag("Acorn")){
            print("acorn");
            tyf.Play();
        }

	}
}
