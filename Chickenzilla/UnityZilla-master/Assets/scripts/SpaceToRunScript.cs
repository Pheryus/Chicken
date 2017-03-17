using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpaceToRunScript : MonoBehaviour {

	public float next_action = 1.0f;
	public float periodo_tempo = 1.0f;
	public bool transparente = false;
	Image image;
	Color c;


	void Start () {
		image = GetComponent<Image> ();
		c = image.color;
	}

	void AppearTittle(){
		c.a = (transparente) ? 255 : 0;
		image.color = c;
		transparente = !transparente;
	}


	// Update is called once per frame
	void Update () {
		if (Time.time >= next_action) {
			AppearTittle ();
			next_action += periodo_tempo;
		}
	}
}
