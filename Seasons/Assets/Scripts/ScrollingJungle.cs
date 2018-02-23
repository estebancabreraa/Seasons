using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingJungle
 : MonoBehaviour {
	public GameObject personaje;
	public float startingPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			if (personaje.transform.position.x > (transform.position.x+ 20f))
			{
				transform.position = new Vector3 ((transform.position.x+ 40f), transform.position.y, transform.position.z); 	
			}
	}
}
