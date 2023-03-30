using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pogas : MonoBehaviour {

    public void uzGrutibasAinu() {
        SceneManager.LoadScene ("grutibasAina", LoadSceneMode.Single);
    }

	public void uzSpelesAinu() {
		SceneManager.LoadScene ("spelesAina", LoadSceneMode.Single);
	}

}
