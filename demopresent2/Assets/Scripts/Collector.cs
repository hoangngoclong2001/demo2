using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {

	private static List<string> tags = new List<string> {"Bomb", "Fruit", "FruitOne", "FruitTwo", "FruitThree", "FruitFour" };

	void OnTriggerEnter2D(Collider2D target){
		if (tags.Contains(target.tag)) {
			target.gameObject.SetActive (false);
		}
	}
}
