using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject Player, Clock;

	public int minutesForRound = 2;

	private Clock clock;
	private PlayerContoller controller;

	public Texture2D fadeTexture;
 	static float fadeSpeed = 0.2f;
 	static int drawDepth = -1000;
 
 	static float alpha = 0.0f; 
	static float fadeDir = 1;

	static bool fade = false;

	// Use this for initialization
	void Start () {
		clock = Clock.GetComponentInChildren<Clock>();
		controller = Player.GetComponent<PlayerContoller>();

		int hours = (int)Mathf.Floor(minutesForRound/60);
		int minutes = minutesForRound%60;

		clock.hour = 11 - hours;
		clock.minutes = 60 - minutes;
		clock.seconds = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(clock.hour == 12){
			controller.Die();
		}
	}

	public static void FadeIn(){ 
		fadeDir = 1;
		alpha = 1.0f;
		fade = true;
	}

	public static void FadeOut(){
		fadeDir = -1;
		alpha = 0.0f;
		fade = true;
	}

	IEnumerator FadeTime(){
		yield return new WaitForSeconds(4f);
		fade = false;
	}

	bool inited = false;
	void OnGUI(){
		if(fade){
			alpha -= fadeDir * fadeSpeed * Time.deltaTime;  
			
			alpha = Mathf.Clamp01(alpha);   
			
			Color thisAlpha = GUI.color;
            thisAlpha.a = alpha;
            GUI.color = thisAlpha;
			
			GUI.depth = drawDepth;
			
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
		}
	}
}
