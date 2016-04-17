using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour
{

	void Start () {
		StartCoroutine (WaitAndReload ());
	}

	public IEnumerator WaitAndReload () {
		yield return new WaitForSeconds (5);
		GameSceneManager.Instance.RestartScene ();
	}

	void OnGUI () {
		GUI.DrawTexture (
			new Rect (0, 0, Screen.width, Screen.height), 
			Utils.LoadImage("Assets/Resources/Images/game-over.jpg", 1280, 720), 
			ScaleMode.StretchToFill
		);
	}

}