using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapeController : MonoBehaviour {

    private int obtained_grapes = 0;
    public int actual_grapes = 0;
    public int max_grapes = 11;
    private int grapes_necessary = 6;
    public GameObject controller;


    public GameObject player;

    public Sprite[] ui_grapes;

    public GameObject ui_life_bar;
    public GameObject chickenzilla;
    public void GetGrape()
    {
        obtained_grapes += 1;
        UpdateUISpriteRenderer();
        CheckIfGetAllGrapes();
    }

    private void UpdateUISpriteRenderer()
    {
        GetComponent<SpriteRenderer>().sprite = ui_grapes[obtained_grapes - 1];
    }

    public void ExitChickenMode()
    {
        GetComponent<SpriteRenderer>().sprite = null;
        obtained_grapes = 0;
        GameObject.FindGameObjectWithTag("Chickenzilla").GetComponent<chicken_script>().is_leaving = true;
    }


    public void EnterChickenMode()
    {
        actual_grapes = max_grapes;
        controller.GetComponent<Items>().enable_grape = true;
        Instantiate(chickenzilla);
    }


    private void CheckIfGetAllGrapes()
    {
        if (obtained_grapes == grapes_necessary)
        {
            controller.GetComponent<Items>().enable_grape = false;
            player.GetComponent<Player>().GainLife();
            ExitChickenMode();
            
            ui_life_bar.GetComponent<UI_life_controller>().ChangePlayerUIPosition(player.GetComponent<Player>().GetLife());
        }
    }

    private void MakeGrapeAppears()
    {
        controller.GetComponent<Items>().enable_grape = true;
    }



}
