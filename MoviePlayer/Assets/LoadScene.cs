using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour {


	public int sceneIndex;

	// Use this for initialization
	void Start () {
		CameraFade.StartAlphaFade (Color.black, true, 3f, 0f, () => {

		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToMain(){
		CameraFade.StartAlphaFade(Color.black, false, 1f, 0f, () =>
			{
				SceneManager.LoadScene(0);
			});

	}	

	public void OpenSceneWithFader () {
		CameraFade.StartAlphaFade(Color.black, false, 1f, 0f, () =>
			{
				SceneManager.LoadScene(sceneIndex);
			});
	}
}
