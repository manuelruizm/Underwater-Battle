using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalBulletController : MonoBehaviour {

	// Use this for initialization
	public float velocidadBala = 3f;

	private int numColisiones;
	void Start () {

		//this.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f, velocidadBala, 0f);
		numColisiones = 2;
	}
	
	// Update is called once per frame
	void Update () {
		

			

	}



	void OnBecameInvisible(){
		
		Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D colision){


		numColisiones--;

		if (numColisiones == 0)
			Destroy (gameObject);
	}



}
