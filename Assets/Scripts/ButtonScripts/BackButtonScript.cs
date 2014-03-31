using UnityEngine;
using System.Collections;

public class BackButtonScript : MonoBehaviour {

	public Texture2D button1;
	public Texture2D button2;
	public GameObject guiObject;
	//private GameObject guiObject;
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
				if(fromCredits)
				{
					guiObject.GetComponent<GuiMovementScript>().StartCoroutine("BackToMenuFromCredits");
				}else
				{
					guiObject.GetComponent<GuiMovementScript>().StartCoroutine("BackToMenuFromLevels");
				}
			}
			
			else if(!guiTexture.HitTest(touch.position))
			{
				guiTexture.texture = button1;
			}
		}

	}
}
