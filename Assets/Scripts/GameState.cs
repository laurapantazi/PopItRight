using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameState{
	private int score = 0;
	private int life = 3;
	private bool stateSound=true,stateMusic=true;
	private float ds;
	private float temp = 0.03f;
	private static GameState instantiate=null;
	//constructor
	private GameState (){	}
	//return score
	public int GetScore() 
	{
		return score;
	}
	//reset score
	public void ResetScore ()
	{
		score = 0;
	}

	//we increade score based on the color of the balloon
	public void IncreaseScore(string color)
	{
		score = GetScore ();				//get the score number
		color = color.ToLower(); 			//set the string to lower letters
		//check if color is red,blue,green,black,gold
		if (color.Contains ("red"))
			score = score + 2;
		else if (color.Contains ("blue"))
			score = score + 1;
		else if (color.Contains ("green"))
			score = score + 1;
		else if (color.Contains ("black"))
			life = life - 1;
		else if (color.Contains ("gold"))
		{	//we get the name of the active scene
			string sceneName = SceneManager.GetActiveScene ().name;
			//call method SetGoldBalloon from class LevelState ,with parameter the name of  the scene 
			LevelState.GetLevelState ().SetGoldBalloon (sceneName); 
		}
		else
			score= score +1; 
	}

	//return the life 
	public int GetLife() 
	{
		return life;
	}
	//reset life
	public void ResetLife ()
	{
		life = 3;
	}
	//decrease life
	public void DecreaseLife()
	{
		life--;
	}
	//sets the new position of the balloon 
	public Vector3 BalloonMovement(float ds,Vector3 oldPosition)
	{
		return new Vector3 (oldPosition.x,oldPosition.y+ds,oldPosition.z);
	}
	//if paused is true , the balloons will have 0 moving, so they will remain in the same position (the game will be paused)
	//otherwise if paused is false , the balloons will have the same default moving , (the game will be in state play)
	public void SetMovement(bool paused)
	{
		if (paused) {
			ds = 0;
		} else {
			ds = temp;
		}
	}
	//return the moving of the balloon
	public float GetMovement()
	{
		return ds;
	}
	//if state true, then the music state will be true
	//otherwise it will be false
	public void SetMusicState(bool state)
	{
		if (state) stateMusic=true;
		else stateMusic=false;
	}
	//return music state
	public bool GetMusicState() 
	{
		return stateMusic;
	}
	//if state true, then the sound state will be true
	//otherwise it will be false
	public void SetSoundState(bool state)
	{
		if (state) stateSound=true;
		else stateSound=false;
	}
	//return sound state
	public bool GetSoundState() 
	{
		return stateSound;
	}
	//create an instance of the class
	public static GameState GetGameState()
	{
		if (instantiate == null) 
		{
			instantiate = new GameState ();
		}
		return instantiate;
	}
}