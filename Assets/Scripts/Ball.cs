using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	// Made private to link ball and paddle scripts together
	private Paddle paddle;
	
	// bool (variable type boolean) hasStarted is to keep track if the ball has launched or not
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	
	// Use this for initialization
	void Start () {
		// This line is to programatically link the ball and paddle scripts together
		paddle = GameObject.FindObjectOfType<Paddle>();
		// paddleToBallVector is the balls (this) position - the paddles position
		paddleToBallVector = this.transform.position - paddle.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		// every single frame if the game has NOT (!) started it will lock the ball to the paddle
		if (!hasStarted) {
			// This line locks the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;
		
			// Bottom body of code waits for a mouse press to launch.
			// Bottom line is an if statement that if the left mouse button is clicked
			// the ball is shot at the stated velocity below															
			if(Input.GetMouseButtonDown(0)) {
			print ("Mouse button clicked, launch ball");
			// hasStarted is made true here so the ball gets launched without
			// staying locked to the paddle
			hasStarted = true;
			// You use rigidbody2D because the ball is a rigidbody and the game is 2D
			// Velocity is used when an object is to move at a certain speed (velocity)
			// Rigidbody2D.Velocity is always a Vector2 (2 dimensional vector)
			this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
			}
		}
	}
	
	public void OnCollisionEnter2D (Collision2D collision){
		Vector2 tweak = new Vector2 (Random.Range (0f, 0.3f), Random.Range (0f, 0.3f));
	
		if (hasStarted) {
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody2D>().velocity += tweak;	
		}
	}
}
