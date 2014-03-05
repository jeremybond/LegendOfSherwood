using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour 
{
	
	public float fSpeed = 1;

	void Update () 
	{
		
		float move = fSpeed*Time.deltaTime;
		transform.Translate(Vector3.up * move);
		
		if (transform.position.y > 10)
			Destroy(this.gameObject);
	}
	
}