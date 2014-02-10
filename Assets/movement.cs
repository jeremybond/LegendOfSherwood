using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	public Texture2D button1;
	public Texture2D button2;

	
	
	

	// Use this for initialization
	void Start () 
	{
		guiTexture.texture = button1;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		foreach (Touch touch in Input.touches)
		{
			if (guiTexture.HitTest(touch.position) && touch.phase != TouchPhase.Ended)
			{
				guiTexture.texture = button2;
				
				transform.Translate(Vector3.right * 30 * Time.smoothDeltaTime);
				
				
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
	