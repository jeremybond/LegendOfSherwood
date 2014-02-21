using UnityEngine;
using System.Collections;

public class MovePlayerObject : MonoBehaviour {
	public static bool rightMovement = false;
	public static bool leftMovement = false;
	public static bool jump = false;
	public static bool standingOnGround = true;
	public static bool shootingBool = false;

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
		//moet nog aangepast worden!!!!!!
		if(shootingBool)
		{
			shootingBool = false;
			StartCoroutine(Shoot());
		}
	
	}
	public IEnumerator  Shoot()
	{
		if (Input.touchCount==1)
		{
			Vector3 position = new Vector3(transform.position.x,(transform.position.y + (transform.localScale.y/2)),0);
			GameObject newArrow = Instantiate(Resources.Load("PreFabs/Arrow"),transform.position, Quaternion.identity) as GameObject;
		}
		Vector3 touchPosition=new Vector3();
		yield return null;
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

