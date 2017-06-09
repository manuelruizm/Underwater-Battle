using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiarEscena : MonoBehaviour {

	private GameObject Nivel1;
	private GameObject Nivel2;

	// Use this for initialization
	void Start () {

		Nivel1 = GameObject.Find ("Juego");
		Nivel2 = GameObject.Find ("nivel2");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CambiarEscena(string nombre){
		SceneManager.LoadScene (nombre);
	}
}
