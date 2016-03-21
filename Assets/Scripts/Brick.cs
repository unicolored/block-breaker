﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breackableCount = 0;
	public GameObject smoke;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start ()
	{
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breackableCount++;
			print (breackableCount);
		}
		
		timesHit = 0;
		levelManager = LevelManager.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void OnCollisionEnter2D (Collision2D collision)
	{
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.1f);
		if (isBreakable) {
			HandleHits ();
		}
	}
	
	void HandleHits ()
	{
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		//SimulateWin ();
		if (timesHit >= maxHits) {
			Destroy (gameObject);
			breackableCount--;
			GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
			smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer> ().color;
			levelManager.BrickDestroyed ();
		} else {
			LoadSprites ();
		}
	}
	
	void LoadSprites ()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}
	
	// TODO Remove this method once we can actually win!
	void SimulateWin ()
	{
		levelManager.LoadNextLevel ();
	}
}
