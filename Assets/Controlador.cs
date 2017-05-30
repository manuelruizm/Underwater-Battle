using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controlador : MonoBehaviour {

	GameObject MenuPrincipal;
	GameObject MenuOpciones;
	private AudioSource player;

	public void Start(){

		MenuPrincipal = GameObject.Find ("Menu Principal");
		MenuOpciones = GameObject.Find("Menu Opciones");

		MenuPrincipal.active = true;
		MenuOpciones.active = false;

		player = GetComponent<AudioSource> ();
		
	}

	public void CambiarEscena(string nombre){
		SceneManager.LoadScene (nombre);
	}

	public void Salir(){
		Application.Quit ();
	}

	public void VerOpciones(){

		MenuPrincipal.active = false;
		MenuOpciones.active = true;
	}

	public void VerMenu(){

		MenuPrincipal.active = true;
		MenuOpciones.active = false;
	}

	public void EncenderApagar(){
		if (player.isPlaying) {
			player.Pause ();
		} else {
			player.Play ();
		}
	}
}
