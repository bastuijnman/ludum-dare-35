using UnityEngine;
using System.Collections;

public class BlokePath : MonoBehaviour {

	// Use this for initialization
	void Start () {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("BlokePath1"), "delay", 12, "time", 4, "easetype", "linear"));
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("BlokePath2"), "delay", 16, "time", 4, "easetype", "linear"));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
