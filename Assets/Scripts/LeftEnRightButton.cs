using UnityEngine;
using System.Collections;

public class LeftEnRightButton : MonoBehaviour {
	public static bool jumpCapability = true;


	void Update()
	{
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
				}else if(jumpCapability){
					MovePlayerObject.jump = true;
				}
			}
		}
	}

}
