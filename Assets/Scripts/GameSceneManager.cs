﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public sealed class GameSceneManager {

	// The GameSceneManager instance
	private static readonly GameSceneManager instance = new GameSceneManager();

	// The current scene index
	private int sceneIndex = 0;

	// List of scene names
	private List<string> sceneList = new List<string>(new string[] {
        "scenes/level0",
        "scenes/level1",
        "scenes/level2",
        "scenes/level3",
        "scenes/level4",
        "scenes/level5",
        "scenes/level6",
        "scenes/level7",
        "scenes/level8",
        "scenes/level9"
	});


	// Empty constructors
	static GameSceneManager () { }
	private GameSceneManager () { }

	// Increments the scene index and loads the new scene
	public void NextScene () {
		SceneManager.UnloadScene (sceneList [sceneIndex]);
		sceneIndex++;
		SceneManager.LoadScene (sceneList [sceneIndex]);
	}

	// Unloads and Loads the current scene to restart
	public void RestartScene () {
		SceneManager.UnloadScene (sceneList [sceneIndex]);
		SceneManager.LoadScene (sceneList [sceneIndex]);
	}

	// Gets the singleton instance
	public static GameSceneManager Instance {
		get {
			return instance;
		}
	}
	
}
