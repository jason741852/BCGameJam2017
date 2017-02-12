using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject Player, Clock;

	private Clock clock;
	private PlayerContoller controller;

	// Use this for initialization
	void Start () {
		clock = Clock.GetComponentInChildren<Clock>();
		controller = Player.GetComponent<PlayerContoller>();
	}
	
	// Update is called once per frame
	void Update () {
		if(clock.hour == 12){
			controller.Die();
		}
	}
}
