using UnityEngine;
using System.Collections;

public class NpcPath : MonoBehaviour {
    Rigidbody2D playerBody;

    // Use this for initialization
    void Start () {

        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("NpcPath0"), "delay", 0, "time", 4, "easetype", "linear"));
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("NpcPath1"), "delay", 4, "time", 4, "easetype", "linear"));
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("NpcPath2"), "delay", 8, "time", 4, "easetype", "linear"));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
