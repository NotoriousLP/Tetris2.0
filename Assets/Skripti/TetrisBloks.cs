using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBloks : MonoBehaviour {

	public Vector3 rotacijasPunkts;
	private float pagLaiks;
	public float lidosanasLaiks = 0.8f;
	public static int augstums = 1200;
	public static int platums = 360;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			transform.position += new Vector3 (-10, 0, 0);
			if (!derigsGajiens ()) {
				transform.position -= new Vector3 (-10, 0, 0);
			}
			
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			transform.position += new Vector3 (10, 0, 0);
			if (!derigsGajiens ()) {
				transform.position -= new Vector3 (10, 0, 0);
			}
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			transform.RotateAround (transform.TransformPoint(rotacijasPunkts), new Vector3 (0, 0, 10), 90);
			if (!derigsGajiens ()) {
				transform.RotateAround (transform.TransformPoint(rotacijasPunkts), new Vector3 (0, 0, 10), -90);
			}
		}

		if(Time.time - pagLaiks > (Input.GetKey(KeyCode.DownArrow) ? lidosanasLaiks/10 : lidosanasLaiks)){
			transform.position += new Vector3(0, -10, 0);
			if (!derigsGajiens ()) {
				transform.position -= new Vector3 (0, -10, 0);
				this.enabled = false;
				FindObjectOfType<GeneretBlokus>().jaunsTetromino();
			}
			pagLaiks = Time.time;
		}
	} 


	bool derigsGajiens() {
		
		foreach (Transform children in transform){
			int roundedX = Mathf.RoundToInt(children.transform.position.x);
			int roundedY = Mathf.RoundToInt(children.transform.position.y);

			if(roundedX < -280 || roundedX >=platums || roundedY < -520 || roundedY >= augstums){
			   return false;
			}
		}

		return true;
	}
}

		