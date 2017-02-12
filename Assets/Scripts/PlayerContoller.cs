using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(RigidbodyFirstPersonController))]
public class PlayerContoller : MonoBehaviour {

	public AudioSource deathNoise;
	RigidbodyFirstPersonController movementController;
	Animation playerDeath;

	private bool playerAlive = true;
	
	void Start () {
		movementController = GetComponent<RigidbodyFirstPersonController>();
		playerDeath = GetComponentInChildren<Animation>();
		playerDeath.wrapMode = WrapMode.Once;
		GameManager.FadeIn();
	}

	public void Die(){
		if(playerAlive){
			movementController.disableMovement = true;
			playerDeath.Play();
			GameManager.FadeOut();
			deathNoise.Play();
			playerAlive = false;
			StartCoroutine("Restart");
		}
	}

	IEnumerator Restart(){
		yield return new WaitForSeconds(2f);
		SceneTransition.RestartGame();
	}
}
