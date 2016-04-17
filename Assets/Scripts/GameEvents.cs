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

	// Die and load game over
	public static void Death() {
		SceneManager.LoadScene ("scenes/game-over");
	}

}