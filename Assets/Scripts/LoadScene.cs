using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

		//method that loads the scene with name sceneName
		public void LoadByName (string sceneName)
		{
			SceneManager.LoadScene (sceneName);		//load the scene with name sceneName
		}


		//method that loads the scene with name sceneName ONLY if this scene/level is unlocked 
		public void LoadLevel(string sceneName)
		{
			bool levelUnlocked=LevelState.GetLevelState ().GetUnlocked (sceneName); //check if the bool variable levelUnlocked of this scene is true or false
			if (levelUnlocked) SceneManager.LoadScene (sceneName);
		}

	}
