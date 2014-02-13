using UnityEngine;
using System.Collections;

public class LeftEnRightButton : MonoBehaviour 
{
	public bool trueIsLeftFalseIsRight;

	void Update()
	{
		foreach (Touch touch in Input.touches)
		{
			if(touch.position.y < (Screen.height/4))
			{
				if (touch.position.x < Screen.width/2 - 20 )
				{
					MovePlayerObject.leftMovement = true;
				}
				else if (touch.position.x > Screen.width/2 - 20) 
				{
					MovePlayerObject.rightMovement = true;
				}
			}
		}
	}
}
