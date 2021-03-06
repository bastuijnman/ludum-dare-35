﻿using UnityEngine;
using System.Collections;

public class CoinPop : MonoBehaviour {

    public float coinDisplayTIme = 0.5f;

    private GameObject coin;
    private GameObject score;
    private Sprite[] scoreSprites;

    // Use this for initialization
    void Start () {
        scoreSprites = Resources.LoadAll<Sprite>("Tilesets/spritesheet_hud");
        coin = GameObject.Find("Coin");
        score = GameObject.Find("Score");
        coin.SetActive(false);
        score.GetComponent<SpriteRenderer>().sprite = scoreSprites[29];
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player")
        {
            AddScore();
        }
    }

    void AddScore() {
        coin.SetActive(true);
        score.GetComponent<SpriteRenderer>().sprite = scoreSprites[25];
        StartCoroutine(LateCall());
    }

    IEnumerator LateCall()
    {

        yield return new WaitForSeconds(coinDisplayTIme);

        coin.SetActive(false);
        //Do Other Stuff Here...
    }

}
