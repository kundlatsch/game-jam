using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlanetsMenuScript : MonoBehaviour {

    private GameObject menu;

    void Start () {
		menu = GameObject.Find("PlanetMenu");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	 void OnMouseOver() {
	 	string object_name = gameObject.name;
	 	if(object_name == "QuitMenu"){
	 		if(Input.GetMouseButtonDown(0)) {
	 			menu.SetActive(false);
	 		}
	 	}

	 	if(object_name == "UpMetal"){
	 		if(Input.GetMouseButtonDown(0)) {
	 			if(!(Mining.planets[GlobalData.active_planet_id].upgrade_metal_mine()))
	 				Debug.Log("viatomanocu");
	 				//StartCoroutine(ShowMessage("Abc", 2));
	 		}
	 	}
	 }

	

}