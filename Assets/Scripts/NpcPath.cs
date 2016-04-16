using UnityEngine;
using System.Collections;

public class NpcPath : MonoBehaviour {
    Rigidbody2D playerBody;

    // Use this for initialization
    void Start () {
        // Add a 2D rigid body so we can detect collisions
        playerBody = gameObject.AddComponent<Rigidbody2D>();
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("NpcPath0"), "delay", 0, "speed", 4, "easetype","linear"));
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("NpcPath1"), "delay", 0, "speed", 8, "easetype", "linear"));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
