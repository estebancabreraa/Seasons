using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasolineSpawner : MonoBehaviour {
	public GameObject gas;
	private float spawnTime = 15f;
	private float elapsedTime = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.instance.gameOver == false && (GameController.instance.nextLevel == false) && (GameController.instance.winner == false)) {

			if (elapsedTime < spawnTime) {
				elapsedTime += Time.deltaTime;
			} else {
				if (GameController.instance.gasInstances < 1 && (GameController.instance.gasCatches < 3)) {
					float random = Random.Range (-9f, 9f);
					Instantiate (gas, new Vector3 (random, 4.5f, 0), Quaternion.identity);
					GameController.instance.gasInstances++;
					elapsedTime = 0f;	
				}
			}
		}
	}
}
