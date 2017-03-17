using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beach_manager : MonoBehaviour {

	public GameObject wave1;
    public GameObject wave2;

	private float tempo = 2.0f;
	private float intervalo = 0.4f;

    private void Start()
    {
        tempo = 2.0f;
        
    }

    void CriaOnda(){

        int wave = Random.Range(0, 2);
        if (wave == 0)
            Instantiate(wave1, wave1.transform.position + new Vector3(0, Random.Range(-0.5f, 0), 0),  wave1.transform.rotation);
        else
            Instantiate(wave2);

    }


    void Update () {

		if (Time.timeSinceLevelLoad >= tempo) {
			CriaOnda ();
			tempo += intervalo + Random.Range(0.28f, 0.9f);
		}

	}
}
