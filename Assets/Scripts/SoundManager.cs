using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
	public AudioSource soundSource;                   //Drag a reference to the audio source which will play the sound effects.
	public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.
	public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.              
	public AudioClip music,sound;					//Drag a reference to the audio clip 

	void Awake ()
	{
		//Check if there is already an instance of SoundManager
		//if not, set it to this.
		if (instance == null) instance = this;
		//If instance already exists:
		//Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
		else if (instance != this) Destroy (gameObject);
		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad (gameObject);
	}
		
	//play music
	public void PlayMusic()
	{
		//Set the clip of our audio source to the clip passed in as a parameter.
		musicSource.clip = music;
		//Play the clip.
		musicSource.Play ();
	}


	//pause music 
	public void PauseMusic()
	{
		//Set the clip of our audio source to the clip passed in as a parameter.
		musicSource.clip = music;
		//Play the clip.
		musicSource.Pause ();
	}


	//play sound
	public void PlaySound ()
	{
		//Set the clip of our audio source to the clip passed in as a parameter
		soundSource.clip = sound;
		//Play the clip.
		soundSource.Play ();
	}


}
