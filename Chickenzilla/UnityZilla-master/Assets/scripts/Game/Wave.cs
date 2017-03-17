using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	private float speed = 15.0f;

    private const float max_speed = 22.0f;

    private GameObject player_reference;

    public GameObject score_reference;

    private bool get_point; 

    private void Start() {
        int score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().GetScore();
        player_reference = GameObject.FindGameObjectWithTag("Player");
        score_reference = GameObject.FindGameObjectWithTag("Score");
        CheckSpeed(score);
    }

    private void CheckSpeed(int score) {
        if (score < 20)
            return;

        float new_speed = score / 20;
        speed += new_speed;
        if (speed > max_speed)
            speed = max_speed;
        
    }

	void Morte (){
		Destroy (gameObject);
	}

	public void Movement(){
		transform.position += Vector3.left * speed * Time.deltaTime;
	}

    public void CheckIfPlayerJumped() {

        if (!get_point && transform.position.x < player_reference.transform.position.x - 0.15) {
            if (!player_reference.GetComponent<Player>().invunerable)
                score_reference.GetComponent<Score>().AddScore(2);
            get_point = true;
        }

    }


	void Update () {

		Movement ();
        CheckIfPlayerJumped();
		if (transform.position.x < -15)
			Morte ();
	}
}
