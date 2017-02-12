using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

	public int SceneIndex = -1;
	public string SceneName;

	public AudioSource transitionSfx;
	public void TransitionScene(){
		StartCoroutine("TransitionDelay");
	}

	IEnumerator TransitionDelay(){
		var wait = .7f;
		if(transitionSfx != null){
			transitionSfx.Play();
			wait = transitionSfx.clip.length - 0.5f;
		}
		GameManager.FadeOut();

		yield return new WaitForSeconds(wait);
		
		if(SceneName != null && SceneName.Length > 0){
			SceneManager.LoadScene(SceneName);
		}
		else if(SceneIndex >= 0){
			SceneManager.LoadScene(SceneIndex);
		}
		else{
			Debug.Log("Error: no scene specified to transition to");
		}
	}

	public static void RestartGame(){
		SceneManager.LoadScene(0);
	}
}
