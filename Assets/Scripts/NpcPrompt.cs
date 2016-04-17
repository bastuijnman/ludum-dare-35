using UnityEngine;
using System.Collections;

public class npcPrompt : MonoBehaviour {

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void OnCollisionEnter2D() {
        gameObject.SetActive(true);

    }
}
