﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TetrisBloks : MonoBehaviour {

	public Vector3 rotacijasPunkts;
	private float pagLaiks;
	public float lidosanasLaiks = 0.8f;
	public static int augstums = 20;
	public static int platums = 15;
	private static Transform[,] grid = new Transform[platums, augstums];


	//Mainīgie, lai var izdabūt citus objektus no citiem skriptiem
	public GeneretBlokus generetBlokus;
	public rezultatuSkaititajs rezultatuskaititajs;
	public Objekti objekti;
	public Teksti teksti;

	void Start () {
		//Sameklē visus objektus no citiem skriptiem, savādāk nekas nestrādās
		rezultatuskaititajs = FindObjectOfType<rezultatuSkaititajs>();
		generetBlokus = FindObjectOfType<GeneretBlokus>();
		objekti = FindObjectOfType<Objekti> ();
		teksti = FindObjectOfType<Teksti> ();

		konfiguretSpeli (objekti.spelesGrutiba);

		objekti.efekts.Pause ();
	}


	void konfiguretSpeli(int grutiba){

		switch (grutiba) {
			
		case 1: //ļoti viegls
			lidosanasLaiks = grutibasAtrums(grutiba);
			break;
		case 2: //viegls
			lidosanasLaiks = grutibasAtrums(grutiba);
			break;
		case 3: //Normāls
			lidosanasLaiks = grutibasAtrums(grutiba);
			break;
		case 4: //Grūts
			lidosanasLaiks = grutibasAtrums(grutiba);
			break;
		case 5: //ļoti Grūts
			lidosanasLaiks = grutibasAtrums(grutiba);
			break;
		case 6: //neiespējami
			lidosanasLaiks = grutibasAtrums(grutiba);
			break;
		default:
			lidosanasLaiks = grutibasAtrums(grutiba);
			break;
		}

	}

	private float grutibasAtrums(int grutiba)
	{
		switch (grutiba)
		{
		case 1:
			return 0.7f;
		case 2:
			return 0.6f;
		case 3:
			return 0.5f;
		case 4:
			return 0.4f;
		case 5:
			return 0.2f;
		case 6:
			return 0.1f;
		default:
			return 0.2f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!objekti.speleBeigusies) {
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				transform.position += new Vector3 (-1, 0, 0);
				if (!derigsGajiens ()) {
					transform.position -= new Vector3 (-1, 0, 0);
				}
			
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				transform.position += new Vector3 (1, 0, 0);
				if (!derigsGajiens ()) {
					transform.position -= new Vector3 (1, 0, 0);
				}
			} else if (Input.GetKeyDown (KeyCode.Z)) {
				objekti.efekts.Play ();
				transform.RotateAround (transform.TransformPoint (rotacijasPunkts), new Vector3 (0, 0, 1), 90);
				if (!derigsGajiens ()) {
					transform.RotateAround (transform.TransformPoint (rotacijasPunkts), new Vector3 (0, 0, 1), -90);
				}
			} else if (Input.GetKeyDown (KeyCode.X)) {
				objekti.efekts.Play ();
				transform.RotateAround (transform.TransformPoint (rotacijasPunkts), new Vector3 (0, 0, 1), -90);
				if (!derigsGajiens ()) {
					transform.RotateAround (transform.TransformPoint (rotacijasPunkts), new Vector3 (0, 0, 1), 90);
				}
			}

			float tagadejaisAtrums = Input.GetKey (KeyCode.DownArrow) ? lidosanasLaiks / 10 : lidosanasLaiks;
			if (Time.time - pagLaiks > tagadejaisAtrums) {
				transform.position += new Vector3 (0, -1, 0);

				if (!derigsGajiens ()) {
					transform.position -= new Vector3 (0, -1, 0);
					this.enabled = false;
					addToGrid ();
					FindObjectOfType<GeneretBlokus> ().jaunsTetromino ();
					parbauditRindas ();
					parbauditSpelesBeigas ();
				}

				pagLaiks = Time.time;
			}
		}
	}
		

	void parbauditSpelesBeigas()
	{
		foreach (Transform child in transform)
		{
			int roundedX = Mathf.RoundToInt(child.transform.position.x);
			int roundedY = Mathf.RoundToInt(child.transform.position.y);

			if (roundedY >= 10 && objekti.vaiIrVirs10 == 0)
			{
				objekti.spelesTema.gameObject.SetActive(false);
				objekti.spelesTema2.gameObject.SetActive(true);
				objekti.vaiIrVirs10++;
			}
			else if (roundedY < 10 && objekti.vaiIrVirs10 > 1) 
			{
				objekti.spelesTema2.gameObject.SetActive(false);
				objekti.spelesTema.gameObject.SetActive(true);
				objekti.vaiIrVirs10--;
			}

			if (roundedX < 0 || roundedX >= platums || roundedY < 0 || roundedY >= augstums)
			{
				objekti.speleBeigusies = true;
				generetBlokus.Generetais.SetActive (false);
				objekti.spelesPanelis.SetActive (true);
				objekti.speleBeidzas.SetActive (true);
				objekti.segVards.gameObject.SetActive (true);
				objekti.okPoga.gameObject.SetActive (true);
				objekti.tekstsNr2.SetActive (true);
				teksti.rezTabTeksts.gameObject.SetActive(true);
				return;
			}

		}
	}

	void parbauditRindas()
	{
		int clearedRows = 0;
		while (true)
		{
			for (int i = augstums - 1; i >= 0; i--)
			{
				if (rindaIr(i))
				{
					clearedRows++;
					objekti.reizesNotiritsLauks++;
					objekti.reizesNotiritsTekstam++;
					dzestRindu(i);
				}
			}


			Debug.Log (objekti.reizesNotiritsLauks);
			if (objekti.reizesNotiritsLauks >= 15) {
				objekti.spelesGrutiba++;
				//Debug.Log ("Nomainās gŗūtība");
				//Debug.Log (objekti.reizesNotiritsLauks);
				objekti.reizesNotiritsLauks = 0;
			}

			if (clearedRows == 0)
				break;
			
			rezultatuskaititajs.pievienotPunktus(clearedRows);
			clearedRows = 0;
		}
	}


	bool rindaIr(int i)
	{
		for (int j = 0; j < platums; j++) {
			if (grid [j, i] == null) return false;
		}
		return true;
	}

	int dzestRindu(int i){
		int clearedRows = 0;
		for (int j = 0; j < platums; j++) {
			Destroy (grid [j, i].gameObject);
			grid [j, i] = null;
		}

		for (int y = i + 1; y < augstums; y++) {
			for (int j = 0; j < platums; j++) {
				if (grid [j, y] != null) {
					grid [j, y - 1] = grid [j, y];
					grid [j, y] = null;
					grid [j, y - 1].transform.position -= new Vector3(0, 1, 0);
				}
			}
		}

		for (int y = i; y < augstums; y++) {
			if (rindaIr (y)) {
				clearedRows++;
			}
		}
		return clearedRows;
	}

	void rindasPaz(int i){
		for (int y = i; y < augstums; y++) {
			
			for (int j = 0; j < platums; j++) {
				if (grid [j, y] != null) {
					
					grid [j, y - 1] = grid [j, y];
					grid [j, y] = null;
					grid [j, y - 1].transform.position = new Vector3 (0, -1, 0);
				}
			}
		}
	}

	void addToGrid()
	{
		foreach (Transform child in transform)
		{
			int roundedX = Mathf.RoundToInt(child.transform.position.x);
			int roundedY = Mathf.RoundToInt(child.transform.position.y);

			if (roundedX >= 0 && roundedX < platums && roundedY >= 0 && roundedY < augstums)
			{
				grid[roundedX, roundedY] = child;
			}
		}

	}

	bool derigsGajiens()
	{
		foreach (Transform children in transform)
		{
			int roundedX = Mathf.RoundToInt(children.transform.position.x);
			int roundedY = Mathf.RoundToInt(children.transform.position.y);

			if (roundedX < 0 || roundedX >= platums || roundedY < 0 || roundedY >= augstums)
			{
				return false;
			}

			if (grid[roundedX, roundedY] != null)
			{
				return false;
			}
		}

		return true;
	}

	public void MuteUnmuteTheme(bool muted){
		if (!muted) {
			objekti.spelesTema.volume = 0f;
			objekti.spelesTema2.volume = 0f;
		} else {
			objekti.spelesTema.volume = 0.1f;
			objekti.spelesTema2.volume = 0.1f;
		}
	}

	public void MuteUnMuteEffect(bool muted){
		if (!muted) {
			objekti.efekts.volume = 0f;
		} else {
			objekti.efekts.volume = 0.1f;
		}
	}
}



		