using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour {
	GameObject start_button;
    GameObject shipTarget;
	bool animate = false;
	bool changeScene = false;
	bool moveCamera = true;
    float speed = 7f;
    Camera camera;
    int menuCount;

	void Start (){
		start_button = GameObject.Find("StartButton");
		shipTarget = GameObject.Find("ShipTarget0");
		camera = Camera.main;
		menuCount = 0;
	}


	void Update() {
		if(animate){
			float step = speed * Time.deltaTime;
	        start_button.transform.position = Vector3.MoveTowards(start_button.transform.position, shipTarget.transform.position, step);
	        //camera.transform.Translate(Vector3.right * Time.deltaTime * step * 50, Space.World);
	        if(moveCamera){
	        	Vector3 camera_move = new Vector3(shipTarget.transform.position.x, shipTarget.transform.position.y, shipTarget.transform.position.z - 10);
	        	camera.transform.position = Vector3.MoveTowards(camera.transform.position, camera_move	, step);
	        }
	        if(start_button.transform.position == shipTarget.transform.position){
	        	menuCount += 1;

				if(menuCount == 4){
					shipTarget = GameObject.Find("ShipTarget" + menuCount);
					moveCamera = false;
				}
	        	else if(menuCount == 5){
					changeScene = true;
	        	}
				else{
					shipTarget = GameObject.Find("ShipTarget" + menuCount);
					animate = false;
				}

	        }
		}
		if(changeScene) {
			SceneManager.LoadScene("InGame", LoadSceneMode.Single);
			animate = false;
		}
	}



	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0)) {
			animate = true;
			
		}
	}

}