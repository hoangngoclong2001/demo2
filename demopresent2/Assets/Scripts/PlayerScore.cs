using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour {


	private static List<string> tags = new List<string>{ "Fruit","FruitOne","FruitTwo","FruitThree","FruitFour" };

	//private Text scoreText;


	//private int score = 0;

	//   // Use this for initialization
	//   void Awake () {
	//	scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();


	//       scoreText.text = "Score: ";
	//}

	[SerializeField]
	private AudioSource audioSource;

	private ScoreManager theScoreManager;
    private void Start()
    {
		SoundManager.Instance.Play(audioSource);
        theScoreManager= FindObjectOfType<ScoreManager>();	
    }
    void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Bomb") {
			transform.position = new Vector2 (0, 100);
			target.gameObject.SetActive (false);
			StartCoroutine (RestartGame());
      
        }

		if (tags.Contains(target.tag)) {
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
