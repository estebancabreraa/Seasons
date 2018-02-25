using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public bool gameOver = false;
	public int score =0;
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
		instance = this;
		GO.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		Pointstxt.text = score.ToString (); // para que muestre en pantalla el score actual
		gasCounter.text = gasCatches.ToString ();
		if (gameOver == true) {
			timeOver += Time.deltaTime;
			GO.gameObject.SetActive (true);
			if (timeOver > 3) {
				sm.OnStartGame ("Main Menu");
				timeOver = 0;
			}
		} 
		if (nextLevel == true) {
			flyTime += Time.deltaTime;
			if (flyTime > 7f) {
				sm.OnStartGame (nextscene);
			}
		}
		
	}
}
