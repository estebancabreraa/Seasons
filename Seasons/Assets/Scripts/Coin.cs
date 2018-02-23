using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (this, 15f);
		
	}
	//public void OnTrigger
	public void OnCollisionEnter2D(Collider2D collider)
	{
		if (collider.tag == "Ground") {
			rb.constraints = RigidbodyConstraints2D.FreezeAll;
		}

	}
}
