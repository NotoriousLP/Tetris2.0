using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBloks : MonoBehaviour {

	private float pagLaiks;
	public float lidosanasLaiks = 0.8f;
	public static int augstums = 1080;
	public static int platums = 1080;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			transform.position += new Vector3 (-10, 0, 0);
			if (!derigsGajiens ()) {
				transform.position -= new Vector3 (-10, 0, 0);
			}
			
	    }else if(Input.GetKeyDown(KeyCode.RightArrow)){
			transform.position += new Vector3 (10, 0, 0);
			if (!derigsGajiens ()) {
				transform.position -= new Vector3 (10, 0, 0);
			}
		}

		if(Time.time - pagLaiks > (Input.GetKey(KeyCode.DownArrow) ? lidosanasLaiks/10 : lidosanasLaiks)){
			transform.position += new Vector3(0, -10, 0);
			if (!derigsGajiens ()) {
				transform.position -= new Vector3 (0, -10, 0);
			}
			pagLaiks = Time.time;
		}
	} 


	bool derigsGajiens() {
		
		foreach (Transform children in transform){
			int roundedX = Mathf.RoundToInt(children.transform.position.x);
			int roundedY = Mathf.RoundToInt(children.transform.position.y);

			if(roundedX <0 || roundedX >=platums || roundedY < 0 || roundedY >= augstums){
			   return false;
			}
		}

		return true;
	}
}

		