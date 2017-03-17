using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour {

    private float speed = 15f;

    void Morte()
    {
        Destroy(gameObject);
    }

    public void Movement()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public bool isOffScreen()
    {
        return transform.position.x < -15;
    }

    void Update()
    {
        Movement();

        if (isOffScreen())
            Morte();
    }


}
