using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour 
{
	void OnTriggerEnter(Collider col)
	{
		if (col.collider.name == "Player")
		{
			Destroy(gameObject);
		}
	}
}
