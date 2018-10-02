using UnityEngine;
using System.Collections;

public class MusicState {
	private static MusicState inst = null;
	private bool stateSound=true,stateMusic=true;



	private MusicState () {}
	public static MusicState GetMState()
	{
		if (inst == null) 
		{
			inst = new MusicState ();
		}
		return inst;
	}


	public void SetMusicState(bool state)
	{
		if (state) stateMusic=true;
		else stateMusic=false;
	}
	public bool GetMusicState() 
	{
		return stateMusic;
	}

	public void SetSoundState(bool state)
	{
		if (state) stateSound=true;
		else stateSound=false;
	}
	public bool GetSoundState() 
	{
		return stateSound;
	}


}
