using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

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
		if (GameController.instance.gameOver == false && (GameController.instance.nextLevel == false)) {
			if (isRight == true) {

				transform.Rotate (0, 0, rotSpeed);
				transform.position += Vector3.right * speed * Time.deltaTime;
			} else {
				transform.Rotate (0, 0, rotSpeed);
				transform.position += Vector3.left * speed * Time.deltaTime;
			}
			Destroy (this, 5f);
		}
		
	}
	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Fireball") {
			Destroy (this.gameObject);
			Destroy (collider.gameObject);
		} 
	}

}
