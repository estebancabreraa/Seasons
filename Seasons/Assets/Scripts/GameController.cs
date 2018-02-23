using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public bool gameOver = false;
	public int score =0;
	public static GameController instance;
	public Text Pointstxt;


	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		Pointstxt.text = GameController.instance.score.ToString (); // para que muestre en pantalla el score actual
		
	}
}
