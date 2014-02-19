using UnityEngine;
using System.Collections;

public class MovePlayerObject : MonoBehaviour {
	public static bool rightMovement = false;
	public static bool leftMovement = false;
	public static bool jump = false;
	public static bool standingOnGround = true;

	void Update()
	{
		if(rightMovement)
		{
			transform.position += new Vector3(0.06f,0,0);
		}else if(leftMovement)
		{
			transform.position += new Vector3(-0.06f,0,0);
		}
		if(jump && standingOnGround)
		{
			rigidbody.AddForce(0, 500, 0);
			//rigidbody.AddRelativeForce(Vector3.up * 8000 * (Time.deltaTime));
			jump = false;
			standingOnGround = false;
		}
		Deactivate();
	}
	void Deactivate()
	{
		rightMovement = false;
		leftMovement = false;
	}
	void OnCollisionEnter(Collision col)
	{
		if(col.collider.tag == "Ground")
		{
			standingOnGround = true;
		}

		if (col.collider.name == "End")
		{
			Application.LoadLevel(3);
		}

		if(col.collider.name == "KillingObjects")
		{
			Destroy(col.collider.gameObject);
			Application.LoadLevel(2);
		}	
	}
}

