using UnityEngine;
using System.Collections;

public class LevelEndpoint : MonoBehaviour {

	BoxCollider2D endpointCollider;

	// Initalises the LevelEndpoint
	void Start () {
		endpointCollider = gameObject.AddComponent<BoxCollider2D> ();
		endpointCollider.offset = Vector3.zero;
	}

	// When a player collides we need to load the next level
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Player") {
			GameSceneManager manager = GameSceneManager.Instance;
			manager.NextScene ();
		}
	}
}
