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
			bazesRezultats = 200;
			break;
		case 2: //viegls
			rezultatuReizinatajs = 150;
			bazesRezultats = 300;
			break;
		case 3: //Normāls
			rezultatuReizinatajs = 200;
			bazesRezultats = 400;
			break;
		case 4: //Grūts
			rezultatuReizinatajs = 250;
			bazesRezultats = 500;
			break;
		case 5: //Ļoti grūts
			rezultatuReizinatajs = 400;
			bazesRezultats = 700;
			break;
		case 6: //Neiespējami
			rezultatuReizinatajs = 1500;
			bazesRezultats = 1500;
			break;
		}

		pievienotRezultatam = bazesRezultats + (rindasNotiritas - 1) * rezultatuReizinatajs;
		ieliktPunktusRez(pievienotRezultatam);
	}
	public void ieliktPunktusRez(int punkti)
	{
		rezultats = rezultats + punkti;
		Debug.Log ("Rezutlāts: " + rezultats);

	}




}
