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
		rezultatuTeksts.text = "Punkti: " + rezultatuskaititajs.rezultats; 
		izdzestasRindas.text = "Rindas: " + objekti.reizesNotiritsTekstam;
		rezTabTeksts.text = "Tavi punkti: " + rezultatuskaititajs.rezultats;
		switch (objekti.spelesGrutiba) {
		case 1:
			grutiba.text = "Grūtíba: Ļoti viegla";
			break;
		case 2: grutiba.text = "Grūtíba: Viegla"; 
			break;
		case 3: grutiba.text = "Grūtíba: Normāla"; 
			break;
		case 4: grutiba.text = "Grūtíba: Grūta"; 
			break;
		case 5: grutiba.text = "Grūtíba: Ļoti grūta"; 
			break;
		case 6: grutiba.text = "Grūtíba: Neiespējami"; 
			break;
		}
	}
}
