using UnityEngine;
using System.Collections;

public class ChooseSkin : MonoBehaviour {



	// Use this for initialization
	public void setSkinGame()
	{
		PlayerPrefs.DeleteKey ("Theme");

		PlayerPrefs.SetString ("Theme", "Game");
	}
	public void setSkinEaster()
	{
		PlayerPrefs.DeleteKey ("Theme");
		PlayerPrefs.SetString ("Theme", "Easter");
	}

	public void setSkinGem()
	{
		PlayerPrefs.DeleteKey ("Theme");
		PlayerPrefs.SetString ("Theme", "Gem");
	}

	public void setSkinCake()
	{
		PlayerPrefs.DeleteKey ("Theme");
		PlayerPrefs.SetString ("Theme", "Cake");
	}
	public void setSkinRandom()
	{
		PlayerPrefs.DeleteKey ("Theme");
		PlayerPrefs.SetString ("Theme", "Random");
	}


}