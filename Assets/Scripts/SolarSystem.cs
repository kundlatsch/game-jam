using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SolarSystem  {

	public List<Planet> planets {get;}
	public List<Planet> colonized_planets {get;}

	public SolarSystem () {
		planets = new List<Planet>();
		colonized_planets = new List<Planet>();
		// PRECISO CRIAR FUNÇÃO QUE CRIA UM OBJETO PLANET
		// PARA CADA PLANETA NA CENA DO JOGO
		// USAR BUSCA POR TAG PARA FACILITAR
		//GameObject[] number_of_planets = GameObject.FindGameObjectsWithTag("Planet");

		// Planets declaration - manually =(
		// Planet(int size, bool isMain, int type, int travel_cost, int index) 
		planets.Add(new Planet(5, false, 2, 0, 0));
		planets.Add(new Planet(4, false, 0, 0, 1));
		planets.Add(new Planet(7, false, 1, 0, 2));
		planets.Add(new Planet(8, false, 2, 0, 3));
		planets.Add(new Planet(10, false, 2, 0, 4));

		foreach(Planet p in planets){
			colonized_planets.Add(null);
		}

		if(SceneManager.GetActiveScene().name == "InGame"){
			//colonized_planets.Add(planets[0]);
			colonized_planets[0] = planets[0];
			GlobalData.main_planet_id = 0;
		}else{
			colonized_planets[4] = planets[4];
			//colonized_planets.Add(planets[4])
			GlobalData.main_planet_id = 4;
			GlobalData.turns = 50;
			//Debug.Log(GlobalData.main_planet_id);

		}

		//colonized_planets.Add(planets[4]);
		//colonized_planets.Add(planets[1]);
		
		//colonized_planets[4] = planets[4];

	}

	public void colonizePlanet(Planet planet) {
		planets.Add(planet);
	}

 }