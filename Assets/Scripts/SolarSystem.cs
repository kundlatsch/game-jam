using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SolarSystem  {

	public List<Planet> planets;
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
		planets.Add(new Planet(10, true, 2, 0, 0));
		

		colonized_planets.Add(planets[0]);
	}

	public void colonizePlanet(Planet planet) {
		planets.Add(planet);
	}

 }