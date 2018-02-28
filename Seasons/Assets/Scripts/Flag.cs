using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * Ayuda a la animación de la bandera hondeando en la última escena. 
 * 
 * @author Ana Lucia Hernandez (17138). Esteban Cabrera (17781)
 * 
 **/
public class Flag : MonoBehaviour {

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if ((collision.gameObject.tag == "Player") && (GameController.instance.gasCatches == 3)) {
			collision.gameObject.SetActive (false);
			GameController.instance.winner = true;
		} 

	}
}
