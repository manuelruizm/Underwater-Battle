using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffControlador : MonoBehaviour {


	public void cambiarTexto(){

		if (GameObject.Find ("Enciende").GetComponent<Text>().text == "On")
			GameObject.Find ("Enciende").GetComponent<Text>().text = "Off";
		else
			GameObject.Find ("Enciende").GetComponent<Text>().text = "On";
	}
}
