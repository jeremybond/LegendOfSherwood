using UnityEngine;
using System.Collections;

public class Animations: MonoBehaviour
{
	
	public Animator animator;

	// Use this for initialization
	/*void Start()
	{
		animator = this.GetComponent<Animator>();
	}*/
	
	// Update is called once per frame
	void Update()
	{
		// idle
		animator.SetInteger("AnimationsArt", 0);

		if (LeftEnRightButton.shootingAni)
		{
			animator.SetInteger("AnimationsArt", 3);
		}else

		if(MovePlayerObject.rightMovement)
		{
			Debug.Log("WalkAnimation");
			animator.SetInteger("AnimationsArt", 1);

		}else
		
		if(LeftEnRightButton.jumped)
		{
			Debug.Log("JumpAnimation");
			animator.SetInteger("AnimationsArt", 2);
		}
	}
	private IEnumerator setShootingAniToFalse(){
		yield return new WaitForSeconds(1f);
		animator.SetInteger("AnimationsArt", 0);
	}
}