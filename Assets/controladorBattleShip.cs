using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class controladorBattleShip : MonoBehaviour {

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


		float translation = Input.GetAxis("Vertical") * velocidad_lineal;
		float rotation = Input.GetAxis("Horizontal") * velocidad_angular;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate(translation, 0, 0);
		transform.Rotate(0, 0, -rotation);

	}

	void disparar(){
		//comprobamos que no nos hemos salido:
		GameObject spawn = GameObject.Find("BulletSpawn");
		Vector2 posicion = new Vector2 (spawn.transform.position.x, spawn.transform.position.y);

		GameObject copia = Instantiate (bala, posicion, Quaternion.identity);
		copia.GetComponent<Rigidbody2D> ().velocity = transform.right * bala.GetComponent<normalBulletController> ().velocidadBala;

	}


	//En caso de que una bala choque destruimos el barco:
	void OnCollisionEnter2D(Collision2D colision){
		if (colision.gameObject.name == "NormalBullet(Clone)") {
			Destroy (gameObject);
			Destroy (colision.gameObject);
		}
	}


}
