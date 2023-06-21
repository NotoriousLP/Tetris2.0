using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneretBlokus : MonoBehaviour
{
	public GameObject[] Tetrominos;
	public GameObject Generetais;

	void Start () {
		jaunsTetromino (); //Ar šo startu uzsāk Bloku uzģenerēšanu
	}


	public void jaunsTetromino () {
		//Šī rinda, uztaisa nejaušu tetromino no GameObject[] Tetromino objektiem.
		Instantiate (Tetrominos [Random.Range (0, Tetrominos.Length)], transform.position, Quaternion.identity); 
	}
}

