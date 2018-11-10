using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour {
	GameObject credits;
    GameObject end;
    float speed = 2f;
    Camera camera;

	void Start (){
		credits = GameObject.Find("Credits");
		end = GameObject.Find("End");
	}


	void Update() {
		
		float step = speed * Time.deltaTime;
	    credits.transform.position = Vector3.MoveTowards(credits.transform.position, end.transform.position, step);
	        //camera.transform.Translate(Vector3.right * Time.deltaTime * step * 50, Space.World);
	    
	    if(credits.transform.position == end.transform.position){
	    	if(GlobalData.main_planet_id == 4) {
	    		Debug.Log("oi");
	    		GlobalData.difficult = 5;
	    		SceneManager.LoadScene("InGame2", LoadSceneMode.Single);
	    	}
	    	
	    	else {
				SceneManager.LoadScene("GameMenu", LoadSceneMode.Single);
	    	}

	    }
		
	}



}