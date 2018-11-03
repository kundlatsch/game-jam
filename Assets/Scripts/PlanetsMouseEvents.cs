using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsMouseEvents : MonoBehaviour {
	private GameObject p1;
    private GameObject p2;
    private LineRenderer lineRenderer;
    private bool addRenderer = true;
 
	// Use this for initialization
	void Start () {
		
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
    }

    void OnMouseExit()
    {
        // Destroy the current line and reset 
        // addRenderer for the next mouseOver event
        Destroy(lineRenderer);
    	addRenderer = true;
    }
}
