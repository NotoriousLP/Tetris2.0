﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objekti : MonoBehaviour {

	//Priekš spēles funkcijas
	public int reizesNotiritsLauks = 0;
	public int reizesNotiritsTekstam = 0;
	public bool speleBeigusies = false;
	public int spelesGrutiba;
	public int vaiIrVirs10 = 0;


	//Priekš tabulas, kad spēle beidzās
	public GameObject spelesPanelis;
	public GameObject speleBeidzas;
	public InputField segVards;
	public Button okPoga;
	public GameObject tekstsNr2;
	public GameObject rezApko;
	public GameObject rezultatuRaksts;
	public Button tabulasIziesana;


	//Spēles mūzika
	public AudioSource spelesTema;
	public AudioSource spelesTema2;
	public AudioSource efekts;

	//Lai var pilniba funkcionet grūtību spēlei.
	void Awake(){
		spelesGrutiba = PlayerPrefs.GetInt("Grutiba");
	}


}
