using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyTrigger : MonoBehaviour {

	public LevelEndDoor doorThisKeyUnlocks;

	public AudioSource unlockSfx;

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Player")){
			if(unlockSfx != null){
				unlockSfx.Play();
			}
			doorThisKeyUnlocks.UnlockDoor();
			gameObject.SetActive(false);
		}
	}
}
