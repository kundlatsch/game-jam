using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Mining4 : MonoBehaviour {
	
	public static SolarSystem ss {get; set;}
	public static List<Planet> planets {get; set;}
	public static Planet mining_planet {get; set;}

	private GameObject metalUI;
	private GameObject deutUI;
	private GameObject years;
	private GameObject sunE;

	bool endGame = false;
	bool sunEanim = false;
	bool blackHoleAnim = false;
	bool blackHoleAnimC = false;
	bool blackHoleAnimF = false;
	bool firstBHAnim = true;

	Camera camera;
	GameObject sun;
	GameObject sun2;
	GameObject sun3;
	GameObject blackHole;
	GameObject[] pAnim;
	int bh_count = 0;

	GameObject ship;

	int moveSpeed;



	void Awake () {
		// Aqui é um bom lugar pra iniciar os valores globais (?)
		GlobalData.metal = 100;
		ss = new SolarSystem();
		// Call the first time after 10 seconds,
		// then recall every 1 second

		metalUI = GameObject.Find("Metalmt");
		deutUI = GameObject.Find("DeutMT");
		years = GameObject.Find("Years");

		sunE = GameObject.Find("SunE");
		sunE.SetActive(false);

		// End game

		camera = Camera.main;
		sun = GameObject.Find("Sun");
		sun2 = GameObject.Find("Sun2");
		sun3 = GameObject.Find("Sun3");
		blackHole = GameObject.Find("BlackHole");
		ship = GameObject.Find("SpaceShip");

		sun2.SetActive(false);
		sun3.SetActive(false);
		if(SceneManager.GetActiveScene().name == "InGame")
			blackHole.SetActive(false);
		
		// GlobalData.metal = 100;
		// GlobalData.deuterium = 100;
		GlobalData.turns = 10;

		Debug.Log(GlobalData.main_planet_id);

		metalUI.GetComponent<Text>().text = "" + GlobalData.metal;
		deutUI.GetComponent<Text>().text = "" + GlobalData.deuterium;
		years.GetComponent<Text>().text = "" + GlobalData.turns;

		moveSpeed = 5;
		
		InvokeRepeating("MineCycle", 1f, 1f);

	}

	void Update() {
		if(endGame){		
			float step = 500f * Time.deltaTime;
			Vector3 camera_move = new Vector3(sun.transform.position.x, sun.transform.position.y, sun.transform.position.z - 10);
	    	camera.transform.position = Vector3.MoveTowards(camera.transform.position, camera_move	, step);

	    	if(camera.transform.position == camera_move) {
	    		if(GlobalData.main_planet_id != 4) {
	    			sun3.SetActive(false);
					sunE.SetActive(true);
					sunEanim = true;
	    		}
	    		else {
	    			sun3.SetActive(false);
					sunE.SetActive(true);
					blackHoleAnim = true;
	    		}

	    	}
	    }
	    if(sunEanim) {
	    	sunE.transform.localScale += new Vector3(0.5F, 0.5F, 0);
	    	if(sunE.transform.localScale == new Vector3(80F, 80F, 1F)){
	    		
				SceneManager.LoadScene("EndGame", LoadSceneMode.Single);
	    	}
	    }
	    if(blackHoleAnim) {


	    	if(blackHoleAnimC && firstBHAnim) {
	    		blackHoleAnimF = true;
	    		sunE.SetActive(false);
	    		blackHole = GameObject.Find("BlackHole");
	    		blackHole.transform.localScale += new Vector3(0.1F, 0.1F, 0);
	    		bh_count += 1;
	    		if(bh_count == 150){
	    			blackHoleAnimC = false;
	    			firstBHAnim = false;
	    		}
	    	}
	    	else if(sunE.transform.localScale != new Vector3(1F, 1F, 1F) && !blackHoleAnimC){
	    		sunE.transform.localScale -= new Vector3(0.5F, 0.5F, 0);
	    	}
	    	else if(sunE.transform.localScale == new Vector3(1F, 1F, 1F)) {
				sunE.SetActive(false);
				blackHole.SetActive(true);
				blackHoleAnimC = true;
				blackHole.transform.localScale -= new Vector3(14F, 14F, 1F);
	    	}

	    	if (blackHoleAnimF) {
	    		sunE.SetActive(false);
	    		Debug.Log("updatando");
	    		pAnim = GameObject.FindGameObjectsWithTag("Planet");
				float step = 250f * Time.deltaTime;
				
            	foreach(GameObject p in pAnim){
                	p.transform.position = Vector2.MoveTowards(p.transform.position, blackHole.transform.position, step);
	    			p.transform.localScale -= new Vector3(0.015F, 0.035F, 0);
	    			if(p.transform.position == blackHole.transform.position) {
	    				p.SetActive(false);
	    			}
            	}

            	
            	ship.transform.position = Vector2.MoveTowards(ship.transform.position, blackHole.transform.position, step);
	    		ship.transform.localScale -= new Vector3(0.015F, 0.035F, 0);
	    		if(ship.transform.position == blackHole.transform.position) {
	    			ship.SetActive(false);
					SceneManager.LoadScene("EndGame2", LoadSceneMode.Single);
	    		}



	    	}


	    }
	}

	void MineCycle() {
		mining_planet = ss.colonized_planets[GlobalData.main_planet_id];
		
		mining_planet.mine_deut();
		mining_planet.mine_metal();

		GlobalData.turns -= 1;

		if(GlobalData.turns == 20){		
			sun.SetActive(false);
			sun2.SetActive(true);
		}
		else if(GlobalData.turns == 10){
			sun2.SetActive(false);
			sun3.SetActive(true);
		}
		else if(GlobalData.turns == 0) {
			endGame = true;
		}
		else if(GlobalData.turns < 0) {
			GlobalData.turns = 0;
		}
		else if(GlobalData.turns <= 10) {
			years.GetComponent<Text>().color = Color.red;
		}
		else if(GlobalData.main_planet_id == 4) {
			sun.SetActive(false);
			sun2.SetActive(false);
			sun3.SetActive(true);
			endGame = true;
		}


		metalUI.GetComponent<Text>().text = "" + GlobalData.metal;
		deutUI.GetComponent<Text>().text = "" + GlobalData.deuterium;
		years.GetComponent<Text>().text = "" + GlobalData.turns;


	}

 }