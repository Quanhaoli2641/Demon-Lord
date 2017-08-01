using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	public string levelToLoad;
	private bool playerInZone;

	// Use this for initialization
	void Start () {
		playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow) && playerInZone) {
			Application.LoadLevel ( levelToLoad );
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			playerInZone = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			playerInZone = false;
		}
	}
}
