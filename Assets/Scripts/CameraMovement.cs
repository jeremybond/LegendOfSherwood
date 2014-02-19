using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public GameObject playerObject;
	private Vector3 playerPos;

	void Update () {
		if(MovePlayerObject.leftMovement || MovePlayerObject.rightMovement)
		{
			updatePlayerPos();
			float temperrarilyVariableX = playerPos.x - 1f;
			float temperrarilyVariableY = playerPos.y - 1f;
			transform.position = new Vector3(temperrarilyVariableX / 2,temperrarilyVariableY / 1.8,transform.position.z);
		}
	}
	void updatePlayerPos(){
		playerPos = playerObject.transform.position;
	}
}
