﻿using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour{
public GameObject explosion;
public GameObject playerExplosion;
	private GameController gameController;
	public int scoreValue;

	void Start(){
		GameObject gameControllerObject=GameObject.FindGameObjectWithTag("GameController");

		if (gameControllerObject != null)
		{

			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameControllerObject == null) {
			Debug.Log ("Cannot find'gamecontroller'");
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="Boundary")
		{return;}
		Instantiate (explosion, transform.position, transform.rotation);



		if (other.tag == "Player") {
			Instantiate (playerExplosion, transform.position, transform.rotation);
			gameController.GameOver ();

		}
		gameController.AddScore (1);
		gameController.AddScore (scoreValue);
		Destroy (gameObject);
		Destroy (other.gameObject);
	}

}