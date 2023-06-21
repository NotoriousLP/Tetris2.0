using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teksti : MonoBehaviour {

	public Text grutiba;

	public Text izdzestasRindas;

	public Text rezultatuTeksts;
	public Text rezTabTeksts;

	public TetrisBloks tetrisBloks;
	public Objekti objekti;
	public rezultatuSkaititajs rezultatuskaititajs;




	// Use this for initialization
	void Start () {
		rezultatuskaititajs = FindObjectOfType<rezultatuSkaititajs>();
		objekti = FindObjectOfType<Objekti> ();
		tetrisBloks = FindObjectOfType<TetrisBloks>();
	}
	
	// Update is called once per frame
	void Update () {
		rezultatuTeksts.text = "Rezultāts: " + rezultatuskaititajs.rezultats; 
		izdzestasRindas.text = "Izdzēstas rindas: " + objekti.reizesNotiritsTekstam;
		rezTabTeksts.text = "Tavi punkti: " + rezultatuskaititajs.rezultats;
		switch (objekti.spelesGrutiba) {
		case 1:
			grutiba.text = "Grūtiba: Ļoti viegla";
			break;
		case 2: grutiba.text = "Grūtiba: Viegla"; 
			break;
		case 3: grutiba.text = "Grūtiba: Normāla"; 
			break;
		case 4: grutiba.text = "Grūtiba: Grūta"; 
			break;
		case 5: grutiba.text = "Grūtiba: Ļoti grūta"; 
			break;
		case 6: grutiba.text = "Grūtiba: Neiespējami"; 
			break;
		}
	}
}
