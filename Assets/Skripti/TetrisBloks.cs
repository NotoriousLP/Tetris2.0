﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TetrisBloks : MonoBehaviour {

	public Vector3 rotacijasPunkts;
	private float pagLaiks;
	public float lidosanasLaiks = 0.8f;
	public static int augstums = 20;
	public static int platums = 10;
	private static Transform[,] grid = new Transform[platums, augstums];
	public int grutibasLimenis;

	private GeneretBlokus generetBlokus;

	public rezultatuSkaititajs rezultatuskaititajs;

	private void Awake()
	{
		grutibasLimenis = PlayerPrefs.GetInt("Grutiba"); //Grūtības pakāpe, ko ņem no grutibasIzvele.cs
	}

	void Start () {
		konfiguretSpeli (grutibasLimenis);
		rezultatuskaititajs = FindObjectOfType<rezultatuSkaititajs>();
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
			return 0.8f;
		case 2:
			return 0.6f;
		case 3:
			return 0.4f;
		case 4:
			return 0.3f;
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
			transform.RotateAround (transform.TransformPoint(rotacijasPunkts), new Vector3 (0, 0, 1), 90);
			if (!derigsGajiens ()) {
				transform.RotateAround (transform.TransformPoint(rotacijasPunkts), new Vector3 (0, 0, 1), -90);
			}
		}else if (Input.GetKeyDown (KeyCode.X)) {
			transform.RotateAround (transform.TransformPoint(rotacijasPunkts), new Vector3 (0, 0, 1), -90);
			if (!derigsGajiens ()) {
				transform.RotateAround (transform.TransformPoint(rotacijasPunkts), new Vector3 (0, 0, 1), 90);
			}
		}else if (Input.GetKeyDown(KeyCode.Space))
		{
			Vector3 previousPosition = transform.position;

			while (derigsGajiens())
			{
				transform.position += new Vector3(0, -1, 0);
			}
				
			transform.position += new Vector3(0, 1, 0);


			if (derigsGajiens())
			{
				addToGrid();
				parbauditRindas();
				FindObjectOfType<GeneretBlokus>().jaunsTetromino();
			}
			else
			{

				transform.position = previousPosition;
			}
		}

			
		float currentSpeed = Input.GetKey(KeyCode.DownArrow) ? lidosanasLaiks / 10 : lidosanasLaiks;
		if (Time.time - pagLaiks > currentSpeed)
		{
			transform.position += new Vector3(0, -1, 0);

			if (!derigsGajiens())
			{
				transform.position -= new Vector3(0, -1, 0);
				this.enabled = false;
				addToGrid();
				FindObjectOfType<GeneretBlokus>().jaunsTetromino();
				parbauditRindas();
			}

			pagLaiks = Time.time;
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
					dzestRindu(i);
				}
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


}



		