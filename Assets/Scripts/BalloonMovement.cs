using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BalloonMovement : MonoBehaviour {
	private float randomX,randomY,randomZ;
	private Vector3 randomPosition;
	private GameObject newBalloon;
	public GameObject sound;
	private bool soundState;
	private float ds;

	void Start()
	{
		//deactivate the animator component of the balloon gameobject
		gameObject.GetComponent<Animator>().enabled=false;
	}
		
	void Update () {
		Vector3 oldPosition = transform.position;
		//if the balloon gameobject has a material with the name golden ,
		//we change the variable ds , which defines the speed of the gameObject (we make it faster)
		if ((GameState.GetGameState ().GetMovement ()!=0) && gameObject.GetComponent<SpriteRenderer> ().material.name.Contains ("Golden")) 
		{
			ds = 0.05f;
		} else 
		{
			ds = GameState.GetGameState ().GetMovement ();
		}
		transform.position = GameState.GetGameState().BalloonMovement (ds,oldPosition);
		//transform.position = new Vector3 (oldPosition.x,oldPosition.y+ds,oldPosition.z);
	}

	//OnMouseDown method is called when the user has pressed the mouse button while over the GUIElement or Collider.
	void OnMouseDown()
	{		
		//call method GetSoundState from class GameState to check if the sound is enabled or disabled
		soundState = GameState.GetGameState ().GetSoundState ();
		if (GameState.GetGameState ().GetMovement () != 0) {//if button PAUSE hasnt been pressed
			//if we press the mouse button
			if (Input.GetMouseButtonDown (0)) 
			{
				if (soundState) 
				{
					//call the method PlaySound from class SoundManager 
					SoundManager.instance.PlaySound ();
				}
				//get the name of the material from Sprite Renderer component
				string color=gameObject.GetComponent<SpriteRenderer> ().material.name;
				//call method IncreaseScore based on the color of the balloon
				GameState.GetGameState ().IncreaseScore (color); 
				//enable the animation component of the gameobject
				gameObject.GetComponent<Animator> ().enabled = true;
				//destroy the gameobject after time 0.155f
				Destroy (gameObject, 0.155f);
			}
		}
	}
}