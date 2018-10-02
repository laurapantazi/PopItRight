using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour {
	//μέθοδος που καλείτε για να γίνει έξοδος από το παιχνίδι
	public void Exit()
	{
		//εκτελείτε όταν τρέχουμε τα scripts απο το unity editor 
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		//εκτελείτε όταν έχουμε κάνει build το παιχνίδι , και το τρέχουμε για παραδειγμα από καποιο κινητο
		#else
		Application.Quit();
		#endif
	}
		
}
