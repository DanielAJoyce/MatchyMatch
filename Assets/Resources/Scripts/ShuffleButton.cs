using UnityEngine;
using System.Collections;

public class ShuffleButton : MonoBehaviour {

	public Main main;

	public void ShuffleClick()
	{
		
		main.shuffle (main.jellyArray);
	

	}
}
