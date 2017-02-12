using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouAreDead : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            player.gameObject.GetComponent<PlayerContoller>().Die();
        }
    }
}
