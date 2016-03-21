using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
	// http://unity3d.com/learn/tutorials/modules/intermediate/scripting/statics
	static MusicPlayer instance = null;
	
	// http://docs.unity3d.com/Manual/ExecutionOrder.html%20#Script Lifecycle Flowchart
	void Awake ()
	{
		if (instance != null) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}

	// Use this for initialization
	void Start ()
	{
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
}
