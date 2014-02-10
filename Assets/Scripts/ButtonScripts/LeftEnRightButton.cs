using UnityEngine;
using System.Collections;

public class LeftEnRightButton : MonoBehaviour {
	
	public Texture2D button1;
	public Texture2D button2;
	public bool trueIsLeftFalseIsRight;
	
	void Start()
	{
		guiTexture.texture = button1;
	}
	void Update()
	{
		foreach (Touch touch in Input.touches)
		{
			if (guiTexture.HitTest(touch.position) && touch.phase != TouchPhase.Ended)
			{
				guiTexture.texture = button2;
				if(trueIsLeftFalseIsRight)
				{
					MovePlayerObject.leftMovement = true;
				}else{
					MovePlayerObject.rightMovement = true;
				}
				if(!guiTexture.HitTest(touch.position))
				{
					guiTexture.texture = button1;
				}
			}
			else if (guiTexture.HitTest(touch.position) && touch.phase == TouchPhase.Ended)
			{
				guiTexture.texture = button1;
			}else if(!guiTexture.HitTest(touch.position))
			{
				guiTexture.texture = button1;
			}
		}
	}
}
