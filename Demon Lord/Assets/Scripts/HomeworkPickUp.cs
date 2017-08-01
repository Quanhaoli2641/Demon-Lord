using UnityEngine;
using System.Collections;

public class HomeworkPickUp : MonoBehaviour {

	public int homeworkRecieved;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.GetComponent<PlayerController> () == null) {
			return;
		}
		HomeworkScoreManager.AddHomeworks (homeworkRecieved);

		Destroy (gameObject);
	}
}
