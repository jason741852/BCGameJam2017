using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("hi");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.CompareTag("Finish")){
			//TODO: action
		}
	}
}
