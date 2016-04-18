using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameWinScreen : MonoBehaviour {

	public Font font;

	// Draw the Game Over screen
	void OnGUI () {
		
		GUI.DrawTexture (
			new Rect (0, 0, Screen.width, Screen.height), 
			(Texture2D)Resources.Load("Images/game-win"), 
			ScaleMode.StretchToFill
		);

		MenuButton start = new MenuButton {
			text = "To Menu",
			textFont = font,
			y = 100 + (Screen.height - 200) / 2,
			callback = delegate {
				SceneManager.LoadScene("scenes/start");

				// Typesafety and such
				return true;
			}
		};
		start.Create ();

		MenuButton quit = new MenuButton {
			text = "Quit Game",
			textFont = font,
			y = 200 + (Screen.height - 200) / 2,
			callback = delegate {
				Application.Quit();

				// Typesafety and such
				return true;
			}
		};
		quit.Create ();

	}

}
