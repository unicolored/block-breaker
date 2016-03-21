﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

	public void LoadLevel (string name)
	{
		Debug.Log ("Level load requested for: " + name);
		Application.LoadLevel (name);
		Brick.breackableCount = 0;
	}

	public void QuitRequest ()
	{
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	
	public void LoadNextLevel ()
	{
		Brick.breackableCount = 0;
		Application.LoadLevel (Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed ()
	{
		if (Brick.breackableCount <= 0) {
			LoadNextLevel ();
		}
	}

}
