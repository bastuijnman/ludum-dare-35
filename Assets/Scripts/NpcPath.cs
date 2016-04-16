using UnityEngine;
using System.Collections;

public class NpcPath : MonoBehaviour {

	// Use this for initialization
	void Start () {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("NpcPath1"), "delay", 1, "speed", 8, "easetype","linear"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
