using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chicken_script : MonoBehaviour {

    private bool destination = false;
    private float speed = 4.0f;

    public bool is_leaving;
    public bool forward = true;

	void Start () {
        transform.position = new Vector3(-18f, -1f, 0);
        is_leaving = false;
	}

    void checkPosition()
    {
        if (forward)
        {
            MovingForward();
            if (transform.position.x >= -9)
            {
                forward = false;            
            }
        }


        else if (is_leaving) {
            if (transform.position.x >= -20)
                MovingBackward();
            else
                Destroy(gameObject);
        }
        

    }

    public void MovingBackward()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public void MovingForward()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    void Update () {
        checkPosition();
    }
}