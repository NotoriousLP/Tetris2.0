using System.Collections;
using System.Collections.Generic;
﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class skanasSkripts : MonoBehaviour {

	private void Awake(){
		GameObject[] muzikasObj = GameObject.FindGameObjectsWithTag ("gameMusic");
		if (muzikasObj.Length > 1) {
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (this.gameObject);
	}

	void Update(){
		Scene tagadejaisScene = SceneManager.GetActiveScene();
		if (tagadejaisScene.name == "spelesAina") {
			Destroy (this.gameObject);
		}
	}
}
