using UnityEngine;
using System.Collections;
 
public class MovingPlatformLeftRight : MonoBehaviour {
 public float speed = 1;
 public float distance;
 Vector3 startingpos;

 void Start(){
   startingpos = transform.position;
 }
 void Update() {
  //move the cube from (0, 0, 0) to (5, 0, 0) and back to (0, 0, 0) and so on.
  //use the same Mathf.PingPong function to the other axes if you need to move in those axes as well
  transform.position = new Vector3(PingPong(Time.time*speed, startingpos.x, startingpos.x+distance), transform.position.y, transform.position.z);
 }
 
 //function to change the default starting value of (0, 0, 0) to any value
 float PingPong(float t, float minLength, float maxLength) {
  return Mathf.PingPong(t, maxLength-minLength) + minLength;
 }
}