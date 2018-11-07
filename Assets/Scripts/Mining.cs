using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mining : MonoBehaviour {
	
	private SolarSystem ss;
	public static List<Planet> planets {get; set;}

	void Start () {
		// Aqui é um bom lugar pra iniciar os valores globais (?)
		GlobalData.metal = 100;
		ss = new SolarSystem();
		// Call the first time after 10 seconds,
		// then recall every 1 second
		InvokeRepeating("MineCycle", 1f, 1f);

		ss.colonizePlanet(new Planet(5, false, 0, 0, 0));

	}

	void MineCycle() {
		planets = ss.colonized_planets;
		for(int i = 0; i < planets.Count; i++) {
			planets[i].mine_deut();
			planets[i].mine_metal();
		}
	}

 }