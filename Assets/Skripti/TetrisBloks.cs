using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBloks : MonoBehaviour {

	public Vector3 rotacijasPunkts;
	private float pagLaiks;
	public float lidosanasLaiks = 0.8f;
	public static int augstums = 20;
	public static int platums = 10;
	private static Transform[,] grid = new Transform[platums, augstums];

	// Use this for initialization
	void Start () {
		
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
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			transform.RotateAround (transform.TransformPoint(rotacijasPunkts), new Vector3 (0, 0, 1), 90);
			if (!derigsGajiens ()) {
				transform.RotateAround (transform.TransformPoint(rotacijasPunkts), new Vector3 (0, 0, 1), -90);
			}
		}

		if(Time.time - pagLaiks > (Input.GetKey(KeyCode.DownArrow) ? lidosanasLaiks/10 : lidosanasLaiks)){
			transform.position += new Vector3(0, -1, 0);
			if (!derigsGajiens ()) {
				transform.position -= new Vector3 (0, -1, 0);
				this.enabled = false;
				addToGrid ();
				parbauditRindas ();
				FindObjectOfType<GeneretBlokus>().jaunsTetromino();
			}
			pagLaiks = Time.time;
		}
	} 

	void parbauditRindas(){
		for (int i = augstums - 1; i >= 0; i--) {
			if (rindaIr (i)) {
				Debug.Log (rindaIr(i));
				dzestRindu (i);
				rindasPaz (i);
			}
		}
	}

	bool rindaIr(int i)
	{
		for (int j = 0; j < platums; j++) {
			if (grid [j, i] == null) return false;
		}
		return true;
	}

	void dzestRindu(int i){
		for (int j = 0; j < platums; j++) {
			Destroy (grid [j, i].gameObject);
			grid [j, i] = null;
		}
	}

	void rindasPaz(int i){
		for (int y = i; y < augstums; y++) {
			
			for (int j = 0; j < platums; j++) {
				if (grid [j, y] != null) {
					
					grid [j, y - 1] = grid [j, y];
					grid [j, y] = null;
					grid [j, y - 1].transform.position = new Vector3 (0, 1, 0);
				}
			}
		}
	}

	void addToGrid(){
		foreach (Transform children in transform) {
			int roundedX = Mathf.RoundToInt(children.transform.position.x);
			int roundedY = Mathf.RoundToInt(children.transform.position.y);

			grid [roundedX, roundedY] = children;
		}
	}


	bool derigsGajiens() {
		
		foreach (Transform children in transform){
			int roundedX = Mathf.RoundToInt(children.transform.position.x);
			int roundedY = Mathf.RoundToInt(children.transform.position.y);

			if(roundedX < 0 || roundedX >=platums || roundedY < 0 || roundedY >= augstums){
				return false;
			}

			if (grid [roundedX, roundedY] != null) {
				return false;
			}
		}

		return true;
	}
}

		