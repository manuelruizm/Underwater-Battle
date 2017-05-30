using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorEnemigo : MonoBehaviour {

	// Use this for initialization
	public KeyCode avanzar;
	public KeyCode boton_disparar;
	public float velocidad_lineal, velocidad_angular;
	public GameObject bala;



	void Start () {
		avanzar = KeyCode.W;
		boton_disparar = KeyCode.Space;
		velocidad_lineal = 2;
		velocidad_angular = 100f;


	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (boton_disparar)) {
			disparar ();
		}

		Vector3 v = new Vector3 (-90, 0, 0);
		transform.up = GameObject.Find("BattleShip").transform.position - transform.position;
		//transform.Rotate (v);


	}

	void disparar(){
		//Buscamos el objeto en la escena:
		GameObject barco = gameObject.transform.Find("torretaDelantera").gameObject;

		//comprobamos que no nos hemos salido:
		if (barco != null) {
			Vector3 posicion = new Vector3 (barco.transform.position.x, barco.transform.position.y, barco.transform.position.z);

			GameObject copia = Instantiate (bala, posicion, Quaternion.identity);
			copia.GetComponent<Rigidbody2D> ().velocity = -barco.transform.right * bala.GetComponent<normalBulletController> ().velocidadBala;


		}
	}


	//En caso de que una bala choque destruimos el barco:
	void OnCollisionEnter2D(Collision2D colision){
		if (colision.gameObject.name == "NormalBullet(Clone)") {
			Destroy (gameObject);
			Destroy (colision.gameObject);
		}
	}



}
