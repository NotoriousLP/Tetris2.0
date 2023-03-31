using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBloks : MonoBehaviour {

	private float pagLaiks;
	public float lidosanasLaiks = 0.8f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			transform.position += new Vector3 (-1, 0, 0);
	    }else if(Input.GetKeyDown(KeyCode.RightArrow)){
			transform.position += new Vector3 (1, 0, 0);
		}

		if(Time.time - pagLaiks > (Input.GetKey(KeyCode.DownArrow) ? lidosanasLaiks/10 : lidosanasLaiks)){
			transform.position += new Vector3(0, -1, 0);
			pagLaiks = Time.time;
		}
	} 


}

		