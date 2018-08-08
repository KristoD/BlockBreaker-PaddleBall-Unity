using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip BallDing;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}
		// timesHit set to zero because it is the beginning of the game
		// and this is the start function so it is set to 0
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Function for collision on a prefab brick
	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint (BallDing, transform.position);
		// boolean (yes or no) isBreakable = this (bricks) has tag equivalent to breakable
		// if block isBreakable, handlehits
		if (isBreakable) {
			HandleHits();
		}
	}
	
	// made to make oncollisionenter2d method tidyer (not a word)
	void HandleHits () {
		// increments timesHit by 1 each time a brick is hit
		// same as timesHit = timesHit + 1;
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		// if timesHit is greater than or equal to maxHits, it destroys the brick
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			// used to destroy the gameobject
			PuffSmoke ();
			Destroy (gameObject);
		} else {
			loadSprites();
		}
	}
	
	void PuffSmoke (){
		GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void loadSprites () {
		int spriteIndex = timesHit - 1;
		// if sprite is looked up and there is nothing, the if statement returns false
		// and the sprite stays the same (made so sprites dont go invisibile)
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
}

