using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SceneTransition))]
public class GameOver : MonoBehaviour {

	SceneTransition sceneTransition;
	// Use this for initialization
	void Start () {
		sceneTransition = GetComponent<SceneTransition>();
		StartCoroutine("WaitThenReset");
	}
	
	IEnumerator WaitThenReset(){
		yield return new WaitForSeconds(4f);
		sceneTransition.TransitionScene();
	}

	public Texture2D fadeTexture;
 	static float fadeSpeed = 0.2f;
 	static int drawDepth = -1000;
 
 	static float alpha = 1f; 
	static float fadeDir = 1;

	void OnGUI(){
			alpha -= fadeDir * fadeSpeed * Time.deltaTime;  
			
			alpha = Mathf.Clamp01(alpha);   
			
			Color thisAlpha = GUI.color;
            thisAlpha.a = alpha;
            GUI.color = thisAlpha;
			
			GUI.depth = drawDepth;
			
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
		
	}
}
