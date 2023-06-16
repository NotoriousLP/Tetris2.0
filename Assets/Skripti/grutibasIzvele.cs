using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum grutibasPakapes
{
	lotiViegls = 1,
	viegls = 2,
	normals = 3,
	gruts = 4,
	lotiGruts = 5,
	neiespejami = 6
}

public class grutibasIzvele : MonoBehaviour {

	public Button lotiViegls;
	public Button viegls;
	public Button normals;
	public Button gruts;
	public Button lotiGruts;
	public Button neiespejami;
    public int izveletaGrutiba;

	void Start(){
		lotiViegls = GameObject.Find("lotiViegls").GetComponent<Button>();
		viegls = GameObject.Find("viegls").GetComponent<Button>();
		normals = GameObject.Find("normals").GetComponent<Button>();
		gruts = GameObject.Find("gruts").GetComponent<Button>();
		lotiGruts = GameObject.Find("lotiGruts").GetComponent<Button>();
		neiespejami = GameObject.Find("neiespejami").GetComponent<Button>();

		lotiViegls.onClick.AddListener(() => grutibasPakapesIzvele(grutibasPakapes.lotiViegls));
		viegls.onClick.AddListener(() => grutibasPakapesIzvele(grutibasPakapes.viegls));
		normals.onClick.AddListener(() => grutibasPakapesIzvele(grutibasPakapes.normals));
		gruts.onClick.AddListener(() => grutibasPakapesIzvele(grutibasPakapes.gruts));
		lotiGruts.onClick.AddListener(() => grutibasPakapesIzvele(grutibasPakapes.lotiGruts));
		neiespejami.onClick.AddListener(() => grutibasPakapesIzvele(grutibasPakapes.neiespejami));
	}

	void grutibasPakapesIzvele(grutibasPakapes grutiba)
	{
		izveletaGrutiba = (int)grutiba;

		SceneManager.LoadScene("spelesAina", LoadSceneMode.Single);

		PlayerPrefs.SetInt("Grutiba", izveletaGrutiba);

	}


	}

