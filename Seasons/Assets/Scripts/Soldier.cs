using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soldier : MonoBehaviour {

    Rigidbody2D rb2d;
    SpriteRenderer sr;
	Animator anim;
	AudioSource audio;
    public Camera cam;
    private float speed = 5f;
    private float jumpForce = 250f;
    private bool facingRight = true;
	private int livesLeft = 3;
	public Fireball fireball;
	private Vector2 offset = new Vector2(0.3f, 0.1f);

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        cam.transform.position = new Vector3(rb2d.transform.position.x, cam.transform.position.y, cam.transform.position.z);
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
    }
	
	// Update is called once per frame
	void Update () {
		if (GameController.instance.gameOver == false) {
			float moveV = Input.GetAxis ("Vertical");
			if (moveV != 0) {
				rb2d.transform.Translate (new Vector3 (0, 1, 0) * moveV * speed * Time.deltaTime);
				cam.transform.position = new Vector3 (rb2d.transform.position.x, cam.transform.position.y, cam.transform.position.z);
			}
			float move = Input.GetAxis ("Horizontal");
			if (move != 0) {
				rb2d.transform.Translate (new Vector3 (1, 0, 0) * move * speed * Time.deltaTime);
				cam.transform.position = new Vector3 (rb2d.transform.position.x, cam.transform.position.y, cam.transform.position.z);
				facingRight = move > 0;
			}

			sr.flipX = !facingRight;

			if (Input.GetButtonDown ("Jump")) {
				Fire();
			}
			anim.SetFloat ("Speed", Mathf.Abs (move));
			if (livesLeft == 0) {
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