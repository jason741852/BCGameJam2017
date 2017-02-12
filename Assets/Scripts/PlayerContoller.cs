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
	// Use this for initialization
	void Start () {
		movementController = GetComponent<RigidbodyFirstPersonController>();
		playerDeath = GetComponentInChildren<Animation>();
		playerDeath.wrapMode = WrapMode.Once;
	}

	public void Die(){
		if(playerAlive){
			movementController.disableMovement = true;
			playerDeath.Play();
			playerAlive = false;
			deathNoise.Play();
		}
	}

	public Texture2D fadeTexture;
 	float fadeSpeed = 0.2f;
 	int drawDepth = -1000;
 
 	private float alpha = 0.0f; 
 	private float fadeDir = -1;
	void OnGUI(){
		if(!playerAlive){

		Debug.Log("memdmf");
			alpha -= fadeDir * fadeSpeed * Time.deltaTime;  
			alpha = Mathf.Clamp01(alpha);   
			
			Color thisAlpha = GUI.color;
            thisAlpha.a = alpha;
            GUI.color = thisAlpha;
			
			GUI.depth = drawDepth;
			
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
		}
	}
}
