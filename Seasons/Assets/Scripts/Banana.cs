using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

/** 
 * Modela comportamiento de objetos que dañan al personaje. 
 * 
 * @author Ana Lucia Hernandez (17138). Esteban Cabrera (17781)
 * 
 **/
public class Banana : MonoBehaviour {
	public float speed = 5f;
	public float rotSpeed = 5f;
	public bool isRight;// para verificar si el personaje se encuentra a la derecha o a la izquierda de donde la banana aparecera
	//asi la banana se dirigira a la direccion general del personaje

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.instance.gameOver == false && (GameController.instance.nextLevel == false) && (GameController.instance.winner == false)) {
			if (isRight == true) {

				transform.Rotate (0, 0, rotSpeed);
				transform.position += Vector3.right * speed * Time.deltaTime;
			} else {
				transform.Rotate (0, 0, rotSpeed);
				transform.position += Vector3.left * speed * Time.deltaTime;
			}
			Destroy (this.gameObject, 5f);
		}
		
	}
	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Fireball") { //si choca con artillería del personaje, que se destruya. 
			Destroy (this.gameObject);
			Destroy (collider.gameObject);
		} 
	}

}
