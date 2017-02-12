using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Clock))]
public class RoundTime : MonoBehaviour {

	public int roundTimeInMinutes = 3;
	private Clock clock;
	// Use this for initialization
	void Start () {
		clock = GetComponent<Clock>();
		int hours = (int)Mathf.Floor(roundTimeInMinutes/60);
		int minutes = roundTimeInMinutes%60;
		int seconds = 0;

		clock.hour = 11 - hours;
		clock.minutes = 60 - minutes;
		clock.seconds = 0;
	}
	
}
