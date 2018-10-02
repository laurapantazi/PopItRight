using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsHandler : MonoBehaviour {

	private bool button= true;
	public GameObject buttonHandle;				//Drag the gameobject button 
	public string variable;						//define if the script is called from the Music or Sound button		


	void Start()
	{
		buttonHandle.GetComponentInChildren<Text>().text = variable+" : ON"; 
		bool music = GameState.GetGameState ().GetMusicState (); // we get the status of the music , true means isplaying, false is disabled
		bool sound = GameState.GetGameState ().GetSoundState (); // we get the status of the sound , true means is activated, false is disabled
		if (variable.Equals ("MUSIC")) 
		{
			//set the child text of the button "MUSIC ON" if music is enabled ,or "MUSIC OFF" if music is disabled
			if (music) buttonHandle.GetComponentInChildren<Text>().text = variable+" : ON";
			else buttonHandle.GetComponentInChildren<Text>().text = variable+" : OFF";
		}
		else if (variable.Equals ("SOUND")) 
		{
			//set the child text of the button "SOUND ON" if sound is enabled ,or "SOUND OFF" if sound is disabled
			if (sound) buttonHandle.GetComponentInChildren<Text>().text = variable+" : ON";
			else buttonHandle.GetComponentInChildren<Text>().text = variable+" : OFF";
		}
	}

	//we call this method when we press the button to activate/deactivate the music in settings
	public void changeMusicState()
	{
			//if button is true and we press it, it will become false
			if (button) {
				//change the text of the button 
				buttonHandle.GetComponentInChildren<Text>().text = variable+" : OFF";
				button = false;
				//create an instance of the class SoundManager, in order to call the method PauseMusic(), that will pause the background music 
				SoundManager.instance.PauseMusic ();
				//call method SetMusicState from class GameState with parameter false, 
				GameState.GetGameState().SetMusicState (button); 
			} else {
				//if button is false and we press it, it will become true
				//change the text of the button 
				buttonHandle.GetComponentInChildren<Text>().text = variable+" : ON";
				button = true;
				//create an instance of the class SoundManager, in order to call the method PlayMusic(), that will start the background music
				SoundManager.instance.PlayMusic ();
				//call method SetMusicState from class GameState with parameter true,
				GameState.GetGameState().SetMusicState(button);
			}
	}


	//we call this method when we press the button to activate/deactivate the sound in settings
	public void changeSoundState()
	{
		//f button is true and we press it, it will become false
		if (button) {
			//change the text of the button 
			buttonHandle.GetComponentInChildren<Text>().text = variable+" : OFF";
			button = false;
			//call method SetSoundState from class GameState with parameter false
			GameState.GetGameState().SetSoundState (button);
		} else {
			//if button is false and we press it, it will become true
			//change the text of the button 
			buttonHandle.GetComponentInChildren<Text>().text = variable+" : ON";
			button = true;
			//call method SetSoundState from class GameState with parameter true
			GameState.GetGameState().SetSoundState(button);
		}
	}

}
