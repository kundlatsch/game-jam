using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class PlanetsMenuScript : MonoBehaviour {

    private GameObject menu;
    private GameObject colonize_menu;
    private GameObject resources_menu;


    private AudioSource source;
    public AudioClip error_sound;
    public AudioClip upgrade_sound;
    public AudioClip travel_sound;

    void Start () {
        GameObject space_ship = GameObject.Find("SpaceShip");
        source = space_ship.GetComponent<AudioSource>();
		menu = GameObject.Find("PlanetMenu");
		colonize_menu = GameObject.Find("ColonizeMenu");
		resources_menu = GameObject.Find("ResourcesMenu");
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

	 	if(object_name == "QuitColonize"){
	 		if(Input.GetMouseButtonDown(0)) {
	 			colonize_menu.SetActive(false);
	 		}
	 	}

	 	if(object_name == "QuitResources"){
	 		if(Input.GetMouseButtonDown(0)) {
	 			resources_menu.SetActive(false);
	 		}
	 	}

	 	if(object_name == "UpMetal"){
	 		if(Input.GetMouseButtonDown(0)) {
	 			if(GlobalData.active_planet_id == GlobalData.main_planet_id){
	 				if(!(Mining.ss.planets[GlobalData.active_planet_id].upgrade_metal_mine())) {
            			source.PlayOneShot(error_sound);
	 				}
	 				else {
	 					GameObject metal = GameObject.Find("Metal");
	 					Planet ap = Mining.ss.planets[GlobalData.active_planet_id];
 						string metal_string = "lvl " + ap.metal_mine_level + " | +" + ap.metal_up_cost;
 						metal.GetComponent<Text>().text = metal_string;
            			source.PlayOneShot(upgrade_sound);
	 				}
	 				//StartCoroutine(ShowMessage("Abc", 2));
	 			}
	 			else{
            		source.PlayOneShot(error_sound);
	 			}
	 		}

	 	}

	 	if(object_name == "UpDeut"){
	 		if(Input.GetMouseButtonDown(0)) {
	 			if(GlobalData.active_planet_id == GlobalData.main_planet_id){
	 				if(!(Mining.ss.planets[GlobalData.active_planet_id].upgrade_deut_mine())) {
            			source.PlayOneShot(error_sound);
	 				}
	 				else {
	 					GameObject deut = GameObject.Find("Deut");
	 					Planet ap = Mining.ss.planets[GlobalData.active_planet_id];
 						string deut_string = "lvl " + ap.deut_mine_level + " | +" + ap.metal_up_cost;
 						deut.GetComponent<Text>().text = deut_string;
            			source.PlayOneShot(upgrade_sound);
	 				}
	 				//StartCoroutine(ShowMessage("Abc", 2));
	 			}
	 			else{
            		source.PlayOneShot(error_sound);
	 			}
	 		}

	 	}

	 	if(object_name == "Colonize") {
	 		if(Input.GetMouseButtonDown(0)) {
		 		if(GlobalData.deuterium >= GlobalData.travel_cost){
		 			GlobalData.deuterium -= GlobalData.travel_cost;
		 			Mining.ss.colonized_planets[GlobalData.active_planet_id] = Mining.ss.planets[GlobalData.active_planet_id];
		 			//Mining.ss.colonized_planets.Add(Mining.ss.planets[GlobalData.active_planet_id]);
		 			colonize_menu.SetActive(false);
		 			ShipMovement.shipTarget = GameObject.Find("Port" + GlobalData.active_planet_id);
		 			GlobalData.main_planet_id = GlobalData.active_planet_id;
            		source.PlayOneShot(travel_sound);
		 		}
		 		else {
            		source.PlayOneShot(error_sound);
		 		}

			}
		}

		if(object_name == "Travel" || object_name == "TravelT"){
	 		if(Input.GetMouseButtonDown(0)) {
		 		if(GlobalData.deuterium >= GlobalData.travel_cost){
		 			GlobalData.deuterium -= GlobalData.travel_cost;
		 			menu.SetActive(false);
		 			ShipMovement.shipTarget = GameObject.Find("Port" + GlobalData.active_planet_id);
		 			GlobalData.main_planet_id = GlobalData.active_planet_id;
            		source.PlayOneShot(travel_sound);
		 		}
		 		else {
            		source.PlayOneShot(error_sound);
		 		}

			}
	 	}



	}

	

}
