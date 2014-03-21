using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
	public GameObject playerObject;
	private Vector3 playerPos;
	private float PosXStraightener;

	void Start()
	{
		PosXStraightener = 14f/25.5f;
	}

	void Update () 
	{

		if(Input.touchCount >= 0)
		{
			updatePlayerPos();
			float temperrarilyVariableX = playerPos.x - 1f;
			float temperrarilyVariableY = playerPos.y - 1f;
			transform.position = new Vector3((temperrarilyVariableX * PosXStraightener - 1),temperrarilyVariableY / 1.9f,transform.position.z);
		}
	}
	void updatePlayerPos()
	{
		playerPos = playerObject.transform.position;
	}
}
