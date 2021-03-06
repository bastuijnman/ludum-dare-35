﻿using UnityEngine;
using System.Collections;

public class BlokePath : MonoBehaviour {

    public float timeToDeath = 13f;

    private Sprite[] hudSprites;
    private GameObject npc;
    private GameObject heart;
    private GameObject rabbitdead;

    // Use this for initialization
    void Start () {
        rabbitdead = GameObject.Find("rabbitdead");
        rabbitdead.SetActive(false);
        hudSprites = Resources.LoadAll<Sprite>("Tilesets/spritesheet_hud");

        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("BlokePath1"), "delay", 12, "time", 4, "easetype", "linear"));
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("BlokePath2"), "delay", 16, "time", 4, "easetype", "linear"));
        StartCoroutine(LateCall());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator LateCall()
    {
    
        yield return new WaitForSeconds(timeToDeath);
        npc = GameObject.Find("NPC");
        
        heart = GameObject.Find("HeartContainer");
        npc.SetActive(false);
        rabbitdead.SetActive(true);
        heart.GetComponent<SpriteRenderer>().sprite = hudSprites[15];
        //Do Other Stuff Here...
    }
}
