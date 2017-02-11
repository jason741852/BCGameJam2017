using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour {

	
	public static Fog fog;

	public static bool countdown = false;

	private float val = 0f;

	public float fogDensityIncreaseRate = .02f;

	public Color fogColor = Color.red;

	void Start(){
		fog = this;
		RenderSettings.fogColor = fogColor;
	}

	void Update(){
		if(countdown){
			val += (fogDensityIncreaseRate * Time.deltaTime);
			RenderSettings.fogDensity = .01f * val;
		}
	}

}
