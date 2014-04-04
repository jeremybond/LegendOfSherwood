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
	public GameObject GUIObjectInGame;
	private Vector3 firstArrowPos;
	private Vector3 touchPos;
	private Vector3 oldArrowRotation;
	private bool shoooooting = true;
	public static bool rightTouch = false;
	public static float playerYpos;
	public static bool WonOrPause = false;
	private bool hitWallsNextToYou = false;
	private Vector3 midScreen = new Vector3(Screen.width/2, Screen.height / 2, 10); 


	//RayCastShit
	public float raycastHeight;
	public static bool raycastJumpBool;

	//Audio
	public AudioClip endSound;
	public AudioClip coinSound;
	
	//public AudioClip themeSong;
	
	public AudioClip walkingSound;
	public AudioClip jumpSound;
	public AudioClip arrowHitSound;

	void Update()
	{
		playerYpos = ((transform.position.y - (transform.localScale.y / 2)));//+0.5f);
		//Debug.Log(playerYpos);
		//here the raycast for the jump get made, directed and shot
		RaycastHit hit;
		float changedLocalScaleX = ((transform.localScale.x / 7) * 3);
		float changedLocalScaleY = ((transform.localScale.y / 7) * 3);
		//Setting the position of the left raycast
		Vector3 lowerPlayerPos1 = transform.position;
		lowerPlayerPos1.x -= changedLocalScaleX;
		lowerPlayerPos1.y -= changedLocalScaleY;
		//Setting the position of the right raycast
		Vector3 lowerPlayerPos2 = transform.position;
		lowerPlayerPos2.x += changedLocalScaleX;
		lowerPlayerPos2.y = lowerPlayerPos1.y;
		//Setting the position of the middle raycast
		Vector3 lowerPlayerPos3 = transform.position;
		lowerPlayerPos3.y = lowerPlayerPos1.y;
		//giving the raycast the position the direction en the lenght
		Ray landingRay1 = new Ray(lowerPlayerPos1, Vector3.down * raycastHeight);
		Ray landingRay2 = new Ray(lowerPlayerPos2, Vector3.down * raycastHeight);
		Ray landingRay3 = new Ray(lowerPlayerPos3, Vector3.down * raycastHeight);
		
		//Debug.DrawRay(lowerPlayerPos1, Vector3.down * raycastHeight);
		//Debug.DrawRay(lowerPlayerPos2, Vector3.down * raycastHeight);
		//Debug.DrawRay(lowerPlayerPos3, Vector3.down * raycastHeight);
		if(!raycastJumpBool)
		{
		
			if(Physics.Raycast(landingRay1, out hit, raycastHeight))
			{
				//Debug.DrawRay(lowerPlayerPos1, Vector3.down * raycastHeight);
				//Debug.DrawRay(lowerPlayerPos2, Vector3.down * raycastHeight);
				//Debug.DrawRay(lowerPlayerPos3, Vector3.down * raycastHeight);
				//Debug.Log(hit.collider.tag);
				if(hit.collider.tag == "Ground")
				{
					StartCoroutine(ReadyForJump());
					//Debug.Log(raycastJumpBool + "11");
					LeftEnRightButton.jumped = false;
				}else if(hit.collider.tag == "Arrow")
				{
					//Debug.Log(raycastJumpBool + "12");
					hit.collider.isTrigger = false;
					LeftEnRightButton.jumped = false;
					StartCoroutine(ReadyForJump());
				}
			}
			if(Physics.Raycast(landingRay2, out hit, raycastHeight))
			{
				//Debug.Log(hit.collider.tag);
				if(hit.collider.tag == "Ground")
				{
					LeftEnRightButton.jumped = false;
					StartCoroutine(ReadyForJump());
				}else if(hit.collider.tag == "Arrow")
				{
					hit.collider.isTrigger = false;
					LeftEnRightButton.jumped = false;
					StartCoroutine(ReadyForJump());
				}
				//Debug.Log(raycastJumpBool + "2");
			}
			if(Physics.Raycast(landingRay3, out hit, raycastHeight))
			{
				//Debug.Log(hit.collider.tag);
				LeftEnRightButton.jumped = false;
				if(hit.collider.tag == "Ground")
				{
					StartCoroutine(ReadyForJump());
				}else if(hit.collider.tag == "Arrow")
				{
					LeftEnRightButton.jumped = false;
					hit.collider.isTrigger = false;
					StartCoroutine(ReadyForJump());
				}
				//Debug.Log(raycastJumpBool + "3");
			}
		}


		if(!WonOrPause)
		{
			if(rightMovement)
			{    
				ChangeToRightSide();
				audio.PlayOneShot(walkingSound);
				transform.position += new Vector3(0.08f,0,0);
			}else if(leftMovement)
			{
				ChangeToLeftSide();
				audio.PlayOneShot(walkingSound);
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
	public void ChangeToLeftSide(){
		if(transform.localScale.x > 0)
		{
			transform.localScale -= new Vector3(1.25f,0,0);
		}
	}
	public void ChangeToRightSide(){
		if(transform.localScale.x < 0)
		{
			transform.localScale += new Vector3(1.25f,0,0);
		}
	}

	public IEnumerator Jump(){
		if(!WonOrPause)
		{
			if(raycastJumpBool)
			{    
				audio.PlayOneShot(jumpSound);
				//Debug.Log(Time.deltaTime);
				raycastJumpBool = false;
				//rigidbody.constraints = RigidbodyConstraints.FreezeAll;
				rigidbody.AddRelativeForce(0, 150, 0);
				//rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
			}
		}
		yield return null;
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
						newArrow = Instantiate(Resources.Load("TileFolder/PreFabs/Arrow"),new Vector3(transform.position.x + 0.8f,transform.position.y,transform.position.z + 0.2f), Quaternion.identity) as GameObject;
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

		if(col.collider.tag == "Arrow")
		{
			//Debug.Log(newArrow.transform.collider.isTrigger);
			//StartCoroutine(ReadyForJump());
			col.collider.isTrigger = false;
			rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
			StartCoroutine(SetConstraintsToAllButXAndYPos());
		}
		if(col.collider.tag == "CoinBag")
		{   
			audio.PlayOneShot(coinSound);
			col.GetComponent<Coins>().CollectMoney();
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.collider.tag == "Ground" )
		{
			//StartCoroutine(ReadyForJump());
			rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
			StartCoroutine(SetConstraintsToAllButXAndYPos());
		}
		if(col.collider.tag == "Arrow" )
		{
			//StartCoroutine(ReadyForJump());
			//col.collider.isTrigger = false;
			rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
			StartCoroutine(SetConstraintsToAllButXAndYPos());
		}
		if (col.collider.name == "End")
		{   
			audio.PlayOneShot(endSound);
			GUIObjectInGame.GetComponent<GuiMovementScript>().StartCoroutine("GoToWinScreen");
			if(StaticVariables.levelsUnlocked <= StaticVariables.currentLevelInt)
			{
				StaticVariables.levelsUnlocked += 1;
			}
		}else if(col.collider.name == "KillingObjects")
		{
			Application.LoadLevel(Application.loadedLevel);
			AllGUITexts.amountOfGoldBags = 0;
		}else if(col.collider.name == "NextPartTutorial")
		{
			Application.LoadLevel("TutorialPart2");
		}else if(col.collider.name == "EndTutorial")
		{
			Application.LoadLevel("Start");
		}
	}
	IEnumerator SetConstraintsToAllButXAndYPos(){
		yield return new WaitForSeconds(0.025f);
		rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
	}
	IEnumerator ReadyForJump(){
		if(!raycastJumpBool)
		{
			raycastJumpBool = true;
		}
		yield return new WaitForSeconds(0.1f);
	}
}

