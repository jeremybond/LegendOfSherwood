using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.collider.name == "Player")
		{
			Destroy(gameObject);
		}
	}
}
