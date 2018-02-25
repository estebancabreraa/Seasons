using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {
	
	private float spawnTime = 10f;
	private float elapsedTime = 0f;
	public GameObject coin;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (GameController.instance.gameOver == false && (GameController.instance.nextLevel == false)) {

			if (elapsedTime < spawnTime) {
				elapsedTime += Time.deltaTime;
			} else {
				if (GameController.instance.coinInstances <= 5) {
					float random = Random.Range (-9f, 9f);
					Instantiate (coin, new Vector3 (random, 4.5f, 0), Quaternion.identity);	
					GameController.instance.coinInstances++;
					elapsedTime = 0f;
				}	
			}
		}
	}
}
