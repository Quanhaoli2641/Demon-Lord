using UnityEngine;
using System.Collections;

public class PortalController : MonoBehaviour {

	public float xPosition;
	public float yPosition;
	public bool inZone;
	private PlayerController player;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow) && inZone){
			player.gameObject.transform.position = new Vector3 (xPosition, yPosition, player.gameObject.transform.position.z);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {

			inZone = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			
			inZone = false;
		}
	}
}
