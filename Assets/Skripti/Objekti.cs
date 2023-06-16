using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objekti : MonoBehaviour {

	public GameObject spelesPanelis;
	public GameObject speleBeidzas;
	public InputField segVards;
	public Button okPoga;
	public GameObject tekstsNr2;

	public GameObject rezTeksts;
	public GameObject rezApko;

	public int reizesNotiritsLauks = 0;
	public bool speleBeigusies = false;

	public int spelesGrutiba;

	void Awake(){
		spelesGrutiba = PlayerPrefs.GetInt("Grutiba");
	}

}
