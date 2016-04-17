using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {

	BoxCollider2D deathCollider;

	// Initalises the LevelEndpoint
	void Start () {
		deathCollider = gameObject.AddComponent<BoxCollider2D> ();
		deathCollider.offset = Vector3.zero;
	}

	// When a player collides we need to load the next level
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Player") {
			GameEvents.Death ();
		}
	}

}
