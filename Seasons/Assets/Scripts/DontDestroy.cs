using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/** 
 * Esta clase sirve para que la música siga sonando cuando se cambia de escena, y no se reinicie. 
 * 
 * @author Ana Lucia Hernandez (17138). Esteban Cabrera (17781)
 * 
 **/
public class DontDestroy : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Music");
		if (objs.Length > 1) { //ya que cuando se regresa al menú principal, siempre se crea una instancia de música, 
			//que si ya hay una creada quese destruya, así no suena la misma cancion dos veces. 
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (this.gameObject);
	}
}
