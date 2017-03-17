using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkGameObject : MonoBehaviour {

    private bool is_transparent = false;

    public int frames_to_flash = 0;
    private int frame = 0;

	void FixedUpdate () {
        if (frames_to_flash == frame) { 
            GetComponent<SpriteRenderer>().color = (is_transparent) ? new Color(1f, 1f, 1f, 0f) : new Color(1f, 1f, 1f, 1f);
            is_transparent = !is_transparent;
            frame = 0;
        }
        else {
            frame += 1;
        }

    }

    public void TurnOffTransparency() {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }
}
