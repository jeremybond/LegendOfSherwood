using UnityEngine;
using System.Collections;

public class LeftEnRightButton : MonoBehaviour 
{
	public static bool jumpCapability = true;

	public float fSpeed = 3;


	void Update()
	{

		//float move = fSpeed*Time.deltaTime;

		foreach (Touch touch in Input.touches)
		{
			if(touch.position.y < (Screen.height/4))
			{
				if (touch.position.x < (Screen.width/2) - (Screen.width / 6))
				{
					MovePlayerObject.leftMovement = true;
				}
				else if (touch.position.x > (Screen.width/2) + (Screen.width / 6)) 
				{
					MovePlayerObject.rightMovement = true;
				}else
				{
					MovePlayerObject.jump = true;
				}
			}
			else
			{
				MovePlayerObject.shootingBool = true;
			}


		}
	
	}
}