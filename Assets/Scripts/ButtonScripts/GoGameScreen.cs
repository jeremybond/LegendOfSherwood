using UnityEngine;
using System.Collections;

public class GoGameScreen : MonoBehaviour {

	public Texture2D button1;
	public Texture2D button2;
	public Texture2D button3;
	public int levelNumber = 1;
	public bool retry = false;//eddited in unity editor
	public bool next = false;//eddited in unity editor
	private int retryToLevelNumber = 1;// eddited in unity editor
	private bool unlocked = false;

	void Start()
	{
		if(!retry)
		{
			guiTexture.texture = button3;
		}else{
			guiTexture.texture = button1;
		}
	}
	void Update()
	{
		if(StaticVariables.levelsUnlocked >= levelNumber)
		{
			guiTexture.texture = button1;
			unlocked = true;
		}
		foreach (Touch touch in Input.touches)
		{
			if(unlocked)
				{
				if (guiTexture.HitTest(touch.position) && touch.phase != TouchPhase.Ended)
				{
					guiTexture.texture = button2;
				}
				else if (guiTexture.HitTest(touch.position) && touch.phase == TouchPhase.Ended)
				{
					guiTexture.texture = button1;
					if(retry)
					{
						if(next){
							StaticVariables.lastLevelInt += 1;
						}
						MovePlayerObject.WonOrPause = false;
						ChooseLevel();
					}else{
						StaticVariables.lastLevelInt = levelNumber;
						ChooseLevel();
					}
				}else if(!guiTexture.HitTest(touch.position))
				{
					guiTexture.texture = button1;
				}
			}
		}
	}

	public void NextLevel(){
		StaticVariables.lastLevelInt += 1;
		ChooseLevel();
	}
	public void ChooseLevel(){
		MovePlayerObject.WonOrPause = false;
		Debug.Log(MovePlayerObject.WonOrPause);
		StaticVariables.currentLevelInt = StaticVariables.lastLevelInt;
		switch(StaticVariables.lastLevelInt){
			case 1:
				Application.LoadLevel("Game 1");
			break;
			case 2:
				Application.LoadLevel("Game 2");
			break;
			case 3:
				Application.LoadLevel("Game 3");
			break;
			case 4:
				Application.LoadLevel("Game 4");
			break;
			case 5:
				Application.LoadLevel("Game 5");
			break;
			case 6:
				Application.LoadLevel("Game 6");
			break;
			case 7:
				Application.LoadLevel("Game 7");
			break;
			case 8:
				Application.LoadLevel("Game 8");
			break;
			case 9:
				Application.LoadLevel("Game 9");
			break;
			case 10:
				Application.LoadLevel("Game 10");
			break;
		}

	}
}
