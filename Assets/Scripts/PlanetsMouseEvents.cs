using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlanetsMouseEvents : MonoBehaviour {
	private GameObject p1;
    private GameObject p2;
    private LineRenderer lineRenderer;
    private bool addRenderer = true;

    private GameObject menu;

	// Use this for initialization
	void Start () {
		menu = GameObject.Find("PlanetMenu");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 void OnMouseOver()
    {
        // find the current main planet (NOT IMPLEMENTED, USE GLOBAL VARIABLE)
		p1 = GameObject.Find("Planet0");
        // p2 = caller object
		p2 = gameObject;

		// This line get the number from the planet name and set the active planet
		// id to this number. Remeber to aways use the name in the correct format!
		GlobalData.active_planet_id = Int32.Parse(gameObject.name.Split('t')[1]);



		// This if will only create the line once
        if(addRenderer) {
        	// Create Line renderers in each planet
        	p1.AddComponent(typeof(LineRenderer));
        	p2.AddComponent(typeof(LineRenderer));
 			
 			// Line renderer itself
 			lineRenderer = GetComponent<LineRenderer>();

 			// Line renderer attributes
        	lineRenderer.material.color= Color.white;
        	lineRenderer.SetWidth(0.1F, 0.05F);
        	lineRenderer.sortingOrder = 100;

        	// Create the line
        	lineRenderer.SetPosition(0, p1.transform.position);
        	lineRenderer.SetPosition(1, p2.transform.position);
 			
 			addRenderer = false;
 		}

 		// When right click the planet you will open the menu
 		if(Input.GetMouseButtonDown(1)) {
 			Vector3 p = transform.position;
 			Vector3 position = new Vector3(p.x + 2, p.y, p.z);
 			menu.transform.position = position;
 			menu.SetActive(true);
 		}
		
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
