using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

	// Camera follow target
	public GameObject target;

	// Update the camera position to the target position
	void Update () {
		Vector3 targetPosition = target.transform.position;
		transform.position = new Vector3 (targetPosition.x, targetPosition.y, -1);
	}
}
