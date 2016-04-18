using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour {

	public Font font;

	void OnGUI () {

		MenuButton start = new MenuButton {
			text = "Start Game",
			textFont = font,
			y = (Screen.height - 300) / 2,
			callback = delegate {
				SceneManager.LoadScene("scenes/level0");

				// Typesafety and such
				return true;
			}
		};
		start.Create ();

		MenuButton hard = new MenuButton {
			text = "Hard mode",
			textFont = font,
			y = 100 + (Screen.height - 300) / 2,
			callback = delegate {
				GameEvents.HardMode = true;
				SceneManager.LoadScene("scenes/level0");

				// Typesafety and such
				return true;
			}
		};
		hard.Create ();

		MenuButton quit = new MenuButton {
			text = "Quit Game",
			textFont = font,
			y = 200 + (Screen.height - 300) / 2,
			callback = delegate {
				Application.Quit();

				// Typesafety and such
				return true;
			}
		};
		quit.Create ();

	}

}
