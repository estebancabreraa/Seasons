using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * Esta sera la clase utilizada para cambiar entre el menú principal y las demás escenas
 * 
 * @author Ana Lucia Hernandez (17138). Esteban Cabrera (17781)
 * 
 **/
public class CoinSpawner : MonoBehaviour {
	
	public float spawnTime = 10f;
	private float elapsedTime = 0f;
	public GameObject coin;

	void Update () {
		if (GameController.instance.gameOver == false && (GameController.instance.nextLevel == false) && (GameController.instance.winner == false)) {

			if (elapsedTime < spawnTime) {
				elapsedTime += Time.deltaTime;
			} else {
				if (GameController.instance.coinInstances <= 5) {//se establece que solo pueden haber 5 monedas en pantalla al mismo tiempo. 
					float random = Random.Range (-9f, 9f);
					Instantiate (coin, new Vector3 (random, 4.5f, 0), Quaternion.identity);	
					GameController.instance.coinInstances++; //al llegar a 5, ya no se crearán instancias de monedas. 
					elapsedTime = 0f;
				}	
			}
		}
	}
}
