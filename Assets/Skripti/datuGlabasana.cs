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
	public Transform wireListContainer;
	public Scrollbar scrollbarVertical; 

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
		objekti.rezApko.SetActive (true);
		objekti.rezTeksts.SetActive (true);
	}

	/*public void paraditRezDatus()
	{
		// Clear the existing content in the Scroll View
		foreach (Transform child in wireListContainer)
		{
			Destroy(child.gameObject);
		}

		using (var connection = new SqliteConnection(dbName))
		{
			connection.Open();

			using (var command = connection.CreateCommand())
			{
				command.CommandText = "SELECT segvards, punkti FROM rezultati";

				using (IDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						string segvards = reader["segvards"].ToString();
						string punkti = reader["punkti"].ToString();

						// Create a new WireRow object for each data entry
						GameObject wireRow = new GameObject("WireRow", typeof(RectTransform));
						wireRow.transform.SetParent(wireListContainer, false);

						// Add a Text component to the WireRow object
						Text wireRowText = wireRow.AddComponent<Text>();

						// Concatenate the segvards and punkti values
						string wireRowContent = segvards + " - " + punkti;
						wireRowText.text = wireRowContent;

						// Set the size of the WireRow object
						RectTransform wireRowRectTransform = wireRow.GetComponent<RectTransform>();
						RectTransform wireListContainerRectTransform = wireListContainer.GetComponent<RectTransform>();
						wireRowRectTransform.sizeDelta = new Vector2(wireListContainerRectTransform.rect.width, 100f); // Adjust the height as needed

						// Add layout elements and adjust positioning as needed
						// ...
					}

					reader.Close();
				}
			}

			connection.Close();
		}

		ScrollRect scrollRect = wireListContainer.GetComponentInParent<ScrollRect>();
		LayoutRebuilder.ForceRebuildLayoutImmediate(scrollRect.content);
		Canvas.ForceUpdateCanvases();
		scrollRect.Rebuild(CanvasUpdate.PostLayout);
	}*/

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
