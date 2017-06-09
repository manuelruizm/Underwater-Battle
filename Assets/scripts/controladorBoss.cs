using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class controladorBoss : MonoBehaviour {

	// Use this for initialization
	public KeyCode avanzar;
	public KeyCode boton_disparar;
	public float velocidad_lineal, velocidad_angular;
	public GameObject bala;
	private bool paused;
	public int vidas;
	private GameObject torreta1;
	private GameObject torreta2;

	private GameObject menuNivelSuperado;


	void Start () {
		boton_disparar = KeyCode.Space;
		velocidad_lineal = 2;
		velocidad_angular = 100f;
		paused = false;

		torreta1 = transform.Find ("torreta1").gameObject;
		torreta2 = transform.Find ("torreta2").gameObject;

		GameObject canvas = GameObject.Find ("Canvas").gameObject;
		menuNivelSuperado = canvas.transform.Find("nivelSuperado").gameObject;

	}

	void LookAt2D(Vector2 target)
	{
		Vector2 current = new Vector2(transform.position.x, transform.position.y );
		var direction = target - current;
		var angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

	}

	void LookAt2D(Vector2 target, GameObject origin)
	{
		
		Vector2 current = new Vector2(origin.transform.position.x, origin.transform.position.y );
		var direction = target - current;
		var angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
		origin.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

	}

	// Update is called once per frame
	void Update () {

		disparar ();
		GameObject barco = GameObject.Find ("BattleShip");
		if (barco != null) {
			
			LookAt2D (new Vector2 (barco.transform.position.x, barco.transform.position.y), torreta1);
			LookAt2D (new Vector2 (barco.transform.position.x, barco.transform.position.y), torreta2);

		}
	}

	void disparar(){
		if (!paused) {

			System.Random rand = new System.Random ();

			// Este if hace que el disparo del enemigo sea aleatorio. Se puede poner algo que pase con menos probabilidad
			// para que dispare menos.

			if (rand.Next (0, 1000) % 120 == 0) {

				//Buscamos el objeto en la escena:
				GameObject spawn1 = GameObject.Find ("BulletSpawn1");
				GameObject spawn2 = GameObject.Find ("BulletSpawn2");

				//comprobamos que no nos hemos salido:
				Vector2 posicion1 = new Vector2 (spawn1.transform.position.x, spawn1.transform.position.y);
				Vector2 posicion2 = new Vector2 (spawn2.transform.position.x, spawn2.transform.position.y);

				GameObject copia1 = Instantiate (bala, posicion1, Quaternion.identity);
				GameObject copia2 = Instantiate (bala, posicion2, Quaternion.identity);

				copia1.GetComponent<Rigidbody2D> ().velocity = torreta1.transform.right * bala.GetComponent<normalBulletController> ().velocidadBala;
				copia2.GetComponent<Rigidbody2D> ().velocity = torreta2.transform.right * bala.GetComponent<normalBulletController> ().velocidadBala;

			}


		}
	}


	//En caso de que una bala choque destruimos el barco:
	void OnCollisionEnter2D(Collision2D colision){
		if (colision.gameObject.name == "NormalBullet(Clone)") {
			vidas--;
			if (vidas <= 0) {
				Destroy (gameObject);

				// Cuando se destruye el objeto salta el nivel superado
				superarNivel ();

				// Entrar en pausa para que no te puedas eliminar con las balas restantes
				Time.timeScale = 0;
				UnityEngine.Object[] objects = FindObjectsOfType (typeof(GameObject));
				foreach (GameObject go in objects) {
					go.SendMessage ("OnPauseGame", SendMessageOptions.DontRequireReceiver);
				}
				Destroy (colision.gameObject);
			}
		}
	}

	void OnPauseGame ()
	{
		paused = true;
	}
	void OnResumeGame ()
	{
		paused = false;
	}

	void superarNivel() {

		menuNivelSuperado.SetActive (true);
	}


}
