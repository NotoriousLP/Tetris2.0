using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objekti : MonoBehaviour {

	//Priekš spēles funkcijas
	public int reizesNotiritsLauks = 0;
	public int reizesNotiritsTekstam = 0;
	public bool speleBeigusies = false;
	public bool irNolikts = false;

	public bool spaceNospiests = false;
	public float spaceSpiezLaiks;


	public int spelesGrutiba;


	//Priekš tabulas, kad spēle beidzās
	public GameObject spelesPanelis;
	public GameObject speleBeidzas;
	public InputField segVards;
	public Button okPoga;
	public GameObject tekstsNr2;
	public GameObject rezTeksts;
	public GameObject rezApko;
	public GameObject rezultatuRaksts;
	public Button tabulasIziesana;

	public AudioSource spelesTema;
	public AudioSource spelesTema2;



	//Lai var izdabūt grūtību spēlei.
	void Awake(){
		spelesGrutiba = PlayerPrefs.GetInt("Grutiba");
	}


}
