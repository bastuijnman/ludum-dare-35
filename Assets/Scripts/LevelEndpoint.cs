using UnityEngine;
using System.Collections;

public class LevelEndpoint : MonoBehaviour {

	BoxCollider2D endpointCollider;
	public bool isFirstLevel = false;

	// Initalises the LevelEndpoint
	void Start () {
		endpointCollider = gameObject.AddComponent<BoxCollider2D> ();
		endpointCollider.offset = Vector3.zero;
	}

	// When a player collides we need to load the next level
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Player") {
			GameSceneManager manager = GameSceneManager.Instance;

			// If we have the first level we can just "restart" the first scene in the manager
			if (isFirstLevel) {
				manager.RestartScene ();
			} else {
				manager.NextScene ();
			}
		}
	}
}
