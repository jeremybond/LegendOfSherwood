using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour 
{
	public void CollectMoney()
	{	
		Destroy(this.gameObject);
		Debug.Log(this.gameObject);
		AllGUITexts.amountOfGoldBags += 1;
	}
}
