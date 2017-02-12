using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftDimension : MonoBehaviour {
	public Transform[] platforms;

	public ParticleSystem shift_effect;

	public AudioSource shift_sfx, invalid_teleport, ambience1, ambience2;

	private ParticleSystem effect_instance;
	private int current_platform;

	public float teleport_delay = 3f;
	private bool can_teleport = true;

	void Start(){
		current_platform = 0;
		ambience1.Play();
	}
		
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift) && can_teleport) {
			PlayShiftPrev ();
		} else if (Input.GetKeyDown (KeyCode.RightShift) && can_teleport) {
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
		if(hits.Length > 0 && hits[hits.Length-1].collider.bounds.Contains(new_player_position_vector)){
			Debug.Log("Shouldnt shift dimension, object in the way");
			invalid_teleport.Play();
			return;
		}else{
			// Else, teleport
			StartCoroutine("TeleportDelay");
			shift_sfx.Play();
			transform.position = new_player_position_vector;
			current_platform = shift_to;

			if(shift_to > 0){
				RenderSettings.fog = true;
				Fog.countdown = true;
				ambience2.Play();
			}else{
				RenderSettings.fog = false;
				ambience2.Stop();
			}

			if(shift_effect != null){
				if(effect_instance == null){
					effect_instance = Instantiate(shift_effect, transform.position + transform.forward, Quaternion.identity) as ParticleSystem;
				}
				effect_instance.Play();
				effect_instance.transform.position = transform.position + transform.forward;
			}
		}
			
	}

	IEnumerator TeleportDelay(){
		can_teleport = false;
		yield return new WaitForSeconds(teleport_delay);
		can_teleport = true;
	}
}
