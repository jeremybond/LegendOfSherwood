using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour 
{
	
	public float fSpeed = 3;

	void Update () 
	{
		float move = fSpeed*Time.deltaTime;
		//transform.Translate(Vector3.forward * move);
		//transform.position = Vector3.Lerp(transform.position, touchposition, Time.deltaTime);
		
		if (transform.position.y > 10)
			Destroy(this.gameObject);
	}
	
}