using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour 
{
	private Vector3 midScreen = new Vector3(Screen.width/2, Screen.height / 4 * 2.5f, 10);
	//private Vector3 touchPosition;
	public  bool arrowMove = false;
	public  float fSpeed = 0.5f;

	void Update () 
	{
		//transform.Translate(Vector3.forward * move);
		foreach (Touch touch in Input.touches)
		{

			if(!arrowMove)
			{
				//touchPosition = new Vector3(touch.position.x, touch.position.y, 10);
				arrowMove = true;
				/*float angleX = touchPosition.x - midScreen.x;
				float angleY = touchPosition.y - midScreen.y;
				float angle = Mathf.Atan2(angleX, angleY)* Mathf.Rad2Deg;
				if(angle <= 0)
				{
					angle += 360;
				}
				transform.Rotate(0, 0, -angle + 90);*/
			}
		}
		if(arrowMove)
		{
			transform.Translate(Vector3.right * fSpeed);
		}
	}

	public void startMoveArrow(){
		Debug.Log("startCorou...");
		StartCoroutine(moveArrow());
	}
	public IEnumerator moveArrow()
	{
		
		Debug.Log("movement");
		float move = fSpeed*Time.deltaTime;
		if(arrowMove)
		{
			transform.Translate(Vector3.right * move);
		}
		yield return new WaitForSeconds(0.05f);
	}

	
}