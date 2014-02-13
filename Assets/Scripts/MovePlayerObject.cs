using UnityEngine;
using System.Collections;

public class MovePlayerObject : MonoBehaviour {
	public static bool rightMovement = false;
	public static bool leftMovement = false;
	public static bool jump = false;
	public static bool standingOnGround = true;

	void Update()
	{
		if(rightMovement){
			transform.position += new Vector3(0.5f,0,0);
		}
		if(leftMovement){
			transform.position += new Vector3(-0.5f,0,0);
		}
		if(jump){
<<<<<<< HEAD
			rigidbody.AddForce(0, 150, 0);
=======
			rigidbody.AddForce(Vector3.up * 2500 * Time.deltaTime);
>>>>>>> origin/Jeremaya
		}
		Deactivate();
	}
	void Deactivate(){
		rightMovement = false;
		leftMovement = false;
		jump = false;
	}
	void OnCollisionEnter(Collision col){
		if(col.collider.name == "Ground")
		{
			standingOnGround = true;
		}
	}
}

