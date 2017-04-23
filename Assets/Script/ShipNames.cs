using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShipNames {
	public static List<string> passengerShipNames;
	public static List<string> cargoShipNames;


	static ShipNames () {
		passengerShipNames = new List<string> ();

		passengerShipNames.Add ("Churchill");
		passengerShipNames.Add ("Daedalus");
		passengerShipNames.Add ("Explorer");
		passengerShipNames.Add ("Intrepid");
		passengerShipNames.Add ("Moonraker");
		passengerShipNames.Add ("OrionIII");
		passengerShipNames.Add ("X-71");
		passengerShipNames.Add ("Lifeboat");
		passengerShipNames.Add ("Hermes");
		passengerShipNames.Add ("Icarus");
		passengerShipNames.Add ("Albatross");
		passengerShipNames.Add ("Axiom");
		passengerShipNames.Add ("Zero-X");
		passengerShipNames.Add ("Vanguard");
		passengerShipNames.Add ("Theseus");
		passengerShipNames.Add ("Ryvius");


		cargoShipNames = new List<string> ();

		cargoShipNames.Add ("Albatross");
		cargoShipNames.Add ("Valkyrie");
		cargoShipNames.Add ("Yamato");
		cargoShipNames.Add ("VonBraun");
		cargoShipNames.Add ("ShangriLa");
		cargoShipNames.Add ("Ark");
		cargoShipNames.Add ("Nostromo");
		cargoShipNames.Add ("Elysium");
		cargoShipNames.Add ("Avalon");
		cargoShipNames.Add ("Serenity");
		cargoShipNames.Add ("RedDwarf");
		cargoShipNames.Add ("Infinity");
		cargoShipNames.Add ("Affinity");
		cargoShipNames.Add ("Haken");
		cargoShipNames.Add ("EEV");
		cargoShipNames.Add ("EVA");
		cargoShipNames.Add ("Vulture");
		cargoShipNames.Add ("Friede");
		cargoShipNames.Add ("Hopper");
		cargoShipNames.Add ("L&C");
		cargoShipNames.Add ("SA-43");
		cargoShipNames.Add ("Cygnus");
		cargoShipNames.Add ("Orion");
		cargoShipNames.Add ("Orbit");
		cargoShipNames.Add ("Titan");
		cargoShipNames.Add ("Terra");
	}
	public static string GetRandomPassengerShipName () {
		return passengerShipNames [Random.Range (0, passengerShipNames.Count)];
	}

	public static string GetRandomCargoShipName () {
		return cargoShipNames [Random.Range (0, cargoShipNames.Count)];
	}
}
