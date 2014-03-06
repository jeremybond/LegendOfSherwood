using UnityEngine;
using System.Collections;

public class LeftEnRightButton : MonoBehaviour 
{
	public static bool jumpCapability = true;

	public float fSpeed = 3;


	void Update()
	{

		float move = fSpeed*Time.deltaTime;

		foreach (Touch touch in Input.touches)
		{
			if(touch.position.y < (Screen.height/4))
			{
				if (touch.position.x < (Screen.width/2) - (Screen.width / 8))
				{
					MovePlayerObject.leftMovement = true;
				}
				else if (touch.position.x > (Screen.width/2) + (Screen.width / 8)) 
				{
					MovePlayerObject.rightMovement = true;
				}else
				{
					MovePlayerObject.jump = true;
				}
			}
			else
			{
				if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
				{
					Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, 10);          
					transform.position = Vector3.Lerp(transform.position, touchPosition, Time.deltaTime);
				}

				MovePlayerObject.shootingBool = true;
			}


		}
	
	}
}