using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public GameObject playerObject;
	private Vector3 playerPos;
	private float PosXStraightener;
<<<<<<< HEAD

	void Start(){
		PosXStraightener = 14f/29f;
	}
=======
>>>>>>> origin/Jeremaya

	void Start() {
		PosXStraightener = 14f/29f;
	}
	void Update () {
<<<<<<< HEAD
		if(MovePlayerObject.leftMovement || MovePlayerObject.rightMovement)
		{
			updatePlayerPos();
			float temperrarilyVariableX = playerPos.x - 1f;
			float temperrarilyVariableY = playerPos.y - 1f;
			transform.position = new Vector3((temperrarilyVariableX * PosXStraightener),temperrarilyVariableY / 2.2f,transform.position.z);
		}
=======

		updatePlayerPos();
		float temperrarilyVariableX = playerPos.x - 1f;
		float temperrarilyVariableY = playerPos.y - 1f;
		transform.position = new Vector3((temperrarilyVariableX * PosXStraightener),temperrarilyVariableY / 2.2f,transform.position.z);
>>>>>>> origin/Jeremaya
	}
	void updatePlayerPos()
	{
		playerPos = playerObject.transform.position;
	}
}
