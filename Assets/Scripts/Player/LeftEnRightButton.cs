using UnityEngine;
using System.Collections;

public class LeftEnRightButton : MonoBehaviour 
{
	public static bool jumpCapability = true;
	public static bool jumped = false;
	public static bool shootingAni = false;

	public float fSpeed = 3;


	void Update()
	{

		//float move = fSpeed*Time.deltaTime;
		if(!MovePlayerObject.WonOrPause)
		{
			foreach (Touch touch in Input.touches)
			{
				if(touch.position.y < (Screen.height/4))
				{
					shootingAni = false;
					if (touch.position.x < (Screen.width/2) - (Screen.width / 6))
					{
						MovePlayerObject.leftMovement = true;
					}
					else if (touch.position.x > (Screen.width/2) + (Screen.width / 6)) 
					{
						MovePlayerObject.rightMovement = true;
					}else
					{
						jumped = true;
						GetComponent<MovePlayerObject>().StartCoroutine("Jump");
					}
				}
				else
				{
					shootingAni = true;
					MovePlayerObject.shootingBool = true;
				}
			}

		}
	}
}