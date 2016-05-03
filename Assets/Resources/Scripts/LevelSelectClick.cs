using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelectClick : MonoBehaviour {

	public void onclick()
	{
		SceneManager.LoadScene ("levelSelect");
	}
}
