using UnityEngine;
using System.Collections;

public class ExitScipt : MonoBehaviour {
	public Texture2D button1;
	public Texture2D button2;

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
				Debug.Log(MovePlayerObject.WonOrPause);
				guiTexture.texture = button1;
				Application.Quit();
			}else if(!guiTexture.HitTest(touch.position))
			{
				guiTexture.texture = button1;
			}
		}
	}
}
