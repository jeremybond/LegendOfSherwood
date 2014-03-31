using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour 
{
	public static bool canIDie = false;
	public void Start()
	{	
		if(canIDie)
		{
			Destroy(this.gameObject);
			AllGUITexts.amountOfGoldBags += 1;
		}
	}
}
