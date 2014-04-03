using UnityEngine;
using System.Collections;

public class Bridge : MonoBehaviour 
{
	public GameObject bridge;
	void OnCollisionEnter(Collision col)
	{


		if(col.collider.tag == "Player")
		{
			shooting.bridgeBuild = true;
		}

		if(col.collider.tag == "Arrow")
		{
			Destroy(col.gameObject);
			if(shooting.bridgeBuild)
			{
				Debug.Log(shooting.bridgeBuild);
				Vector3 temp = new Vector3(0,0,bridge.transform.position.z - transform.position.z);
				bridge.transform.position -= temp;
			}
		}
	}
}