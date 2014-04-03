using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour 
{
	private Vector3 midScreen = new Vector3(Screen.width/2, Screen.height / 4 * 2.5f, 10);
	//private Vector3 touchPosition;
	public  bool arrowMove = false;
	public  float fSpeed = 0.1f;
	private bool firstTime = true;
	public static bool hasBinShot = false;
	
	public static bool bridgeBuild = false;

	//Audio
	public AudioClip arrowHitSound;

	void Update () 
	{
		//Debug.Log(transform.position.y);
		if(!firstTime)
		{
			if(transform.position.y < (MovePlayerObject.playerYpos + 0.1f))
			{
				//Debug.Log(transform.position.y + "arrow");
				//collider.isTrigger = false;
				//Debug.Log(MovePlayerObject.playerYpos + "player");
			}else{
				//Debug.Log ("player");
				collider.isTrigger = true;
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
				transform.Translate((Vector3.right/ 2) / move);
			}
		}
		yield return new WaitForSeconds(0.05f);
	}
	void OnCollisionEnter(Collision col){
		if(col.transform.tag == "Ground")
		{
			audio.PlayOneShot(arrowHitSound);
			firstTime = false;
			arrowMove = false;
			if(transform.rotation.z > 0.8f){
				transform.rotation = Quaternion.Euler(0, 0, 180);
			}else if(transform.rotation.z < 0.6f && transform.rotation.z > -0.6f){
				transform.rotation = Quaternion.Euler(0, 0, 0);
			}
		}
		if(col.transform.tag == "Rope")
		{
			col.gameObject.GetComponent<RopeController>().ReleaseLog();
		}
	}

}


