using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {
	
	public float spawnTime = 3f;
	public float elapsedTime = 0f;
	public int instances =0;
	public GameObject coin;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (GameController.instance.gameOver == false) {

			if (elapsedTime < spawnTime) {
				elapsedTime += Time.deltaTime;
			} else {
				if (instances <= 5) {
					float random = Random.Range (-9f, 9f);
					Instantiate (coin, new Vector3 (random, 5.1f, 0), Quaternion.identity);	
					instances++;
					elapsedTime = 0f;
				}	
			}
		}
	}
}
