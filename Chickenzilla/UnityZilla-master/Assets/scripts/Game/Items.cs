using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    private float item_chance = 30f;
    public bool enable_grape = false;
    private string[] possible_items;
    public GameObject[] itemsPrefabs;

    public GameObject[] itemsPositions;

    public GameObject grapeController;

	void Start () {
        float time = 3f + Random.Range(0, 5);
        Invoke("GenerateItem", time);
        InvokeRepeating("CheckIfItemAppears", time + 5.0f, 1.0f);
    }


    public void GenerateItem(){

        int key = 0;

        int grape_created = grapeController.GetComponent<GrapeController>().actual_grapes;

        int max_grape = grapeController.GetComponent<GrapeController>().max_grapes;

        //50% do item ser uva
        if (enable_grape && grape_created > 0)
        {
            grape_created -= 1;
            key = 3;
        }
        else
            key = Random.Range(0, itemsPrefabs.Length - 1);

        Vector3 position = itemsPositions[Random.Range(0, 2)].transform.position;
        Instantiate(itemsPrefabs[key], position, Quaternion.identity);
        
    }

    public void CheckIfItemAppears() {

        if ((enable_grape && Random.Range(0, 100) < 75) || (Random.Range(0,100) < item_chance)) { 
            GenerateItem();
            ReduceItemChance();
        }
    }	
	
    public void ReduceItemChance()
    {
        item_chance -= 1;
        if (item_chance < 1)
            item_chance = 1;
    }


}
