using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoJumpScript : MonoBehaviour {

    GameObject player_reference;

    private void Start() {
        player_reference = GameObject.FindGameObjectWithTag("Player");
    }

   

	void FixedUpdate () {
        if (!player_reference.GetComponent<Player>().is_drunk)
            Destroy(gameObject);
	}
}
