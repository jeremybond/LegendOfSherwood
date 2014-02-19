using UnityEngine;
using System.Collections;

public class MovePlayerObject : MonoBehaviour {
	public static bool rightMovement = false;
	public static bool leftMovement = false;
	public static bool standingOnGround = true;
	public static bool jump = false;

	void Update()
	{
		if(rightMovement){
			transform.position += new Vector3(0.2f,0,0);
		}else if(leftMovement){
			transform.position += new Vector3(-0.2f,0,0);
		}
		if(jump ){
			rigidbody.AddRelativeForce(Vector3.up * 7000 * (Time.deltaTime ));
			LeftEnRightButton.jumpCapability = false;
		}
		Deactivate();
	}
	void Deactivate(){
		rightMovement = false;
		leftMovement = false;
	}
}

