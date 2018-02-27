using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    Rigidbody2D rb2d;
    SpriteRenderer sr;
	Animator anim;
    public Camera cam;
    private float speed = 12f;
    private bool facingRight = true;
	private int livesLeft = 3;
	public Fireball fireball;
	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;
	private float fireTime =0;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        cam.transform.position = new Vector3(rb2d.transform.position.x, cam.transform.position.y, cam.transform.position.z);
		anim = GetComponent<Animator> ();
    }
	
	// Update is called once per frame
	void Update () {
		if (GameController.instance.gameOver == false && (GameController.instance.nextLevel == false)) {
			float move = Input.acceleration.x;
			if (move != 0) {
				rb2d.transform.Translate (new Vector3 (1, 0, 0) * move * speed * Time.deltaTime);
				facingRight = move > 0;
			}
			sr.flipX = !facingRight;
			//
			if (Input.touchCount > 0) {
				fireTime += Time.deltaTime;
				foreach (Touch touch in Input.touches) { //ya que pueden haber multiples touches sucediendo simultaneamente
					if (touch.position.x < Screen.width/2) { //si se presiona en la mitad izquierda de la pantalla, volara
						rb2d.transform.Translate (new Vector3 (0, 1, 0) * speed * Time.deltaTime);
						anim.SetBool ("isOnGround", false);
					} 
					else if (fireTime > 0.1) // si se presiona a la derecha, disparara bolas cada 0.1 seg
					{
						Fire ();
						fireTime = 0;
					}
				}
			}
			anim.SetFloat ("Speed", Mathf.Abs (Input.acceleration.x)); //para que en la animacion cambie la pose del personaje cuando se mueva.
			if (livesLeft == 2)
				heart1.SetActive (false);
			if (livesLeft == 1)
				heart2.SetActive (false);
			if (livesLeft == 0) {
				heart3.SetActive (false);
				GameController.instance.gameOver = true;
				this.gameObject.SetActive (false);
			}
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Points") {// cada vez que choque con una moneda (con tag points) se le sumaran puntos
			GameController.instance.score += 5;
			PlayerPrefs.SetInt ("Score", GameController.instance.score);
			GameController.instance.coinInstances--;
			Destroy (collision.gameObject);
		} else if (collision.gameObject.tag == "Gasoline") {
			Destroy (collision.gameObject);
			GameController.instance.gasCatches++;
			GameController.instance.gasInstances--;
		} else if (collision.gameObject.tag == "Deadly") {
			livesLeft--;
			transform.position = new Vector3 (0, 0, 0);
		} else if (collision.gameObject.tag == "Ground" && (anim.GetFloat ("Speed") > 0)) {
			anim.SetBool ("isOnGround", true);
		}
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground") {
			anim.SetBool ("isOnGround", false);
		}
	}

    private void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.tag == "Deadly") { // cada vez que choque con una banana (con tag deadly) se le restara una vida y se mostrara en 
			//pantalla
			livesLeft--;
			Destroy (collision.gameObject);
			transform.position = new Vector3 (0, 0, 0);
		} 

	}
	public void Fire()
	{
		anim.SetBool ("isFiring", true);
		Vector2 offset = new Vector2(0.3f, 0.1f);
		// Para que el personaje dispare bolas de fuego
		if (sr.flipX == true) {
			fireball.direction = "negative";
		} 
		else {
			fireball.direction = "positive";
		}
		Instantiate (fireball, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
		anim.SetBool ("isFiring", false);
	}
}