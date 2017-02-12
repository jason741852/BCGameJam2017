using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SceneTransition))]
public class FinishCheck : MonoBehaviour {

	SceneTransition sceneTransition;

	void Start(){
		sceneTransition = GetComponent<SceneTransition>();
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Player")){
			sceneTransition.TransitionScene();
		}
	}
}
