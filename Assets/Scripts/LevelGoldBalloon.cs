using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelGoldBalloon : MonoBehaviour {

	//we attach this script to seven images ,that shows if the golden balloon has been taken
	void Start()
	{
		//call the method
		UpdateGoldBalloon();
	}

	public void UpdateGoldBalloon()
	{		
		//with method GetGoldBalloon from class LevelState , we get a bool variable ,
		//if it's true that the player took the golden balloon of the specific level , otherwise he didnt

		//we examine if he took the golden balloon in a level and if the name of the gameObject that called the method represents the same level
		//then we change the color (from the component image) of the image gameobject 
		if ((LevelState.GetLevelState ().GetGoldBalloon ("Level1")) && gameObject.name.Equals("Balloon1")) {
			gameObject.GetComponent<Image> ().color = new Color(1,1,0,1);
		} 
		if ((LevelState.GetLevelState ().GetGoldBalloon ("Level2")) && gameObject.name.Equals("Balloon2")) {
			gameObject.GetComponent<Image> ().color = new Color(1,1,0,1);
		} 
		if ((LevelState.GetLevelState ().GetGoldBalloon ("Level3")) && gameObject.name.Equals("Balloon3")) {
			gameObject.GetComponent<Image> ().color = new Color(1,1,0,1);
		} 
		if (LevelState.GetLevelState ().GetGoldBalloon ("Level4") && gameObject.name.Equals("Balloon4")) {
			gameObject.GetComponent<Image> ().color = new Color(1,1,0,1);
		} 
		if (LevelState.GetLevelState ().GetGoldBalloon ("Level5") && gameObject.name.Equals("Balloon5")) {
			gameObject.GetComponent<Image> ().color = new Color(1,1,0,1);
		} 
		if (LevelState.GetLevelState ().GetGoldBalloon ("Level6") && gameObject.name.Equals("Balloon6")) {
			gameObject.GetComponent<Image> ().color = new Color(1,1,0,1);
		} 
		if (LevelState.GetLevelState ().GetGoldBalloon ("Level7") && gameObject.name.Equals("Balloon7")) {
			gameObject.GetComponent<Image> ().color = new Color(1,1,0,1);
		}
	}
}
