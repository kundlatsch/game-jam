using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour {
	public static GameObject shipTarget {get; set;}
    GameObject ship;
    float speed = 60f;

	// Use this for initialization
	void Start () {
 		ship = GameObject.Find("SpaceShip");
		shipTarget = GameObject.Find("Port0");//ship;
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		if((ship.transform.position.x >= shipTarget.transform.position.x && (SceneManager.GetActiveScene().name == "InGame")) ||
			(ship.transform.position.x < shipTarget.transform.position.x && (SceneManager.GetActiveScene().name == "InGame2") ))
			ship.transform.localRotation = Quaternion.Euler(0, 0, 0);
		else
			ship.transform.localRotation = Quaternion.Euler(0, 180, 0);
        ship.transform.position = Vector2.MoveTowards(ship.transform.position, shipTarget.transform.position, step);
		
	}
}
