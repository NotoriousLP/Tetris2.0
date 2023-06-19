using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneretBlokus : MonoBehaviour
{
	public GameObject[] Tetrominos;
	public GameObject Generetais;


	void Start () {
		jaunsTetromino ();
	}

	// Update is called once per frame
	public void jaunsTetromino () {
		Instantiate (Tetrominos [Random.Range (0, Tetrominos.Length)], transform.position, Quaternion.identity);
	}


}
