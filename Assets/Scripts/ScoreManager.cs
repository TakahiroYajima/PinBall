using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager> {

    private Text myText;
    private int score = 0;
    private int setedScore = 0;

    public const int SmallStarScore = 1;
    public const int LargeStarScore = 7;
    public const int SmallCloudScore = 5;
    public const int LargeCloudScore = 10;
	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>();
        setedScore = score;
        myText.text = setedScore.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		if(score > setedScore)
        {
            setedScore++;
            myText.text = setedScore.ToString();
        }
	}

    public void SetScore(int plusScore)
    {
        score += plusScore;
    }
}
