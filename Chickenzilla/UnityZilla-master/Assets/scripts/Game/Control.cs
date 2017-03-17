using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour {

    void Start() {
        GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();
    }
    
	void Actions(){
		if (Input.GetButtonDown ("Jump"))
            SceneManager.LoadScene("Game");
        
        else if (Input.GetButtonDown ("Quit")) {
            Application.Quit();
		}
	}

	void Update () {
		Actions ();
	}
}
