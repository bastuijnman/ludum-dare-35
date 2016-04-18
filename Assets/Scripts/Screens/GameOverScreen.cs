using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour
{

	// Start our coroutine
	void Start () {
		StartCoroutine (WaitAndReload ());
	}

	// Reload the active level
	public IEnumerator WaitAndReload () {
		yield return new WaitForSeconds (5);
		GameSceneManager.Instance.RestartScene ();
	}

	// Draw the Game Over screen
	void OnGUI () {
		GUI.DrawTexture (
			new Rect (0, 0, Screen.width, Screen.height), 
			(Texture2D)Resources.Load("Images/game-over"), 
			ScaleMode.StretchToFill
		);
	}

}