﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour {

	//private Text scoreText;


	//private int score = 0;

	//   // Use this for initialization
	//   void Awake () {
	//	scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();


	//       scoreText.text = "Score: ";
	//}
	private ScoreManager theScoreManager;
    private void Start()
    {
        theScoreManager= FindObjectOfType<ScoreManager>();	
    }
    void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Bomb") {
			transform.position = new Vector2 (0, 100);
			target.gameObject.SetActive (false);
			StartCoroutine (RestartGame());
      
        }

		if (target.tag == "Fruit") {
			target.gameObject.SetActive (false);
			theScoreManager.scoreCount = this.theScoreManager.scoreCount + 1;
        
        }
	}

	IEnumerator RestartGame(){
		theScoreManager.scoreIncreasing = false;
		yield return new WaitForSecondsRealtime (2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		theScoreManager.scoreCount= 0;
		theScoreManager.scoreIncreasing = true;	
       
    }

	// Update is called once per frame
	void Update () {
		

	}
}