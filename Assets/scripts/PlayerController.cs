using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	public float jump;
	public string level;
	
	void Awake(){
		//runs first
	}

// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	void Update(){

		//This is code run every frame
	}

	void FixedUpdate(){
		
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce(movement * speed);
		if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()){

		
			rb.AddForce(new Vector3(0,jump,0 ) , ForceMode.Impulse);

		}
	}


	bool IsGrounded(){
		return Physics.Raycast (transform.position, - Vector3.up, GetComponent<Collider>().bounds.extents.y+ 0.15f);
	}


	void OnTriggerEnter(Collider collisionObject){
		if (collisionObject.gameObject.CompareTag("Death")){
			Application.LoadLevel(level);
			}

		if (collisionObject.gameObject.CompareTag("Victory")){
			Application.LoadLevel("Scene2");
			}

	}
}
