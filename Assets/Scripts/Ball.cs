using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
	
	private Paddle paddle;
	
	private Vector3 paddleToBallVector;
	
	private bool hasStarted = false;

	// Use this for initialization
	void Start ()
	{
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		print (paddleToBallVector.y);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (hasStarted == false) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			if (Input.GetMouseButtonDown (0)) {
				hasStarted = true;
				print ("Mouse Left clicked, launch ball");
				this.rigidbody2D.velocity = new Vector2 (2f, 10f);
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision)
	{
		Vector2 tweak = new Vector2 (Random.Range (0f, 0.5f), Random.Range (0f, 0.5f));
		print (tweak);
	
		if (hasStarted) {
			audio.Play ();
			rigidbody2D.velocity += tweak;
		}
	}
}
