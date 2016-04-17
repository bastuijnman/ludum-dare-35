using UnityEngine;
using System.Collections;

public class VerticalBooster : MonoBehaviour {

	BoxCollider2D endpointCollider;

	// Initalises the LevelEndpoint
	void Start () {
		endpointCollider = gameObject.AddComponent<BoxCollider2D> ();
		endpointCollider.offset = Vector3.zero;
	}

	// When a player collides we need to load the next level
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Player") {
			Destroy (gameObject);
			GameSceneManager manager = GameSceneManager.Instance;
			Player p = col.gameObject.GetComponent<Player> ();

			p.body.velocity = new Vector2(0, 60);

		}
	}
}
