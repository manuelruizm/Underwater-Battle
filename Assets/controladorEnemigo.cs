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
		boton_disparar = KeyCode.Space;
		velocidad_lineal = 2;
		velocidad_angular = 100f;


	}

	void LookAt2D(Vector2 target)
	{
		Vector2 current = new Vector2(transform.position.x, transform.position.y );
		var direction = target - current;
		var angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (boton_disparar)) {
			disparar ();
		}

		LookAt2D(new Vector2 (GameObject.Find("BattleShip").transform.position.x, GameObject.Find("BattleShip").transform.position.y));
	}

	void disparar(){
		//Buscamos el objeto en la escena:
		GameObject spawn = GameObject.Find("BulletSpawn2");

		//comprobamos que no nos hemos salido:
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
