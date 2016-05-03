using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Main : MonoBehaviour {
	//This class is the main class of the game. Will handle game logic.



	public GameObject[] GameStored;
	public GameObject[] GemStored;
	public GameObject[] CakeStored;
	public GameObject[] EasterStored;

	public GameObject[,] jellyArray; // Array containing all different jellies.
	private GameObject firstObject;
	private GameObject secondObject;
	public GameObject [] listofJellies; // List of jellies
	public GameObject emptyGameObject; // When destroying a gameObject, replace with this for now.
	public GameObject matchParticle;
	private GameObject currentIndicator;
	public GameObject indicator;
	public GameObject gridBG;
	public Text scoreText;
	public GameObject completeUI;


 	
	public int winScore;
	public bool levelComplete; // Way to check whether or not player has completed objective
	private int scoreIncrement = 5; // 
	private int totalScore = 0;

	// public AudioClip MatchSound; // Sound for when match is made

	public int gridWidth;
	public int gridHeight;



	void Start () {
		levelComplete = false;
		GetLevel ();
		GetTheme ();
		SetUpGrid ();
		SetupBoard();

		// scoreText.text = "Hello";
	}
	void GetTheme()
	{
		
		string theme = PlayerPrefs.GetString ("Theme");
		Debug.Log (theme);

		if (theme == "Game") {
			listofJellies [0] = GameStored [0];
			listofJellies [1] = GameStored [1];
			listofJellies [2] = GameStored [2];
			listofJellies [3] = GameStored [3];
			listofJellies [4] = GameStored [4];

		} else if (theme == "Easter") {
			listofJellies [0] = EasterStored [0];
			listofJellies [1] = EasterStored [1];
			listofJellies [2] = EasterStored [2];
			listofJellies [3] = EasterStored [3];
			listofJellies [4] = EasterStored [4];
		} else if (theme == "Gem") {
			listofJellies [0] = GemStored [0];
			listofJellies [1] = GemStored [1];
			listofJellies [2] = GemStored [2];
			listofJellies [3] = GemStored [3];
			listofJellies [4] = GemStored [4];
			
		} else if (theme == "Cake") {
			listofJellies [0] = CakeStored [0];
			listofJellies [1] = CakeStored [1];
			listofJellies [2] = CakeStored [2];
			listofJellies [3] = CakeStored [3];
			listofJellies [4] = CakeStored [4];

		} else {

			int randomInt = Random.Range (1, 100);
			Debug.Log (randomInt);

			if (randomInt >=0 && randomInt < 30) {
				listofJellies [0] = GameStored [0];
				listofJellies [1] = GameStored [1];
				listofJellies [2] = GameStored [2];
				listofJellies [3] = GameStored [3];
				listofJellies [4] = GameStored [4];

			}
			else if (randomInt >=30 && randomInt < 50) {
				listofJellies [0] = EasterStored [0];
				listofJellies [1] = EasterStored [1];
				listofJellies [2] = EasterStored [2];
				listofJellies [3] = EasterStored [3];
				listofJellies [4] = EasterStored [4];

			}
			else if (randomInt >=50 && randomInt <70) {
				listofJellies [0] = GemStored [0];
				listofJellies [1] = GemStored [1];
				listofJellies [2] = GemStored [2];
				listofJellies [3] = GemStored [3];
				listofJellies [4] = GemStored [4];

			}
			else {
				listofJellies [0] = CakeStored [0];
				listofJellies [1] = CakeStored [1];
				listofJellies [2] = CakeStored [2];
				listofJellies [3] = CakeStored [3];
				listofJellies [4] = CakeStored [4];

			}
            
		}


	}

	/*public static string GetGameObjectPath(GameObject obj)
	{
		string path = "/" + obj.name;
		while (obj.transform.parent != null) {

			obj = obj.transform.parent.gameObject;
			path = "/" + obj.name + path;

		}
	}*/

	void GetLevel()
	{
		string currentLevel = SceneManager.GetActiveScene().name;
		Debug.Log (currentLevel);

		if (currentLevel == "Level1") {
			gridHeight = 6;
			gridWidth = 5;
			winScore= 300;
	
		}
		if (currentLevel == "Level2") {

			gridHeight = 4;
			gridWidth = 6;
			winScore = 300;
		}
		if (currentLevel == "Level3") {
			gridHeight = 4;
			gridWidth = 7;
			winScore= 350;
		}
		if (currentLevel == "Level4") {
			gridHeight = 5;
			gridWidth = 5;
			winScore= 320;
		}
		if (currentLevel == "Level5") {
			gridHeight = 7;
			gridWidth = 5;
			winScore=450;
		}

	}

	// Creates the grid.
	public void SetUpGrid()
	{
		//Initialise the array for grid height and width
		jellyArray = new GameObject[gridWidth,gridHeight];
		//Create the jellies from the list of the jellies (Which is set in Unity's editor)
		for(int i=0; i <= gridWidth-1;i++)
		{
			for(int j=0;j<=gridHeight-1;j++)
			{
				
				var gameObject = GameObject.Instantiate (listofJellies [Random.Range (0, listofJellies.Length)] as GameObject,
					new Vector3 (i, j, 0), transform.rotation) as GameObject;
				jellyArray [i, j] = gameObject;

				while (i >= 2 && jellyArray [i-1, j].name == jellyArray [i, j].name && jellyArray[i-2,j].name == jellyArray[i,j].name ){
					
					Destroy (gameObject);


					var gb = GameObject.Instantiate (listofJellies [Random.Range (0, listofJellies.Length)] as GameObject,
						new Vector3 (i, j, 0), transform.rotation) as GameObject;

					jellyArray [i, j] = gb;

					if (jellyArray [i, j].name == jellyArray [i - 1, j].name && jellyArray [i, j].name == jellyArray [i - 2, j].name) {
						Destroy (gb);
					}
				}
				while (j >= 2 && jellyArray [i, j-1].name == jellyArray [i, j].name && jellyArray[i,j-2].name == jellyArray[i,j].name ){
					
					Destroy (gameObject);
				
					 var gb = GameObject.Instantiate (listofJellies [Random.Range (0, listofJellies.Length)] as GameObject,
						new Vector3 (i, j, 0), transform.rotation) as GameObject;

					jellyArray [i, j] = gb;
					if (jellyArray [i, j].name == jellyArray [i, j-1].name && jellyArray [i, j].name == jellyArray [i, j-2].name) {
						Destroy (gb);
					}
				}



				//var gridBackground = GameObject.Instantiate (gridBG as GameObject, new Vector3(i,j,0),transform.rotation) as GameObject;

	}
		}
	}
	public void SetupBoard()
	{
		for (int i = 0; i <= gridWidth - 1; i++) {
			for (int j = 0; j <= gridHeight - 1; j++) {
				var gridBackground = GameObject.Instantiate (gridBG as GameObject, new Vector3(i,j,0),transform.rotation) as GameObject;
			}

		}
	}
		
	// Update is called once per frame
	void Update ()
	{
		bool ShouldMove = false;

		/*if (Input.GetButtonDown ("Fire1") && HOTween.GetTweenInfos () == null && levelComplete == true) {
			//This is going to be the logic for when game objective is met.

			
		}*/

		//If selected via tap or left Mouse button and animations finish.
		if (Input.GetButtonDown ("Fire1") && HOTween.GetTweenInfos () == null) {
			
				Destroy (currentIndicator);//Destroys indicator

				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			
				if (hit.transform != null) {
					//Checking if user has selected a title or not.
					if (firstObject == null) {
						firstObject = hit.transform.gameObject;
					} else {
						secondObject = hit.transform.gameObject;
						ShouldMove = true;
					}
				
				currentIndicator = GameObject.Instantiate (indicator, new Vector3 (hit.transform.gameObject.transform.position.x,
					hit.transform.position.y, -1), transform.rotation) as GameObject;
				// If user selects the second tile. It will swap the jellies and animate.
				if (ShouldMove == true) {
					// If the user selects a second title, it'll swap the tiles and animate.
					var distance = firstObject.transform.position - secondObject.transform.position;
					//Check for 2 tiles being beside each other.
					if (Mathf.Abs (distance.x) <= 1 && Mathf.Abs (distance.y) <= 1) {
						if (distance.x != 0 && distance.y != 0) {
							Destroy (currentIndicator);
							firstObject = null;
							secondObject = null;
							return;
						}
						
						AnimateSwap (firstObject.transform, secondObject.transform);
						SwapTile (firstObject, secondObject, ref jellyArray);
					} else {
						firstObject = null;
						secondObject = null;
					}
					Destroy (currentIndicator); //Destroys indicator
					}
				}
			}

	
	
		//If no animation is playing
		if (HOTween.GetTweenInfos() == null) {
			
			var Matches = FindMatch(jellyArray);
			//If we find a match, update score.
			if (Matches.Count > 0) {
				totalScore += Matches.Count * scoreIncrement;
				scoreText.text = totalScore.ToString ();
				if( totalScore >= winScore)
				{
					scoreText.text = "You Win!";

					//Brings in the completion UI dialogue when level is complete
					string currentLevel = SceneManager.GetActiveScene().name;
					if (currentLevel == "Level1") {
						HOTween.To(completeUI.transform, 0.8f, "position", new Vector3(1.3f,2,0));
					}
					if (currentLevel == "Level2") {
						HOTween.To(completeUI.transform, 0.8f, "position", new Vector3(2.2f,2,0));
					}
					if (currentLevel == "Level3") {
						HOTween.To(completeUI.transform, 0.8f, "position", new Vector3(3f,2,0));
					}
					if (currentLevel == "Level4") {
						HOTween.To(completeUI.transform, 0.8f, "position", new Vector3(1.6f,2,0));
					}
					if (currentLevel == "Level5") {
						HOTween.To(completeUI.transform, 0.8f, "position", new Vector3(1.5f,2,0));
					}

				
			

		

				}

				foreach (GameObject emptyCell in Matches) {
					//Play Match Sound
					//GetComponent<AudioSource>().PlayOneShot(MatchSound);
					//particle shit here.
				//	var destroyingParticle = GameObject.Instantiate(matchParticle as GameObject, new Vector3(emptyCell.transform.position.x, emptyCell.transform.position.y, -2), transform.rotation) as GameObject;
				//	Destroy(destroyingParticle, 1f);

					//Replace matched tile with an empty one
					jellyArray [(int)emptyCell.transform.position.x, (int)emptyCell.transform.position.y] = 
						GameObject.Instantiate (emptyGameObject, new Vector3 ((int)emptyCell.transform.position.x, (int)emptyCell.transform.position.y, -1), transform.rotation) as GameObject;

					//Destroy the ancient matching tiles
					Destroy (emptyCell, 0.1f);
				}

				firstObject = null;
				secondObject = null;
				// Moving the tiles down
				MoveGravity (ref jellyArray);
			} else if (firstObject != null && secondObject != null) {
				
				AnimateSwap (firstObject.transform, secondObject.transform);
				SwapTile (firstObject, secondObject, ref jellyArray);
				firstObject = null;
				secondObject = null;
			}
			if (Matches.Count == 0) {
				//checkForShuffle (jellyArray);
			}

		}

		// Update Score.
		//(GetComponent (typeof(TextMesh))as TextMesh).text = totalScore.ToString ();
	}

	 void checkForShuffle(GameObject[,] cells)
	{
		bool matchFound = false;
		Debug.Log (gridWidth + "" + gridHeight);
		for (int x = 0; x < gridWidth; x++) {
			for (int y = 0; y < gridHeight; y++) {


				var thiscell = cells [x, y];


				if (x < (gridWidth - 2) && y < (gridHeight - 1)) {
					if (thiscell.name == cells [x + 1, y].name) {
						if (thiscell.name == cells [(x + 2), (y + 1)].name) {

							/*
				 * OOX
				 * XXO
				*/
							Debug.Log ("Match Found");
							matchFound = true;
							break;

						}
					}

				}
			

				if (x <= (gridWidth - 2) && y >= 1) {
					if (thiscell.name == cells [x + 1, y].name && thiscell.name == cells [x + 2, y - 1].name) 
						/*
				 * XXO
				 * OOX
				*/
						Debug.Log ("Match Found");
					matchFound = true;
					break;

					}
				if (x >= 2 && y >= 1) {
					if (thiscell.name == cells [x - 1, y].name && thiscell.name == cells [x - 2, y - 1].name) {

						/*
				 * OXX
				 * XOO
				*/
						Debug.Log ("Match Found");
						matchFound = true;
						break;

					}
				}
				if (x >= 2 && y <= (gridHeight - 1)) {
					if (thiscell.name == cells [(x - 1), y].name && thiscell.name == cells [(x - 2), (y + 1)].name ) {

						/*
				 * XOO
				 * OXX
				*/
						Debug.Log ("Match Found");
						matchFound = true;
						break;

					}
				}

				if (x < gridWidth && y < (gridHeight - 2)) {
				
					if (thiscell.name == cells[x, (y + 1)].name && thiscell.name == cells[(x + 1), (y + 2)].name) {

						/*
				 * OXO
				 * XOO
				 * XOO
				*/
						Debug.Log ("Match Found");
						matchFound = true;
						break;

					}
				}
				
				if (x > 0 && y < (gridHeight - 2)) {

						if (thiscell.name == cells [x, y+1].name && thiscell.name == cells [x-1, y + 2].name ) {

							/*
				 * XOO
				 * OXO
				 * OXO
				*/
						Debug.Log ("Match Found");
						matchFound = true;
						break;

						}
					}
				
				if (x > 0 && y <= (gridHeight - 2)) {
						if (thiscell.name == cells [x, y+1].name && thiscell.name == cells [x-1, y + 2].name ) {

							/*
				 * XOO
				 * OXO
				 * OXO
				*/
						Debug.Log ("Match Found");
						matchFound = true;
						break;
					
						}
					}

					if (x >= 1 && y >= 2) {
						if (thiscell.name == cells [x, y-1].name && thiscell.name == cells [x-1, y - 2].name) {

							/*
				 * XOO
				 * XOO
				 * OXO
				*/
						Debug.Log ("Match Found");
						matchFound = true;
						break;
					
						}
					}
				if (x <= (gridWidth - 1) && y >= 2) {
						if (thiscell.name == cells [x, y-1].name && thiscell.name == cells [x+1, y - 2].name) {

							/*
				 * OOO
				 * OXO
				 * XOO
				*/
						Debug.Log ("Match Found");
						matchFound = true;
						break;
					
						}
					}
				


			}
		}

		if (matchFound == false) {
			shuffle(jellyArray);
		}


	} 

			


	public void shuffle(GameObject[,] cells)
	{
		for (int x = 0; x < gridWidth; x++) {
			for (int y = 0; y < gridHeight; y++) {

				Destroy (cells [x, y]);


			}
		}
		SetUpGrid ();
	}

	private ArrayList FindMatch(GameObject[,] cells)
	{
		// This is the algorithm for finding matches. Should be called from Update(). This is a very long algorithm.
		ArrayList stack = new ArrayList ();
		//Check vertical tiles.
		for (var x = 0; x <= cells.GetUpperBound(0); x++) 
		{
			for (var y = 0; y <= cells.GetUpperBound(1); y++) 
			{
				var thiscell = cells[x, y];
				//if it's an empty tile continue

				if (thiscell.name == "Empty(Clone)") {
					continue;
				}
				int matchCount = 0;
				int y2 = cells.GetUpperBound(1);
				int y1;
				//Getting the number of tiles of the same kind
				for (y1 = y + 1; y1 <= y2; y1++) {
					if (cells [x, y1].name == "Empty(Clone)" || thiscell.name != cells [x, y1].name) {
						break;
					}
					matchCount++;
				}
				// If we found more than 2 tiles close we add them in the array of matching title
				if (matchCount >= 2) {
					y1 = Mathf.Min (cells.GetUpperBound (1), y1 - 1);
					for (var y3 = y; y3 <= y1; y3++) {
						if (!stack.Contains (cells [x, y3])) 
						{
							stack.Add(cells[x, y3]);
						}
					}
				}
			}
		}
		// Checking the horizontal tiles, in the following loops we will use the same concept as the previous ones
		for (var y = 0; y < cells.GetUpperBound (1) + 1; y++) {
			for (var x = 0; x < cells.GetUpperBound (0) + 1; x++) {
				var thiscell = cells [x, y];
				if (thiscell.name == "Empty(Clone)")
					continue;
				int matchCount = 0;
				int x2 = cells.GetUpperBound (0);
				int x1;
				for (x1 = x + 1; x1 <= x2; x1++) {
					if (cells [x, y].name == "Empty(Clone)" || thiscell.name != cells [x1, y].name)	break;
					matchCount++;
				}
				if (matchCount >= 2) {
					x1 = Mathf.Min (cells.GetUpperBound (0), x1 - 1);
					for (var x3 = x; x3 <= x1; x3++) {
						if (!stack.Contains (cells [x3, y])) {
							stack.Add (cells [x3, y]);
						}
					}
				}
			}
		}
		return stack;
	}


	void MoveGravity(ref GameObject[,] cells)
	{
		// Called for when there's an empty tile and it needs to pull down a jelly 

		//Replace empty Tile with one above.
		for (int x = 0; x <= cells.GetUpperBound (0); x++) {
			for (int y = 0; y <= cells.GetUpperBound (1); y++) {
				var thisCell = cells [x, y];
				if (thisCell.name == "Empty(Clone)") {
					for (int y2 = y; y2 <= cells.GetUpperBound (1); y2++) {
						if (cells [x, y2].name != "Empty(Clone)") { 
							cells [x, y] = cells [x, y2];
							cells [x, y2] = thisCell;
							break;
						}
					}
				}
			}
		}

		//Insantiate new tiles to replace Empty ones.
		for (int x = 0; x<= cells.GetUpperBound(0);x++)
			{
				for (int y=0;y <= cells.GetUpperBound(1); y++)
				{
				if (cells [x, y].name == "Empty(Clone)") {
					Destroy (cells [x, y]);
					cells [x, y] = GameObject.Instantiate (listofJellies [Random.Range (0, listofJellies.Length)] as GameObject, new Vector3 (x, cells.GetUpperBound (1) + 2, 0), transform.rotation) as GameObject;
				}
				}			
			}

		// Eases the transition in "gravity" effect
		for (int x = 0; x <= cells.GetUpperBound (0); x++) {
			for (int y = 0; y <= cells.GetUpperBound (1); y++) {
				TweenParms Tparms = new TweenParms ().Prop ("position", new Vector3 (x, y, -1)).Ease(EaseType.EaseOutQuart);
				HOTween.To (cells [x, y].transform, 1.0f, Tparms);
			}
		}
	}


	void TouchMethod()
	{
		
	}



	void AnimateSwap(Transform a,Transform b)
	{
		//hold these positions into vector3s for Hotween.
		Vector3 posA = a.localPosition;
		Vector3 posB = b.localPosition;

		//These lines will smooth out the animation of them moving. 0.25 Seconds.
		TweenParms Tparms = new TweenParms ().Prop ("localPosition", posB).Ease (EaseType.EaseOutQuart);
		HOTween.To (a, 0.3f, Tparms).WaitForCompletion ();
		Tparms = new TweenParms ().Prop ("localPosition", posA).Ease (EaseType.EaseOutQuart);
		HOTween.To (b, 0.3f, Tparms).WaitForRewind ();
	}
	void SwapTile(GameObject a, GameObject b, ref GameObject[,] cells)
	{
		//Swaps positions of two objects(Jellies) in the Jelly/Grid Array.
		// hold a game object to temporary hold gameObject A's position
		GameObject temp = cells[(int)a.transform.transform.position.x,(int)a.transform.position.y];
		// sets a = b's position then b to temp(a)'s position.
		cells[(int)a.transform.position.x, (int)a.transform.position.y] = cells[(int)b.transform.position.x,(int)b.transform.position.y];
		cells [(int)b.transform.position.x, (int)b.transform.position.y] = temp;

	}
}
