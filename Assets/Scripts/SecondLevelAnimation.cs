using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLevelAnimation : MonoBehaviour {

	private bool animate = true;
	private Vector3 finalSize;

	private GameObject ship;
	private GameObject shipTarget;

	private int count = 0;

	// Use this for initialization
	void Start () {
 		ship = GameObject.Find("SpaceShip");
		shipTarget = GameObject.Find("Port0");//ship;
		finalSize = ship.transform.localScale;
		ship.transform.localScale -= ship.transform.localScale;//new Vector3(-3F, -3F, 0);
		ship.transform.localScale += new Vector3(0, 0, 1);

		//News Definitions
		GlobalData.turns = 50;
		//GlobalData.main_planet_id = 4;

	}
	
	// Update is called once per frame
	void Update () {
		if (animate){
			count++;
	    	if(count <= 150) {
	    		ship.transform.localScale += new Vector3(0.02F, 0.02F, 0);
            }
            else {
            	animate = false;
            }
		}
	}
}
