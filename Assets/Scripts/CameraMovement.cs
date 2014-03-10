using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
	public GameObject playerObject;
	private Vector3 playerPos;
	private float PosXStraightener;

	void Start()
	{
		PosXStraightener = 14f/29f;
	}

	void Update () 
	{

		if(Input.touchCount >= 0)
		{
			updatePlayerPos();
			float temperrarilyVariableX = playerPos.x - 1f;
			float temperrarilyVariableY = playerPos.y - 1f;
			transform.position = new Vector3((temperrarilyVariableX * PosXStraightener),temperrarilyVariableY / 2.2f,transform.position.z);
		}
	}
	void updatePlayerPos()
	{
		playerPos = playerObject.transform.position;
	}
}
