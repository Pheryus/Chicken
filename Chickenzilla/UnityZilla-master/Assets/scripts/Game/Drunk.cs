using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drunk {

    private const int drunk_max_space_times = 8;
    private int drunk_num_pressed_space = 0;

    public bool PressSpaceToStopDrunkenness() {
        if (Input.GetButtonDown("Jump")){
            drunk_num_pressed_space += 1;
            if (drunk_num_pressed_space == drunk_max_space_times) {
                drunk_num_pressed_space = 0;
                return false;
            }
        }
        return true;
    }

}
