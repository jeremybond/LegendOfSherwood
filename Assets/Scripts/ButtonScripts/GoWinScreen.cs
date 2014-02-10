using UnityEngine;
using System.Collections;

public class GoWinScreen : MonoBehaviour {
	
	public Texture2D button1;
	public Texture2D button2;
	public GameObject guiObject;
	
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
				GuiMovementScript.inGameScreen = true;
				GuiMovementScript.won = true;
				if(StaticVariables.levelsUnlocked <= StaticVariables.currentLevelInt)
				{
					StaticVariables.levelsUnlocked += 1;
				}
			}else if(!guiTexture.HitTest(touch.position))
			{
				guiTexture.texture = button1;
			}
		}
	}
}
