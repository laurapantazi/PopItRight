using UnityEngine;
using System.Collections;

public class ExitGame : MonoBehaviour {

	//method to exit the game
	public void Exit()
	{

		//if the game is running in the unity editor, the method Quit() is ignored
		#if UNITY_EDITOR
		//exit play mode
		UnityEditor.EditorApplication.isPlaying = false;
		//else we are running in a build, we call method Quit()
		#else
		Application.Quit();
		#endif
	}
}
