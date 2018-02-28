using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/** 
 * Modela todo el comportamiento necesario del personaje. 
 * 
 * @author Ana Lucia Hernandez (17138). Esteban Cabrera (17781)
 * 
 **/

public class Character : MonoBehaviour {

    Rigidbody2D rb2d;
    SpriteRenderer sr;
	Animator anim;
    private float speed = 12f;
    private bool facingRight = true;
	private int livesLeft = 3;
	public Fireball fireball; //ya que la artillería puede cambiar (por lo menos de imagen, para ajustarla al ambiente de la escena)
	public GameObject heart1; //cuando va perdiendo vidas se desactivan los corazones en pantalla
	public GameObject heart2;
	public GameObject heart3;
	private float fireTime =0;//limita cuantos tiros en determinado tiempo puede hacer. 
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator> ();
    }
	
	// Update is called once per frame
	void Update () {
		if (GameController.instance.gameOver == false && (GameController.instance.nextLevel == false) && (GameController.instance.winner == false)) {
			float move = Input.acceleration.x;//uso del acelerómetro. 
			if (move != 0) {
				rb2d.transform.Translate (new Vector3 (1, 0, 0) * move * speed * Time.deltaTime);
				facingRight = move > 0;
			}

			sr.flipX = !facingRight;
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
			if (livesLeft == 1) //va desactivando corazones
				heart2.SetActive (false);
			if (livesLeft == 0) {
				heart3.SetActive (false);
				anim.SetBool ("isDead", true);
				rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
				GameController.instance.gameOver = true;
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
		} else if (collision.gameObject.tag == "Gasoline") {// cada vez que atrape gasolina, se guardará la cantidad que tiene. 
			Destroy (collision.gameObject);
			GameController.instance.gasCatches++;
			GameController.instance.gasInstances--;
		} else if (collision.gameObject.tag == "Deadly") {// cada vez que choque con algo que lo dañe, le quitará vidas. 
			livesLeft--;
			transform.position = new Vector3 (0, 0, 0);
		} else if (collision.gameObject.tag == "Ground" && (anim.GetFloat ("Speed") > 0)) {// para que camine (animacion) cuando está en el suelo
			anim.SetBool ("isOnGround", true);
		} else if ((collision.gameObject.tag == "Flag") && (GameController.instance.gasCatches == 3)) {
			this.gameObject.SetActive (false);
			GameController.instance.winner = true;
		} else if (collision.gameObject.tag == "ExtraPoints") {
			GameController.instance.score += 25;
			PlayerPrefs.SetInt ("Score", GameController.instance.score);
			GameController.instance.coinInstances--;
			Destroy (collision.gameObject);
		}
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground") {// para que se de la animación de volar cuando deje de estar en el suelo. 
			anim.SetBool ("isOnGround", false);
		}
	}

    private void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.tag == "Deadly") { // cada vez que choque con una banana (con tag deadly) se le restara una vida y se mostrara en 
			//pantalla
			livesLeft--;
			Destroy (collision.gameObject);
			if (livesLeft != 0)
				transform.position = new Vector3 (0, 0, 0);
		} 

	}
	public void Fire() //para disparar las bolas de fuego. 
	{
		anim.SetBool ("isFiring", true);
		Vector2 offset = new Vector2(0.3f, 0.1f);
		if (sr.flipX == true) {
			fireball.direction = "negative"; //que siempre se disparen al frente del personaje. 
		} 
		else {
			fireball.direction = "positive";
		}
		Instantiate (fireball, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
		anim.SetBool ("isFiring", false); //animación de pug disparando. 
	}
}