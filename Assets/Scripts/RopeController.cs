using UnityEngine;
using System.Collections;

public class RopeController : MonoBehaviour 
{
	public Rigidbody log;

	public void ReleaseLog()
	{
		log.constraints &= ~RigidbodyConstraints.FreezePositionY;
		Destroy(gameObject);
	}
	
}
