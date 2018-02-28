using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/** 
 * Para poder crear aleatoriamente tambos de gasolina. Solamente puede haber un tambo de gasolina en pantalla a la vez. 
 * 
 * @author Ana Lucia Hernandez (17138). Esteban Cabrera (17781)
 * 
 **/
public class GasolineSpawner : MonoBehaviour {
	public GameObject gas;
	private float spawnTime = 15f;
	private float elapsedTime = 2f;

	
	// Update is called once per frame
	void Update () {
		//todo se hará solamente si el personaje no ha muerto (game over), si no ha pasado al siguiente nivel (para que se 
		//detenga todo una vez el personaje sale volando en el helicóptero) y para que se detenga todo cuando gane. 
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
