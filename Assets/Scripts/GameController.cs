using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public GameObject balloon;
	public GameObject balloonParent;
	private float randomX,randomY,randomZ;
	private Vector3 randomPosition;
	private GameObject newBalloon;
	private bool musicState,soundState;
	private float Timer = 0f;
	private bool paused;
	public GameObject pauseGame,restartGame;
	public GameObject score, life;
	public Material red,green,blue,black,golden;
	public GameObject panelNew,losePanel,winPanel,initialPanel,topPanel,infoPanel,infoButton;
	public Image img,infoimage;
	private bool goldenBalloonFlag=true;
	private int count = 0;
	private bool winPanelFlag = true;
	public Text levelText;


	void Awake () {
		initialPanel.SetActive (true);  //activate gameobject panel
		topPanel.SetActive (false);		//deactivate gameobject panel
		infoButton.SetActive (false);	//deactivate gameobject panel
		levelText.GetComponent<Text> ().text = SceneManager.GetActiveScene().name;;
		Invoke ("HideLevelImage",2f); //call method HideLevelImage after time 2f
		GameState.GetGameState ().ResetScore ();  //reset score
		paused = false; 				//deactivate pause button
		GameState.GetGameState ().SetMovement (false); //method SetMovement takes a bool parameter,that represents if the game is paused, if parameter false,itmeans it's not paused
	}

	void Update () {		
		createBalloonClone ();  //call method from this class
		string sceneName= SceneManager.GetActiveScene().name;	//get the name of the current active scene
		score.GetComponent<Text>().text="SCORE : "+GameState.GetGameState ().GetScore (); //change the score text to the current one
		life.GetComponent<Text>().text="LIFE : "+GameState.GetGameState ().GetLife ();    //change the life text to the current one

		if (GameState.GetGameState ().GetScore () > 10 && winPanelFlag) {
			//call method SetUnlocked with the name of this scene, 
			//this method will keep a bool variable of the new level as true (the next level will be unlocked)
			LevelState.GetLevelState ().SetUnlocked (sceneName);  
			winPanel.SetActive(true);   //activate gameobject panel
			GameState.GetGameState ().SetMovement (true);  //call method with parameter true, so the balloons will be paused
			//keep a flag ,because when we unlock new level , the winPanel will appear only once in each level
			winPanelFlag = false;
		}
		if ((GameState.GetGameState ().GetLife () == 0) ) {
			losePanel.SetActive(true);    //activate gameobject panel
			GameState.GetGameState ().SetMovement (true);   //call method with parameter true, so the balloons will be paused
		}
	}

	//create balloon clones 
	public void createBalloonClone ()
	{
		//decrease the timer to Time.deltaTime
			Timer -= Time.deltaTime;
			if (Timer <= 0f) {
				if (GameState.GetGameState ().GetMovement () != 0) {
					randomX = Random.Range (-6, 6);  //get a random number from -6 to 6
					randomY = -9;  //y position will be the same
					randomZ = -1;	//z position will be the same
					randomPosition = new Vector3 (randomX, randomY, randomZ); //create new Vector3 
					// create new clone gameobject of balloon , with randomPosition , and name newBalloon
					newBalloon = Instantiate (balloon, randomPosition, transform.rotation) as GameObject;
					//set parent of newBalloon gameobject, the balloonParent 
					newBalloon.transform.parent = balloonParent.transform;
					//set sprite from component Sprite Renderer (of the new balloon) the sprite of the balloon gameobject
					newBalloon.GetComponent<SpriteRenderer> ().sprite = balloon.GetComponent<SpriteRenderer> ().sprite;
					//call method of this class, chooseRandomBalloon()
					string color = chooseRandomBalloon ();
					//according to the color that the method returned, we assign a different material to the new gameobject 
					if (goldenBalloonFlag && color == "golden" && count>10) {
						//add the material 
						newBalloon.GetComponent<SpriteRenderer> ().material = golden;
						//change the size of the gameobject
						newBalloon.GetComponent<Transform>().localScale = new Vector3(0.7F, 0.7F, 0.7F);
						//we keep a flag ,so the golden balloon will appear each level
						goldenBalloonFlag = false;
					} else if (color == "red") {
						newBalloon.GetComponent<SpriteRenderer> ().material = red;
					} else if (color == "blue") {
						newBalloon.GetComponent<SpriteRenderer> ().material = blue;
					} else if (color == "black") {
						newBalloon.GetComponent<SpriteRenderer> ().material = black;
					} else {
						newBalloon.GetComponent<SpriteRenderer> ().material = green;
					}
					newBalloon.SetActive (true);  //activate gameobject
					count++;
				}
				Timer = 1f;
			//set the timer to 1.4f ,in order to create a "gap" of time between every balloon instantiate
			}
	}

	//method called from this class, after we show the initial panel
	private void HideLevelImage()
	{
		initialPanel.SetActive (false);//deactivate panel
		topPanel.SetActive (true);//activate panel
		infoButton.SetActive (true); //activate panel
		paused = false; 		//deactivate pause button
	}
	//method called when we press button information
	public void InfoButton ()
	{
		//activate panel 
		infoPanel.SetActive (true); 
		//call method SetMovement
		GameState.GetGameState ().SetMovement (true);
		//get the name of the current active scene
		string sceneName= SceneManager.GetActiveScene().name;
		if (sceneName.Equals ("Level1"))
		{
			//change child text name of the gameobject infoPanel 
			infoPanel.GetComponentInChildren<Text>().text = "Level 1";
			//change sprite of the gameobject infoimage, load the sprite with name Level1 ,from folden Resources
			infoimage.sprite = Resources.Load<Sprite>("Level1"); 
		}
		else if (sceneName.Equals ("Level2"))
		{
			infoPanel.GetComponentInChildren<Text>().text = "Level 2";
			infoimage.sprite = Resources.Load<Sprite>("Level2");
		}
		else if (sceneName.Equals ("Level3")) 
		{
			infoPanel.GetComponentInChildren<Text>().text = "Level 3";
			infoimage.sprite = Resources.Load<Sprite>("Level3");
		}
		else if (sceneName.Equals ("Level4")) 
		{
			infoPanel.GetComponentInChildren<Text>().text = "Level 4";
			infoimage.sprite = Resources.Load<Sprite>("Level4");
		}
		else if (sceneName.Equals ("Level5")) 
		{
			infoPanel.GetComponentInChildren<Text>().text = "Level 5";
			infoimage.sprite = Resources.Load<Sprite>("Level5");
		}
		else if (sceneName.Equals ("Level6")) 
		{
			infoPanel.GetComponentInChildren<Text>().text = "Level 6";
			infoimage.sprite = Resources.Load<Sprite>("Level6");
		}
		else if (sceneName.Equals ("Level7")) 
		{
			infoPanel.GetComponentInChildren<Text>().text = "Level 7";
			infoimage.sprite = Resources.Load<Sprite>("Level7");
		}
		else if (sceneName.Equals ("Level8")) 
		{
			infoPanel.GetComponentInChildren<Text>().text = "Level 8";
			infoimage.sprite = Resources.Load<Sprite>("Level8");
		}
	}
	//method called when we have lock new level press button continue in the same level
	public void ContinueButton()
	{
		winPanel.SetActive(false);     //deactivate panel winPanel
		infoPanel.SetActive (false);	//deactivate panel infoPanel
		GameState.GetGameState ().SetMovement (false);  //call method SetMovement 
	}
	//method called when we have lost and we press button repeat level 
	public void RepeatButton()
	{
		losePanel.SetActive(false);//deactivate panel losePanel
		GameState.GetGameState ().SetMovement (false); //call method SetMovement 
		GameState.GetGameState ().ResetLife();  //reset life=3
		GameState.GetGameState ().ResetScore(); //reset score=0
	}

	//method called when we press button pause/start
	public void PauseGame()
	{
		if (!paused) {
			//game is paused
			infoButton.SetActive (false);
			paused = true;
			GameState.GetGameState().SetMovement (true); //call method SetMovement with parameter true
			img.sprite= Resources.Load <Sprite> ("playButton"); //change sprite of the gameobject img, load the sprite with name playButton ,from folden Resources
		} else {
			//game is not paused
			infoButton.SetActive (true);
			paused = false;
			GameState.GetGameState ().SetMovement (false);//call method SetMovement with parameter false
			img.sprite= Resources.Load <Sprite> ("pauseButton"); //change sprite of the gameobject img, load the sprite with name pauseButton ,from folden Resources
		}
	}

	//method called when we press button restart
	public void RestartGame()
	{
		GameState.GetGameState ().ResetLife ();		//reset life 
		GameState.GetGameState ().ResetScore ();	//reset score 
	}


	//method that randomly(based on posibility) selects the new balloon color
	//returns a string with the color
	private string chooseRandomBalloon()
	{
		//list with colors and numbers that represent their posibility to appear
		List<KeyValuePair<string,double>> balloon=new List<KeyValuePair<string,double>>()
		{
			new KeyValuePair<string, double>("red",0.1),   			//red with posibility 10%
			new KeyValuePair<string, double>("golden",0.15),		//golden with posibility 5%
			new KeyValuePair<string, double>("green",0.45),			//green with posibility 30%
			new KeyValuePair<string, double>("blue",0.65),			//blue with posibility 20%
			new KeyValuePair<string, double>("black",1),			//black with posibility 35%
		};

		float r = Random.Range (0.0f, 1.0f); 		//create a random number r , from 0 to 1 
		string returnBalloon=null;
		foreach (KeyValuePair<string, double> i in balloon) 
		{
			returnBalloon = i.Key;
			if ( i.Value >= r ) break;			//if r<= to the first number from the list, then the color of this item will be given as output
		}
		return returnBalloon;
	}
		
}
