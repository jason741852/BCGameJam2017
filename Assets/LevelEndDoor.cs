using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndDoor : MonoBehaviour {

	public GameObject Door, Teleporter;

	public bool StartWithDoorOpen = true;

	bool doorOpen = false;

	// Use this for initialization
	void Start () {
		Teleporter.SetActive(false);
		if(StartWithDoorOpen){
			UnlockDoor();
		}
	}
	
	public void UnlockDoor(){
		if(!doorOpen){
			OpenDoor();
			Teleporter.SetActive(true);
		}
	}

	void OpenDoor(){
		Door.transform.Rotate(new Vector3(0,-120f, 0));
		doorOpen = true;
	}
}
