using UnityEngine;
using System.Collections;

public class JumpButtonScript : MonoBehaviour {

	public Texture2D button1;
	public Texture2D button2;
	
	void Start()
	{
		guiTexture.texture = button1;
	}
	void OnDrawGizmosSelected() {
		//Vector3 p = camera.ScreenToWorldPoint(new Vector3(100, 100, camera.nearClipPlane));
		//Gizmos.color = Color.yellow;
		//Gizmos.DrawSphere(p, 0.1F);
	}
	void Update()
	{
		foreach (Touch touch in Input.touches)
		{
			if(touch.position.y <= ((Screen.width / 4)*3))
			{
				if(MovePlayerObject.standingOnGround)
				{
					//MovePlayerObject.jump = true;
				}
			}
			if (guiTexture.HitTest(touch.position) && touch.phase != TouchPhase.Ended)
			{
				guiTexture.texture = button2;
				if(MovePlayerObject.standingOnGround)
				{
					//MovePlayerObject.jump = true;
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

//links = 6.2
//rechts = 715.2
//onder = 8.0
//boven = 473.4


