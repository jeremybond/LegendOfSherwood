using UnityEngine;
using System.Collections;

public class MovePlayerObject : MonoBehaviour 
{
	public static bool rightMovement = false;
	public static bool leftMovement = false;
	public static bool jump = false;
	public static bool standingOnGround = true;
	public static bool shootingBool = false;
	private GameObject newArrow;
	private Vector3 touchPos;
	private Vector3 oldArrowRotation;
	private bool shoooooting = true;
	private bool rightTouch = false;

	private Vector3 midScreen = new Vector3(Screen.width/2, Screen.height / 2, 10); 

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
			if(touch.position.y > (Screen.height/4))
			{
				rightTouch = true;

				if (Input.touchCount==1)
				{
					touchPos = new Vector3(touch.position.x, touch.position.y, transform.position.z);
					if(shoooooting)
					{
						newArrow = Instantiate(Resources.Load("TileFolder/PreFabs/Arrow"),transform.position, Quaternion.identity) as GameObject;
						//newArrow.transform.Rotate(0, 0, newArrow.transform.rotation.z);
						shoooooting = false;
					}else if(touch.phase == TouchPhase.Ended)
					{
						newArrow.GetComponent<shooting>().moveArrow();
						shoooooting = true;
					}//else if(touch.phase == TouchPhase.Moved)
					//{
						ArrowRotationUpdate();
					//}

				}else{
					//oldArrowRotation.z = 0;
				}
			}else{
				rightTouch = false;
			}
			
			yield return null;
		}

	}
	void ArrowRotationUpdate(){
		if(rightTouch)
		{
			float angleX = touchPos.x - midScreen.x;
			float angleY = touchPos.y - midScreen.y;
			float angle = Mathf.Atan2(angleX, angleY)* Mathf.Rad2Deg;

			//if(angle <= 0)
			//{
			//	angle += 360;
			//}
			Debug.Log(angle);

			Vector3 newArrowRotation = new Vector3(0, 0, angle);
			//Vector3 nullRotationVector = new Vector3(0, 0, angle + 90);
			newArrow.transform.Rotate(0, 0, (oldArrowRotation.z - newArrowRotation.z));
			oldArrowRotation = newArrowRotation;
			//newArrow.transform.Rotate(newArrowRotation);
			newArrow.transform.position = transform.position;
		}
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
			Application.LoadLevel(StaticVariables.lastLevelInt+1);
		}else if(col.collider.name == "KillingObjects")
		{
			//Destroy(col.collider.gameObject);
			Application.LoadLevel(2);
		}else if(col.collider.name == "Gold")
		{
			Destroy(col.collider.gameObject);
			Debug.Log("jes gold!!");
		}
	}
}

