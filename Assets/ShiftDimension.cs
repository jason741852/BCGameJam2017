using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftDimension : MonoBehaviour {
	public Transform[] platforms;
	private int current_platform;

	void Start(){
		current_platform = 0;
	}
		
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			PlayShiftPrev ();
		} else if (Input.GetKeyDown (KeyCode.RightShift)) {
			PlayShiftNext ();
		}
	}

	void PlayShiftNext(){
		PlayShift (true);
	}

	void PlayShiftPrev(){
		PlayShift (false);
	}

	void PlayShift(bool next){
		int shift_to = current_platform;
		if (next) {
			if (shift_to ==platforms.Length-1) {
				shift_to = 0;
			}
			else {
				shift_to++;
			}
		} else {
			if (shift_to == 0) {
				shift_to = platforms.Length - 1;
			} 
			else {
				shift_to--;
			}

		}

		Vector3 platform = platforms[current_platform].position;
		Vector3 player_position_vector = transform.position - platform;

		Vector3 new_player_position_vector = player_position_vector + platforms[shift_to].position;

		// Test to see if the other dimension teleport to location is open
		Rigidbody rb = GetComponent<Rigidbody>();
		Vector3 old_to_new_point = new_player_position_vector - transform.position;
		RaycastHit[] hits = rb.SweepTestAll (old_to_new_point, old_to_new_point.magnitude, QueryTriggerInteraction.Ignore);
		// If something in way, prevent teleport
		if(hits[hits.Length-1].collider.bounds.Contains(new_player_position_vector)){
			Debug.Log("Shouldnt shift dimension, object in the way");
			return;
		}else{
			// Else, teleport
			transform.position = new_player_position_vector;
			current_platform = shift_to;
		}
	}
}
