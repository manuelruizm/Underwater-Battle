using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseGame : MonoBehaviour {
	
	private GameObject menuPausa;

	void Start () {
		GameObject canvas = GameObject.Find ("Canvas").gameObject;

		menuPausa = canvas.transform.Find("background").gameObject;
		if (menuPausa == null)
			print ("no estaaaaa");
	}

	public void salirPausa(){
		menuPausa.SetActive (false);
		Time.timeScale = 1;
		Object[] objects = FindObjectsOfType (typeof(GameObject));
		foreach (GameObject go in objects) {
			go.SendMessage ("OnResumeGame", SendMessageOptions.DontRequireReceiver);
		}
	}


	public void entrarPausa(){
		Time.timeScale = 0;
		menuPausa.SetActive (true);
		Object[] objects = FindObjectsOfType (typeof(GameObject));
		foreach (GameObject go in objects) {
			go.SendMessage ("OnPauseGame", SendMessageOptions.DontRequireReceiver);
		}
	}

	public void CambiarEscena(string nombre){
		salirPausa ();
		SceneManager.LoadScene (nombre);
	}
	// Update is called once per frame
	void Update () {
		//n caso de que pulsemos la tecla escape

		if(Input.GetKeyDown(KeyCode.Escape)){
			if (menuPausa.active) {	
				salirPausa ();
			} else {
				entrarPausa ();
			}

		}

	}



}
