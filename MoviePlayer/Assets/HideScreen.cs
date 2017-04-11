using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideScreen : MonoBehaviour {

	public GameObject blocker;

	// Use this for initialization
	void Start () {
		
	}

	void OnEnable(){
		Invoke ("hideBlocker", 1.0f);
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void hideBlocker(){
		blocker.SetActive (false);
	}
	public void showBlocker(){
		blocker.SetActive (true);
	}
}
