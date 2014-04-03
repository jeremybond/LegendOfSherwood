using UnityEngine;
using System.Collections;

public class AllGUITexts : MonoBehaviour {
	public GUIText gameCredits;
	public GUIText coinBags;
	public bool creditsBool = false;
	public bool coinBagsBool = false;
	public static int amountOfGoldBags = 0;
	public int totalAmountOfCoinBags;
	void Start () {
		if(creditsBool)
		{
			gameCredits.text = "\nCrew \n" +
			"Developers \n" + "Jeremy Bond & Yornie Westink \n" +
			" \n" +
			"Artists \n" + "Dejorden Moerman & Joost Voss & Joppe Min & Vince van den Wijngaard \n" +
			" \n" +
			"Managers \n" + "Janine Spijker & Lisa van Diepen & Samantha Klein \n" +
			" \n" + " \n" +
			"Special Thanks To \n" + "Ruben Koops & Ted de Vos\0";
		}else if(coinBagsBool)
		{
			coinBags.text = amountOfGoldBags + "/" + totalAmountOfCoinBags;
		}
	}


	void Update () {
		if(coinBagsBool)
		{
			coinBags.text = amountOfGoldBags + "/" + totalAmountOfCoinBags + "                        Level: " + StaticVariables.currentLevelInt;
		}
	}
}
