using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;
using System.Configuration;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

/** 
 * Modela el comportamiento que tendrán las bolas de fuego (u otra artillería) que usa el personaje para defenderse. 
 * 
 * @author Ana Lucia Hernandez (17138). Esteban Cabrera (17781)
 * 
 **/
public class Fireball : MonoBehaviour {
	private float fireSpeed= 7f;
	public string direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.instance.gameOver == false && (GameController.instance.nextLevel == false) && (GameController.instance.winner == false)) {

			if (direction == "positive") { //para que siempre las bolas se disparen hacia la direccion que está viendo el personaje
				transform.Translate (Vector2.right * fireSpeed * Time.deltaTime);	
			}
			if (direction == "negative") {
				transform.Translate (Vector2.left * fireSpeed * Time.deltaTime);	
			}
			Destroy (gameObject, 3f);//después de determinado tiempo, se destruyen las bolas de fuego. 
		}
	}
}
