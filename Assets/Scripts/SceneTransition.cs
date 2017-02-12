using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

	public int SceneIndex = -1;
	public string SceneName;
	public void TransitionScene(){
		if(SceneName != null){
			SceneManager.LoadScene("SceneName");
		}
		else if(SceneIndex >= 0){
			SceneManager.LoadScene(SceneIndex);
		}
		else{
			Debug.Log("Error: no scene specified to transition to");
		}
	}
}
