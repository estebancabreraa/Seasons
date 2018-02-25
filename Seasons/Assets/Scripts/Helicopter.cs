using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {
	Rigidbody2D rb;
	Animator anim;
	private float speed = 1f;
	private bool fly = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (fly == true) {
			anim.SetBool ("isFlying", true);
			transform.Translate (new Vector3 (0, 1, 0) * speed * Time.deltaTime);
		}

	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if ((collision.gameObject.tag == "Player") && (GameController.instance.gasCatches == 3)) {
			collision.gameObject.SetActive (false);
			fly = true;
			GameController.instance.nextLevel = true;
		} 

	}
}
