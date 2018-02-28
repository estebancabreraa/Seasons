using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/** 
 * Generador de objetos que lastiman al personaje (se le puso banana porque fue el primer objeto dañino creado, pero pueden ser otras cosas)
 * 
 * @author Ana Lucia Hernandez (17138). Esteban Cabrera (17781)
 * 
 **/
public class BananaSpawner : MonoBehaviour {

	public float spawnTime = 1.5f;
	public float elapsedTime = 0f;
	public Banana banana;


	// Update is called once per frame
	void Update () {
		if (GameController.instance.gameOver == false && (GameController.instance.nextLevel == false) && (GameController.instance.winner == false)) {

			if (elapsedTime < spawnTime) {
				elapsedTime += Time.deltaTime;
			} else {
				float randomy = Random.Range (5.23f, 0.29f);
				int randomx = Random.Range (0, 2); //para que se generen aleatoriamente a la derecha de la pantalla o a la izquierda. 
				if (randomx == 0) {
					banana.isRight = true;
					Instantiate (banana, new Vector3 (-11, randomy, 0), Quaternion.identity);	
				} 
				else {
					banana.isRight = false;
					Instantiate (banana, new Vector3 (11, randomy, 0), Quaternion.identity);
				}
				elapsedTime = 0f;	
			}
		}
	}
}
