using UnityEngine;
using System.Collections;

public class GuiMovementScript : MonoBehaviour {
	public static float relativeForce = 0.05f;

	void Start(){
		MovePlayerObject.WonOrPause = false;
	}
	//////////////////////////////////////////////////IEnumerators for out of the game
	public IEnumerator BackToMenuFromLevels(){///////////To menu from level select
		if(transform.position.x < 0f){
			transform.position += new Vector3(relativeForce, 0, 0);
			yield return new WaitForSeconds(0.02f);
			StartCoroutine(BackToMenuFromLevels());
		}
		yield return new WaitForSeconds(0.1f);
	}
	public IEnumerator BackToMenuFromCredits(){///////////To menu from credits
		if(transform.position.x > 0f){
			transform.position -= new Vector3(relativeForce, 0, 0);
			yield return new WaitForSeconds(0.02f);
			StartCoroutine(BackToMenuFromCredits());
		}
		yield return new WaitForSeconds(0.1f);
	}
	public IEnumerator ToLevelsFromMenu(){///////////To levels select from menu
		if(transform.position.x > -1f){
			transform.position -= new Vector3(relativeForce, 0, 0);
			yield return new WaitForSeconds(0.02f);
			StartCoroutine(ToLevelsFromMenu());
		}
		yield return new WaitForSeconds(0.1f);
	}
	public IEnumerator GoToCreditsScreen(){///////////To credits from menu
		if(transform.position.x < 1f){
			transform.position += new Vector3(relativeForce, 0, 0);
			yield return new WaitForSeconds(0.02f);
			StartCoroutine(GoToCreditsScreen());
		}
		yield return new WaitForSeconds(0.1f);
	}

	//////////////////////////////////////////////////IEnumerators for in the game
	public IEnumerator FromGameToPause(){/////////////pushing the pause button
		MovePlayerObject.WonOrPause = true;
		if(transform.position.x < 1f){
			transform.position += new Vector3(relativeForce, 0, 0);
			yield return new WaitForSeconds(0.02f);
			StartCoroutine(FromGameToPause());
		}
		yield return new WaitForSeconds(0.1f);
	}

	public IEnumerator FromPauseToGame(){////////////Pushing the continue button
		MovePlayerObject.WonOrPause = false;
		if(transform.position.x > 0f){
			transform.position -= new Vector3(relativeForce, 0, 0);
			yield return new WaitForSeconds(0.02f);
			StartCoroutine(FromPauseToGame());
		}
		yield return new WaitForSeconds(0.1f);
	}
	public IEnumerator GoToWinScreen(){//////////////Winning the game
		MovePlayerObject.WonOrPause = true;
		if(transform.position.x > -1f){
			//Debug.Log(transform.position.y);
			transform.position -= new Vector3(relativeForce, 0, 0);
			yield return new WaitForSeconds(0.02f);
			StartCoroutine(GoToWinScreen());
		}
		yield return new WaitForSeconds(0.1f);
	}
}
