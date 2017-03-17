using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_life_controller : MonoBehaviour {

    public void ChangePlayerUIPosition(int life) {

        transform.GetChild(4).transform.position = transform.GetChild(life).transform.position;
        if (life > 1)
            transform.GetChild(life).GetComponent<SpriteRenderer>().sortingOrder = -1;

    }



}
