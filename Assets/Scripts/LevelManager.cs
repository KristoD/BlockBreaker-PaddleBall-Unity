using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log(name);
		Brick.breakableCount = 0;
		Application.LoadLevel(name);
	}
	
	public void Quit() {
		Debug.Log(name);
		Application.Quit ();
	}
	
	public void LoadNextLevel() {
		Brick.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);

	}
	
	public void BrickDestroyed() {
		if (Brick.breakableCount <= 0) {
			LoadNextLevel ();
		}
	}
}
