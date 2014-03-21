using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour 
{
	private Vector3 midScreen = new Vector3(Screen.width/2, Screen.height / 4 * 2.5f, 10);
	//private Vector3 touchPosition;
	public  bool arrowMove = false;
	public  float fSpeed = 2f;
	private bool firstTime = true;
	public static bool hasBinShot = false;

	void Update () 
	{
		if(!firstTime)
		{
			if(MovePlayerObject.playerYpos < transform.position.y + 0.1f)
			{
				collider.isTrigger = true;
			}else{
				collider.isTrigger = false;
			}
		}
		foreach (Touch touch in Input.touches)
		{
			if(!arrowMove)
			{
				arrowMove = true;
			}
		}
		if(arrowMove)
		{

			if(firstTime)
			{
				transform.Translate(Vector3.right * fSpeed);
				hasBinShot = false;
			}else{
				hasBinShot = true;
			}

		}
	}

	public IEnumerator moveArrow()
	{
		if(firstTime)
		{
			Debug.Log("movement");
			float move = fSpeed*Time.deltaTime;
			if(arrowMove)
			{
				transform.Translate(Vector3.right * move);
			}
		}
		yield return new WaitForSeconds(0.05f);
	}
	void OnTriggerEnter(Collider col){
		if(col.transform.tag == "Ground")
		{
			//Debug.Log(transform.rotation.z);
			firstTime = false;
			arrowMove = false;
			if(transform.rotation.z > 0.8f){
				this.transform.rotation = Quaternion.Euler(0, 0, 180);
			}else if(transform.rotation.z < 0.6f && transform.rotation.z > -0.6f){
				transform.rotation = Quaternion.Euler(0, 0, 0);
			}
		}
		if(col.transform.tag == "Player")
		{

		}
	}
	
}


