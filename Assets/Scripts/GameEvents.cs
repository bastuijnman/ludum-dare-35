using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Timers;

/*
 * Just as an FYI, you should NOT use static classes
 * this is just me taking a shortcut because fuck
 * everything
 */
public static class GameEvents
{

	// OH GOD SO UGLY!!!! Enables hard mode if set to true
	public static bool HardMode = false;

	// Die and load game over
	public static void Death() {

		// When hard mode is active skip to level 1
		if (HardMode) {
			GameSceneManager.Instance.ResetHardMode ();
		}
		SceneManager.LoadScene ("scenes/game-over");
	}

}