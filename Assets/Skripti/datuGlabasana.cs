using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.SqliteClient;
using UnityEngine.UI;
using UnityEngine;
using System;


public class datuGlabasana : MonoBehaviour {

	public Objekti objekti;
	public rezultatuSkaititajs rezultatskaititajs;


	public Text segVarduTeksts;
	public Text punktuTeksts;

	public GameObject wireRowPrefab; 
	public RectTransform wireListContainer;
	public ScrollRect scrollRect;
	public Scrollbar scrollbar;

	private string dbName = "URI=file:rezultati.db";

	void Start(){
		createDB ();
	}


	public void createDB(){
		using (var connection = new SqliteConnection (dbName)) {
			connection.Open();

			using (var command = connection.CreateCommand ()) {
				command.CommandText = "CREATE TABLE IF NOT EXISTS rezultati (id integer primary key, segvards VARCHAR(30), punkti INT);";
				command.ExecuteNonQuery ();
			}

			connection.Close ();
		}
	}

	public void pievienotDatus(){
		if (objekti.segVards == null) {
			Debug.LogError("Nav visi dati");
			return;
		}

		using (var connection = new SqliteConnection (dbName)) {
			connection.Open ();

			using (var command = connection.CreateCommand ()) {

				command.CommandText = "INSERT INTO rezultati (segvards, punkti) VALUES ('"+objekti.segVards.text +"' , '"+rezultatskaititajs.rezultats+"');";
				command.ExecuteNonQuery ();
			}
			connection.Close ();
		}
		paraditRezDat ();
		objekti.speleBeidzas.SetActive (false);
		objekti.segVards.gameObject.SetActive (false);
		objekti.okPoga.gameObject.SetActive (false);
		objekti.tekstsNr2.SetActive (false);
		rezultatskaititajs.rezTabTeksts.gameObject.SetActive(false);
		objekti.rezTeksts.SetActive (false);
		objekti.rezApko.SetActive (true);
		objekti.rezultatuRaksts.SetActive (true);
		objekti.tabulasIziesana.gameObject.SetActive (true);
	}
		
	public void paraditRezDat(){

		segVarduTeksts.text = "";
		punktuTeksts.text = "";

		using (var connection = new SqliteConnection (dbName)) {
			connection.Open ();

			using (var command = connection.CreateCommand ()) {
				command.CommandText = "SELECT segvards, punkti FROM rezultati ORDER BY punkti DESc";

				using (IDataReader reader = command.ExecuteReader ()) {

					while (reader.Read ()) {
						segVarduTeksts.text += reader ["segvards"] + "\n\n";
						punktuTeksts.text += reader ["punkti"] + "\n\n";
					}

					reader.Close ();
				}
			}
			connection.Close ();
		}
	}

}

