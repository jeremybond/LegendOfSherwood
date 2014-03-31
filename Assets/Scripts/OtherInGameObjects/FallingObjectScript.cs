using UnityEngine;
using System.Collections;

public class FallingObjectScript : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if(col.collider.tag == "Rope"){
		}else{
			if(gameObject.rigidbody.useGravity == false){
				gameObject.collider.isTrigger = false;
				gameObject.rigidbody.useGravity = true;
				Debug.Log(gameObject.rigidbody.useGravity);
				Debug.Log(gameObject.collider.isTrigger);
			}
		}
	}
}
