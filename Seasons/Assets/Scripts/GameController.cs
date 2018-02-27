using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour {
	public bool gameOver = false;
	public int score;
	public static GameController instance;
	public SceneChanger sm;
	public Text Pointstxt;
	public Text GO;
	public Text gasCounter;
	public int coinInstances;
	private float timeOver =0;
	public int gasInstances; //solamente se puede crear una instancia de gasolina a la vez, esta variable controlara eso
	public int gasCatches; // indica cuantos botecitos de gasolina se ha recolectado, cuando llegue a 3 pasara a la siguiente escena
	public bool nextLevel = false;
	private float flyTime = 0;
	public string nextscene;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("Highscore", 0);
		instance = this;
		GO.gameObject.SetActive (false);
		Pointstxt.text = PlayerPrefs.GetInt ("Score").ToString (); // para que muestre en pantalla el score actual
		score = PlayerPrefs.GetInt ("Score");
	}

	// Update is called once per frame
	void Update () {
		Pointstxt.text = score.ToString (); // para que muestre en pantalla el score actual
		gasCounter.text = gasCatches.ToString ();
		if (gameOver == true) {
			timeOver += Time.deltaTime;
			GO.gameObject.SetActive (true);
			int currentHighScore = PlayerPrefs.GetInt ("Highscore");
			if (score > currentHighScore) {
				PlayerPrefs.SetInt("Highscore", score); //en el caso que el score actual sea mayor que el highscore guardado
			}
			if (timeOver > 3) {
				sm.OnStartGame ("Main Menu");
				sm.highscore.text = PlayerPrefs.GetInt ("Highscore").ToString(); // para que cambie el texto que aparece en el menu
				// que se guarde el actual como el highscore
				timeOver = 0;
			}
			PlayerPrefs.SetInt("Score", 0);
		} 
		if (nextLevel == true) {
			flyTime += Time.deltaTime;
			int currentHighScore = PlayerPrefs.GetInt ("Highscore");
			if (score > currentHighScore) {
				PlayerPrefs.SetInt("Highscore", score); //en el caso que el score actual sea mayor que el highscore guardado
			}
			if (flyTime > 7f) {
				sm.OnStartGame (nextscene);
				score += 100;
				PlayerPrefs.SetInt ("Score", score);
			}
		}
	}
}
