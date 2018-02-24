using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    Rigidbody2D rb2d;
    SpriteRenderer sr;
	Animator anim;
    public Camera cam;
    private float speed = 10f;
    private bool facingRight = true;
	private int livesLeft = 3;
	public Fireball fireball;
	private Vector2 offset = new Vector2(0.3f, 0.1f);
	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        cam.transform.position = new Vector3(rb2d.transform.position.x, cam.transform.position.y, cam.transform.position.z);
		anim = GetComponent<Animator> ();
    }
	
	// Update is called once per frame
	void Update () {
		if (GameController.instance.gameOver == false) {
			float move = Input.acceleration.x;
			if (move != 0) {
				rb2d.transform.Translate (new Vector3 (1, 0, 0) * move * speed * Time.deltaTime);
				cam.transform.position = new Vector3 (rb2d.transform.position.x, cam.transform.position.y, cam.transform.position.z);
				facingRight = move > 0;
			}
			sr.flipX = !facingRight;
			//
			if (Input.touchCount > 0) {
				for (int i = 0; i < Input.touchCount; ++i) {
					if (Input.GetTouch (i).phase == TouchPhase.Stationary) {
						rb2d.transform.Translate (new Vector3 (0, 1, 0) * speed * Time.deltaTime);
						cam.transform.position = new Vector3 (rb2d.transform.position.x, cam.transform.position.y, cam.transform.position.z);
					} 
					else
					{
						Fire ();
					}
				}
				/**
				else if (Input.GetTouch (1).position.x > 0 ) {
					Fire ();
				}
				/**
				if (Input.GetTouch (1).phase == TouchPhase.Stationary) {
					rb2d.transform.Translate (new Vector3 (0, 1, 0) * speed * Time.deltaTime);
					cam.transform.position = new Vector3 (rb2d.transform.position.x, cam.transform.position.y, cam.transform.position.z);
				}

				else if (Input.GetTouch (1).phase == TouchPhase.Ended) {
					Fire ();
				}**/
			}
			anim.SetFloat ("Speed", Mathf.Abs (Input.acceleration.x));
			if (livesLeft == 0) {
				heart3.SetActive (false);
				GameController.instance.gameOver = true;
			}
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Points") {
			GameController.instance.score += 5;
			Destroy (collision.gameObject);
		}
	}

    private void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.tag == "Deadly") {
			livesLeft--;
			if (livesLeft == 2)
				heart1.SetActive (false);
			if (livesLeft == 1)
				heart2.SetActive (false);
			Destroy (collision.gameObject);
		} 

	}
	public void Fire()
	{
		// Create the Bullet from the Bullet Prefab
		if (sr.flipX == true) {
			fireball.direction = "negative";
		} 
		else {
			fireball.direction = "positive";
		}
		Instantiate (fireball, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
	}
}