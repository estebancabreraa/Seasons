using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;
using System.Configuration;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Fireball : MonoBehaviour {
	private float fireSpeed= 7f;
	public string direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.instance.gameOver == false) {

			if (direction == "positive") {
				transform.Translate (Vector2.right * fireSpeed * Time.deltaTime);	
			}
			if (direction == "negative") {
				transform.Translate (Vector2.left * fireSpeed * Time.deltaTime);	
			}
			Destroy (gameObject, 3f);
		}
	}
}
