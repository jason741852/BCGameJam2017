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
	//	logic
		int shift_to = current_platform;
		if (next) {
			// mod length
			// assign to shift to
			if (shift_to ==platforms.Length-1) {
				shift_to = 0;
			}
			else {
				shift_to++;
			}
		} else {
			// subtract 1, check for less than 0
			// assign to shift to
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
		transform.position = new_player_position_vector;
		current_platform = shift_to;
		Debug.Log (shift_to);
	}
}
