using UnityEngine;
using System.Collections;

public class LevelState {
	private static LevelState inst=null;
	//variables that represent if each level is locked or unlocked
	//in the beginning all the levels are unlocked, so the variables are false
	//the first level is unlocked ,so we dont need a variable
	private bool unlockedL2 = false, unlockedL3 = false, unlockedL4 = false, unlockedL5 = false, unlockedL6 = false, unlockedL7 = false, unlockedL8 = false ; 
	//variables that represent in each level if we have picked the golden balloon
	//in the beginning we have pick none golden balloon, so the variables are false
	private bool goldenBalloonL1=false, goldenBalloonL2=false, goldenBalloonL3=false, goldenBalloonL4=false, goldenBalloonL5=false, goldenBalloonL6=false, goldenBalloonL7=false;

	private LevelState () {}
	public static LevelState GetLevelState()
	{
		if (inst == null) 
		{
			inst = new LevelState ();		//create new instance of the class
		}
		return inst;
	}

	//method that converts the name of the scene into a number , e.g. scene with name Level1 -> 1
	public int ConvertLevel(string levelName)
	{
		//use the method Contains() 
		if (levelName.Contains ("1")) {
			return 1;
		} else if (levelName.Contains ("2")) {
			return 2;
		} else if (levelName.Contains ("3")) {
			return 3;
		} else if (levelName.Contains ("4")) {
			return 4;
		} else if (levelName.Contains ("5")) {
			return 5;
		} else if (levelName.Contains ("6")) {
			return 6;
		} else if (levelName.Contains ("7")) {
			return 7;
		} else if (levelName.Contains ("8")) {
			return 8;
		} else
			return 0;
	}
	//set the next level to unlocked
	public void SetUnlocked (string levelName)
	{
		int levelNumber = ConvertLevel (levelName);
		if (levelNumber == 1)
			unlockedL2 = true;
		else if (levelNumber == 2)
			unlockedL3 = true;
		else if (levelNumber == 3)
			unlockedL4 = true;
		else if (levelNumber == 4)
			unlockedL5 = true;
		else if (levelNumber == 5)
			unlockedL6 = true;
		else if (levelNumber == 6)
			unlockedL7 = true;
		else if ((levelNumber == 7) && goldenBalloonL1 && goldenBalloonL2 && goldenBalloonL3 && goldenBalloonL4 && goldenBalloonL5 && goldenBalloonL6 && goldenBalloonL7)
			unlockedL8 = true;
	}
	//return true or false (the level is locked or unlocked)
	//obviously the 1st level is unlocked by default
	public bool GetUnlocked(string levelName)
	{
		int levelNumber = ConvertLevel (levelName);
		if (levelNumber == 2)
			return unlockedL2;
		else if (levelNumber == 3)
			return unlockedL3;
		else if (levelNumber == 4)
			return unlockedL4;
		else if (levelNumber == 5)
			return unlockedL5;
		else if (levelNumber == 6)
			return unlockedL6;
		else if (levelNumber == 7)
			return unlockedL7;
		else if (levelNumber == 8)
			return unlockedL8;
		else
			return false;
	}
	//set to true the variable that represents the level input
	public void SetGoldBalloon (string levelName)
	{
		int levelNumber = ConvertLevel (levelName);
		if (levelNumber == 1)
			goldenBalloonL1 = true;
		else if (levelNumber == 2)
			goldenBalloonL2 = true;
		else if (levelNumber == 3)
			goldenBalloonL3 = true;
		else if (levelNumber == 4)
			goldenBalloonL4 = true;
		else if (levelNumber == 5)
			goldenBalloonL5 = true;
		else if (levelNumber == 6)
			goldenBalloonL6 = true;
		else if (levelNumber == 7)
			goldenBalloonL7 = true;
	}
	//return true or false(if we pick the golden balloon or not) for a specific level
	public bool GetGoldBalloon(string levelName)
	{
		int levelNumber = ConvertLevel (levelName);
		if (levelNumber == 1)
			return goldenBalloonL1;
		else if (levelNumber == 2)
			return goldenBalloonL2;
		else if (levelNumber == 3)
			return goldenBalloonL3;
		else if (levelNumber == 4)
			return goldenBalloonL4;
		else if (levelNumber == 5)
			return goldenBalloonL5;
		else if (levelNumber == 6)
			return goldenBalloonL6;
		else if (levelNumber == 7)
			return goldenBalloonL7;
		else
			return false;
	}
}
