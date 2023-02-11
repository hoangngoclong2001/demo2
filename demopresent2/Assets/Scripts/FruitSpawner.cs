using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

	private List<GameObject> fruits;

	[SerializeField]
	private AudioSource audioSource;

	private BoxCollider2D col;
	float x1,x2;
	// Use this for initialization
	void Awake () {
		col = GetComponent<BoxCollider2D> ();
		x1 = transform.position.x - col.bounds.size.x / 2f;
		x2 = transform.position.x + col.bounds.size.x / 2f;
	}

	void Start(){
		InitFruits();
		SoundManager.Instance.PlayMusic(audioSource);
		StartCoroutine (SpawnFruit (1f));
	}

	// Update is called once per frame
	void Update () {
		
	}

	void InitFruits()
    {
        fruits = new List<GameObject>
		{
			ObjectPool.SharedInstance.GetPooledObject("Bomb"),
			ObjectPool.SharedInstance.GetPooledObject("Fruit"),
			ObjectPool.SharedInstance.GetPooledObject("FruitOne"),
			ObjectPool.SharedInstance.GetPooledObject("FruitTwo"),
			ObjectPool.SharedInstance.GetPooledObject("FruitThree"),
			ObjectPool.SharedInstance.GetPooledObject("FruitFour")
        };
    }

	IEnumerator SpawnFruit(float time){
		yield return new WaitForSecondsRealtime (time);


		Vector3 temp = transform.position;
		temp.x = Random.Range (x1, x2);

		GameObject fruit = fruits[Random.Range(0, fruits.Count)];
		fruit.transform.position = temp;
		fruit.SetActive (true);
		StartCoroutine (SpawnFruit (Random.Range (1f, 2f)));
	}
}
