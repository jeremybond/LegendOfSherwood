/*using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour 
{	
	float pos;
	void Update()
	{

		for (var i = 0; i < Input.touchCount; ++i) 
		{
			ray = Camera.mainCamera.ScreenPointToRay(Input.GetTouch(i).position); 
			
			switch(Input.GetTouch(0).phase)
			{
				case TouchPhase.Stationary:

					if (Physics.Raycast(ray,hit))
					{       
						
						bulletObject = Instantiate(bulletFab , bulletShootPoint.transform.position , bulletFab.transform.rotation);
						hitPoint = hit.point;
						
						float pos = Input.GetTouch(i).position;
						Bullet.transform.LookAt(hitPoint);
						Bullet.rigidbody.AddForce(bulletObject.transform.forward * 1000);

						hitPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
					}

				case TouchPhase.Began:
				break;
					
				case TouchPhase.Moved:
				break;
					
				case TouchPhase.Ended:
				break;
			
			}  
		}
	}
}*/