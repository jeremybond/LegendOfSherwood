using UnityEngine;
using System.Collections;

public class MovePlayerObject : MonoBehaviour 
{
	public static bool rightMovement = false;
	public static bool leftMovement = false;
	public static bool jump = false;
	public static bool standingOnGround = true;
	public static bool shootingBool = false;
	private Vector3 midScreen = new Vector3(Screen.width/2, Screen.height / 8 * 5, 10); 

	void Update()
	{
		if(rightMovement)
		{
			transform.position += new Vector3(0.08f,0,0);
		}else if(leftMovement)
		{
			transform.position += new Vector3(-0.08f,0,0);
		}

		if(jump && standingOnGround)
		{
			rigidbody.AddForce(0, 400, 0);
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
		foreach (Touch touch in Input.touches)
		{
			if (Input.touchCount==1)
			{
				//Vector3 position = new Vector3(transform.position.x,(transform.position.y + (transform.localScale.y/2)),0);
				GameObject newArrow = Instantiate(Resources.Load("TileFolder/PreFabs/Arrow"),transform.position, Quaternion.identity) as GameObject;
				//Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, 10);
				Vector3 touchPosition=new Vector3();

				if (touch.phase == TouchPhase.Ended)
				{
					touchPosition = new Vector3(touch.position.x, touch.position.y, 10);
					float angleX = touchPosition.x - midScreen.x;
					float angleY = touchPosition.y - midScreen.y;
					float angle = Mathf.Atan2(angleX, angleY)* Mathf.Rad2Deg;
					if(angle <= 0)
					{
						angle += 360;
					}
					newArrow.transform.Rotate(0, 0, -angle + 90);
				}
			}
		}



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
		}else if(col.collider.name == "KillingObjects")
		{
			Destroy(col.collider.gameObject);
			Application.LoadLevel(2);
		}	
	}
}

