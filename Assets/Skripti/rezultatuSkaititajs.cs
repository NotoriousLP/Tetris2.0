using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rezultatuSkaititajs : MonoBehaviour {


	public Objekti objekti;
	public int rezultats;

	void Start(){
		if (rezultats == 0)
		{
			rezultats = 0;
		}
	}



	public void pievienotPunktus(int rindasNotiritas)
	{
		int rezultatuReizinatajs = 100;
		int bazesRezultats = 0;
		int pievienotRezultatam = 0;

		switch (objekti.spelesGrutiba)
		{
		case 1: //ļoti viegls
			rezultatuReizinatajs = 200;
			bazesRezultats = 200;
			break;
		case 2: //viegls
			rezultatuReizinatajs = 300;
			bazesRezultats = 300;

			break;
		case 3: //Normāls
			rezultatuReizinatajs = 400;
			bazesRezultats = 400;
			break;
		case 4: //Grūts
			rezultatuReizinatajs = 500;
			bazesRezultats = 500;
			break;
		case 5: //Ļoti grūts
			rezultatuReizinatajs = 700;
			bazesRezultats = 700;
			break;
		case 6: //Neiespējami
			rezultatuReizinatajs = 1500;
			bazesRezultats = 1500;
			break;
		}
		if (rindasNotiritas == 1) {
			pievienotRezultatam = bazesRezultats;
		} else if (rindasNotiritas == 2) {
			pievienotRezultatam = bazesRezultats + (rindasNotiritas - 1) * rezultatuReizinatajs + 250;
		} else if (rindasNotiritas == 3) {
			pievienotRezultatam = bazesRezultats + (rindasNotiritas - 1) * rezultatuReizinatajs + 500;
		} else if (rindasNotiritas == 4) {
			pievienotRezultatam = bazesRezultats + (rindasNotiritas - 1) * rezultatuReizinatajs + 1000;
		}
		ieliktPunktusRez(pievienotRezultatam);
	}
	public void ieliktPunktusRez(int punkti)
	{
		rezultats = rezultats + punkti;
		Debug.Log ("Rezutlāts: " + rezultats);

	}




}
