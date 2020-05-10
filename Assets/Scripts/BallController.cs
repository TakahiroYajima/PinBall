using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    private float visiblePosZ = -6.5f;
    private GameObject gameoverText;

	// Use this for initialization
	void Start () {
        this.gameoverText = GameObject.Find("GameOverText");
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.z < this.visiblePosZ)
        {
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
	}

    /// <summary>
    /// 衝突したオブジェクトにより得点を加算
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SmallStarTag")
        {
            ScoreManager.Instance.SetScore(ScoreManager.SmallStarScore);
        }
        else if (collision.gameObject.tag == "LargeStarTag")
        {
            ScoreManager.Instance.SetScore(ScoreManager.LargeStarScore);
        }
        else if (collision.gameObject.tag == "SmallCloudTag")
        {
            ScoreManager.Instance.SetScore(ScoreManager.SmallCloudScore);
        }
        else if (collision.gameObject.tag == "LargeCloudTag")
        {
            ScoreManager.Instance.SetScore(ScoreManager.LargeCloudScore);
        }
        else
        {
            
        }
    }
}
