using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controlador : MonoBehaviour {

	GameObject MenuPrincipal;
	GameObject MenuOpciones;
	GameObject MenuTutorial;
	GameObject MenuCreditos;
	private AudioSource player;

	public void Start(){

		MenuPrincipal = GameObject.Find ("Menu Principal");
		MenuOpciones = GameObject.Find("Menu Opciones");
		MenuTutorial = GameObject.Find ("Menu Tutorial");
		MenuCreditos = GameObject.Find ("Menu Creditos");

		MenuPrincipal.active = true;
		MenuOpciones.active = false;
		MenuTutorial.active = false;
		MenuCreditos.active = false;

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
		MenuTutorial.active = false;
		MenuCreditos.active = false;
	}

	public void VerMenu(){

		MenuPrincipal.active = true;
		MenuOpciones.active = false;
		MenuTutorial.active = false;
		MenuCreditos.active = false;
	}

	public void VerTutorial(){

		MenuPrincipal.active = false;
		MenuOpciones.active = false;
		MenuTutorial.active = true;
		MenuCreditos.active = false;
	}

	public void VerCreditos(){

		MenuPrincipal.active = false;
		MenuOpciones.active = false;
		MenuTutorial.active = false;
		MenuCreditos.active = true;
	}

	public void EncenderApagar(){
		if (player.isPlaying) {
			player.Pause ();
		} else {
			player.Play ();
		}
	}
}
