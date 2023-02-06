using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Text scoreText;
    public Text highest;

    public int scoreCount =0 ;
    public int highestCount;

    public bool scoreIncreasing;

    void Start()
    {
        highestCount = PlayerPrefs.GetInt("Highest");
    }

    // Update is called once per frame
    void Update()
    {

        if (scoreCount > highestCount)
        {
            highestCount = scoreCount;
            PlayerPrefs.SetInt("Highest", highestCount);
        }
        scoreText.text = "Score: " + scoreCount;
        highest.text = "Highest; " + highestCount;
   
    }
}
