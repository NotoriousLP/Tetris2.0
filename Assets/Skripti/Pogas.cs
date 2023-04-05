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
	public void beigtSpeli(){
		//Izies ārā no spēles
		Application.Quit ();
	}
}
