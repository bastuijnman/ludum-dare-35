using UnityEngine;
using System.Collections;

public class CoinPop : MonoBehaviour {

    public int fakeScore;
    private GameObject coin;
    private GameObject score;
    public Sprite score0;
    public Sprite score1;
    public float coinShow = 0.5f;
    // Use this for initialization
    void Start () {
        fakeScore = 0;
        coin = GameObject.Find("Coin");
        score = GameObject.Find("score");
        coin.SetActive(false);
        score.GetComponent<SpriteRenderer>().sprite = score0;
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
        fakeScore += 1;
        coin.SetActive(true);
        StartCoroutine(LateCall());
        score.GetComponent<SpriteRenderer>().sprite = score1;
    }

    IEnumerator LateCall()
    {

        yield return new WaitForSeconds(coinShow);

        coin.SetActive(false);
        //Do Other Stuff Here...
    }

}
