using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class PlaySnd : MonoBehaviour {

	public AudioSource source;
	public AudioClip beep;

	public void OnCLick(){
		source.PlayOneShot (beep);
	}



}
