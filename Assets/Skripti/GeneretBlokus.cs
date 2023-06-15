using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneretBlokus : MonoBehaviour
{
	public GameObject[] Tetrominoes;


	void Start () {
		jaunsTetromino ();
	}

	// Update is called once per frame
	public void jaunsTetromino () {
		Instantiate (Tetrominoes [Random.Range (0, Tetrominoes.Length)], transform.position, Quaternion.identity);
	}
		



}
