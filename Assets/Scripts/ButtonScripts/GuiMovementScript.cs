using UnityEngine;
using System.Collections;

public class GuiMovementScript : MonoBehaviour {
	public static float relativeForce = 0.05f;
	public static bool levels = false;
	public static bool backToMenuFromLevels = false;
	public static bool backToMenuFromCredits = false;
	public static bool credits = false;
	public static bool lost = false;
	public static bool won = false;
	public static bool onStartScreen = false;
	public static bool inGameScreen = false;

	public void Update(){
		if(onStartScreen)
		{
			if(backToMenuFromLevels)
			{
				if(transform.position.x < 0f)
				{
					transform.position += new Vector3(relativeForce, 0, 0);
				}else{
					backToMenuFromLevels = false;
					onStartScreen = false;
				}
			}else if(backToMenuFromCredits)
			{
				if(transform.position.x > 0f)
				{
					transform.position -= new Vector3(relativeForce, 0, 0);
				}
				else{
					backToMenuFromCredits = false;
					onStartScreen = false;
				}
			}else if(levels)
			{
				if(transform.position.x > -1f)
				{
					transform.position -= new Vector3(relativeForce, 0, 0);
				}else{
					levels = false;
					onStartScreen = false;
				}
			}else if(credits)
			{
				if(transform.position.x < 1f)
				{
					transform.position += new Vector3(relativeForce, 0, 0);
				}else{
					credits = false;
					onStartScreen = false;
				}
			}

		}
		if(inGameScreen)
		{
			if(lost)
			{
				if(transform.position.y < 1f)
				{
					transform.position += new Vector3(0, relativeForce, 0);
				}else{
					lost = false;
					inGameScreen = false;
				}
			}else if (won)
			{
				if(transform.position.y > -1f)
				{
					transform.position -= new Vector3(0, relativeForce, 0);
				}else{
					won = false;
					inGameScreen = false;
				}
			}
		}
	}
}
