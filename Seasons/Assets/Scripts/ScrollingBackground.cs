using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {
	public GameObject personaje;
	public float startingPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			if (personaje.transform.position.x > (transform.position.x+ 26.89f))
			{
				transform.position = new Vector3 ((transform.position.x+ 53.78f), transform.position.y, transform.position.z); 	
			}
	}
}
