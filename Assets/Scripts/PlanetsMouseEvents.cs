using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;


public class PlanetsMouseEvents : MonoBehaviour {
	public GameObject p1;
    public GameObject p2;
    public LineRenderer lineRenderer;
    public bool addRenderer = true;

    public GameObject menu;
    public GameObject colonize_menu;
    public	 GameObject resources_menu;


    private GameObject metal;
 	private GameObject deut;
    private GameObject metalT;
 	private GameObject deutT;
 	private GameObject colonize;
 	private GameObject travelT;

 	private GameObject travel;


 	private Planet ap;

	// Use this for initialization
	void Start () {
		menu = GameObject.Find("PlanetMenu");
 		colonize_menu = GameObject.Find("ColonizeMenu");
 		resources_menu = GameObject.Find("ResourcesMenu");
 		travel = GameObject.Find("Travel");
 			deut = GameObject.Find("Deut");
 			metal = GameObject.Find("Metal");
//		GlobalData.main_planet_id = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	 void OnMouseOver() {
        // find the current main planet (NOT IMPLEMENTED, USE GLOBAL VARIABLE)
		p1 = GameObject.Find("Planet" + GlobalData.main_planet_id);
		//Debug.Log(GlobalData.active_planet_id);
        // p2 = caller object
		p2 = gameObject;

		// This line get the number from the planet name and set the active planet
		// id to this number. Remeber to aways use the name in the correct format!
		GlobalData.active_planet_id = Int32.Parse(gameObject.name.Split('t')[1]);


 		ap = Mining.ss.planets[GlobalData.active_planet_id];
	//	Debug.Log(GlobalData.active_planet_id);


		// This if will only create the line once
        if(addRenderer) {
        	// Create Line renderers in each planet
        	p1.AddComponent(typeof(LineRenderer));
        	p2.AddComponent(typeof(LineRenderer));
 			
 			// Line renderer itself
 			lineRenderer = GetComponent<LineRenderer>();

 			// Line renderer attributes
        	lineRenderer.material.color= Color.white;
        	lineRenderer.SetWidth(1F, 1F);
        	lineRenderer.sortingOrder = 100;

        	// Create the line
        	lineRenderer.SetPosition(0, p1.transform.position);
        	lineRenderer.SetPosition(1, p2.transform.position);
 			
 			addRenderer = false;
 		}

 		// When right click the planet you will open the menu
 		if(Input.GetMouseButtonDown(1) && Mining.ss.colonized_planets[GlobalData.active_planet_id] != null) {//*/ GlobalData.active_planet_id <= (Mining.ss.colonized_planets.Count - 1)) {
 			// Planet Menu config

 			// New position, in the side of the planet
 			Vector3 p = transform.position;
 			Vector3 position = new Vector3(p.x + 30, p.y, p.z);
 			menu.transform.position = position;

 			// Get actual mine levels and up cost
 			string metal_string = "lvl " + ap.metal_mine_level + " | +" + ap.metal_up_cost;

 			string deut_string = "lvl " + ap.deut_mine_level + " | +" + ap.deut_up_cost;

 			// We need to activate the menu before acessing the text

 			menu.SetActive(true);
 			metal.GetComponent<Text>().text = metal_string;
 			deut.GetComponent<Text>().text = deut_string;
 		
 			if(GlobalData.active_planet_id == GlobalData.main_planet_id) {
 				travel.SetActive(false);
 			}
 			else {
 				travel.SetActive(true);
 				GlobalData.travel_cost =  (int)(Vector3.Distance(p1.transform.position, p2.transform.position)) / 4;
 				travelT = GameObject.Find("TravelT");
 				string travel_string = "" + GlobalData.travel_cost;
 				travelT.GetComponent<Text>().text = travel_string;
 			}
 		}

 		else if (Input.GetMouseButtonDown(1)) {
 			Vector3 p = transform.position;
 			Vector3 position = new Vector3(p.x + 30, p.y, p.z);
 			colonize_menu.transform.position = position;
 			//Debug.Log("T1");
 			// Planets on the solar system
 			colonize = GameObject.Find("ColonizeT");
 			GlobalData.travel_cost =  (int)(Vector3.Distance(p1.transform.position, p2.transform.position)) / 2;
 			string travel_string = "Colonize | " + GlobalData.travel_cost;
 			//Debug.Log("T2");

 			colonize_menu.SetActive(true);
 			//Debug.Log("2.5");
 			if(colonize != null){
 				colonize.GetComponent<Text>().text = travel_string;
 			}
 			// Debug.Log("T3");

    	}

    	else if (Input.GetMouseButtonDown(0)) {
 			Vector3 p = transform.position;
 			Vector3 position = new Vector3(p.x - 120, p.y, p.z);
 			resources_menu.transform.position = position;

 			metalT = GameObject.Find("MetalT");
 			deutT = GameObject.Find("DeutT");

 			resources_menu.SetActive(true);

 			if(metalT != null){
	 			metalT.GetComponent<Text>().text = "" + ap.metal;
	 			deutT.GetComponent<Text>().text = "" + ap.deuterium;
	 		}
 			if(GlobalData.invoke_f) {
				InvokeRepeating("UpdateResources", 1f, 1f);
 				GlobalData.invoke_f = false;
 			}
    	}
    }

    void UpdateResources() {
    	Planet rp = Mining.ss.planets[GlobalData.active_planet_id];
		metalT = GameObject.Find("MetalT");
		deutT = GameObject.Find("DeutT");
 		//resources_menu.SetActive(true);

		//Debug.Log(Mining.ss.planets[GlobalData.active_planet_id].ToString());
		if(metalT != null){
			metalT.GetComponent<Text>().text = "" + rp.metal;
			deutT.GetComponent<Text>().text = "" + rp.deuterium;
		}
		//metalT.GetComponent<Text>().text = "" + rp.metal;
		//deutT.GetComponent<Text>().text = "" + rp.deuterium;
    }




    void OnMouseExit()
    {
        // Destroy the current line and reset 
        // addRenderer for the next mouseOver event
        Destroy(lineRenderer);
    	addRenderer = true;
    }

    // PLANETS MENU

    // static SceneGUIGenericMenu () {
    //     SceneView.onSceneGUIDelegate += OnSceneGUI;
    // }
 
    // static void OnSceneGUI (SceneView sceneview) {
    //     if (Event.current.button == 1)
    //     {
    //         if (Event.current.type == EventType.MouseDown)
    //         {              
    //             GenericMenu menu = new GenericMenu();
    //             menu.AddItem(new GUIContent("Item 1"), false, Callback, 1);
    //             menu.AddItem(new GUIContent("Item 2"), false, Callback, 2);
    //             menu.ShowAsContext();
    //         }
    //     }
    // }
 
    // static void Callback (object obj) {
    //     // Do something
    // }

 //    void inGameMenu() {
   
 //    showGameMenu = false;
   
 //    if(!showGameMenu) {
 //        GUI.Box (new Rect(300,80,200,180), "Greenophilia");
 //    //If Level 1 button is clicked , 1st level is loaded
 //    if (GUI.Button (new Rect (320,110,150,20), "Back to game")) {
       
 //        Application.LoadLevel("level2");
 //    }
 
 //    // Make the second button to load second level
 //    if (GUI.Button (new Rect (320,150,150,20), "How to Play")) {
 //        Application.LoadLevel ("Tutorial");
 //    }
   
 //    if (GUI.Button (new Rect(320,190,150,20), "Restart")) {
 //        Application.LoadLevel ("quit");
 //    }
   
 //    print ("Printing in game menu");
 //    }
 
	// }
 
	// void OnGUI () {
   
 //        if (GUI.Button (new Rect (10,10,200,20), "Meet the flashing button")) {
 //            //GUI.Box (Rect (0,0,100,50), "Top-left");
 //            inGameMenu();
                       
 //            // Make a background box
 //        }
	// }
 
}
