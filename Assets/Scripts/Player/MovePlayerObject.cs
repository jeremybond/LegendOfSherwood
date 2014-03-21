using UnityEngine;
using System.Collections;

public class MovePlayerObject : MonoBehaviour 
{
	public static bool rightMovement = false;
	public static bool leftMovement = false;
	//public static bool jump = false;
	public static bool standingOnGround = true;
	public static bool shootingBool = false;
	private GameObject newArrow;
	private Vector3 firstArrowPos;
	private Vector3 touchPos;
	private Vector3 oldArrowRotation;
	private bool shoooooting = true;
	public static bool rightTouch = false;
	public static float playerYpos;
	public static bool WonOrPause = false;
	//public GameObject endPoint;


	private Vector3 midScreen = new Vector3(Screen.width/2, Screen.height / 2, 10); 

	void Update()
	{
		playerYpos = transform.position.y;
		if(!WonOrPause)
		{
			if(rightMovement)
			{
				transform.position += new Vector3(0.08f,0,0);
			}else if(leftMovement)
			{
				transform.position += new Vector3(-0.08f,0,0);
			}
			Deactivate();
			
			
			//moet nog aangepast worden!!!!!!
			if(shootingBool)
			{
				shootingBool = false;
				StartCoroutine(Shoot());
			}
		}


	}

	public void Jump(){
		if(!WonOrPause)
		{
			if(standingOnGround)
			{
				rigidbody.AddForce(0, 150, 0);
				standingOnGround = false;
			}
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
						newArrow = Instantiate(Resources.Load("TileFolder/PreFabs/Arrow"),new Vector3(transform.position.x + 0.8f,transform.position.y,transform.position.z), Quaternion.identity) as GameObject;
						newArrow.collider.enabled = false;
						shoooooting = false;
					}else if(touch.phase == TouchPhase.Ended)
					{
						newArrow.GetComponent<shooting>().moveArrow();
						shooting.hasBinShot = true;
						shoooooting = true;
						newArrow.collider.enabled = true;
					}
					ArrowRotationUpdate();
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
			newArrow.transform.eulerAngles = new Vector3(0, 0, (-angle + 90));
			newArrow.transform.position = transform.position;
		}
	}

	void Deactivate()
	{
		rightMovement = false;
		leftMovement = false;
	}
	void OnTriggerEnter(Collider col)
	{
		if(col.collider.tag == "Ground")
		{
			StartCoroutine(ReadyForJump());
		}
		if(col.collider.tag == "Arrow")
		{
			StartCoroutine(ReadyForJump());
		}
	}
	void OnCollisionEnter(Collision col)
	{

		if (col.collider.name == "End")
		{
			GuiMovementScript.inGameScreen = true;
			GuiMovementScript.won = true;
			if(StaticVariables.levelsUnlocked <= StaticVariables.currentLevelInt)
			{
				StaticVariables.levelsUnlocked += 1;
			}
		}else if(col.collider.name == "KillingObjects")
		{
			//Destroy(col.collider.gameObject);
			Application.LoadLevel(2);
		}else if(col.collider.name == "Gold")
		{
			Destroy(col.collider.gameObject);
		}else if(col.collider.name == "NextPartTutorial")
		{
			Application.LoadLevel("TutorialPart2");
		}else if(col.collider.name == "EndTutorial")
		{
			Application.LoadLevel("Start");
		}
	}
	IEnumerator ReadyForJump(){
		yield return new WaitForSeconds(0.5f);
		if(!standingOnGround)
		{
			standingOnGround = true;
		}

	}
}

