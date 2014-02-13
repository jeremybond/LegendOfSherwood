using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {
	public GameObject[] tileMap;
	public int[] tileId;
	public int Xrow;
	public int Ynum;
	public Vector3 tilePos;
	
	// Use this for initialization
	void Start () {
		Readtile();
		tileId = Levels.introLvl;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Readtile(){
		for(int i = 0;i < 200; i ++)
		{
			
			Xrow ++;
			int straightener = 0;
			if(tilePos.y < 0)
			{
				straightener = 1;
			}
			tilePos.x += 1;
			if(Xrow > 20-straightener)
			{
				Ynum += 1;
				tilePos.y -= 1;
				tilePos.x = 1;
				Xrow = 0;
				//Debug.Log("YPos" + tilePos.y + "| XPos:" + tilePos.x);
			}
			CreateTile(Levels.introLvl[i]);
			
		}
	}
	void CreateTile(int id){
			
		switch(id){
			case 1:
				//GameObject newPlayer		= Instantiate(Resources.Load("Prefabs/Player"), 						tilePos, transform.rotation) as GameObject;
				//newPlayer.name = "Player";
			break;

		}
	}
}
