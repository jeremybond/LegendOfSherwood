using UnityEngine;
using System.Collections;

public class BackButtonScript : MonoBehaviour {

	public Texture2D button1;
	public Texture2D button2;
	public GameObject guiObject;
	public bool fromCredits;

	void Start () 
	{
		guiTexture.texture = button1;	
	}
	void Update () 
	{
		foreach (Touch touch in Input.touches)
		{
			if (guiTexture.HitTest(touch.position) && touch.phase != TouchPhase.Ended)
			{
				guiTexture.texture = button2;
			}
			else if (guiTexture.HitTest(touch.position) && touch.phase == TouchPhase.Ended)
			{
				guiTexture.texture = button1;
				GuiMovementScript.onStartScreen = true;
				if(fromCredits)
				{
					GuiMovementScript.backToMenuFromCredits = true;
				}else{
					GuiMovementScript.backToMenuFromLevels = true;
				}
			}else if(!guiTexture.HitTest(touch.position))
			{
				guiTexture.texture = button1;
			}
		}
	}
}
