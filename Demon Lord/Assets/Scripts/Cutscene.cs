using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour {

	public Sprite s1;
	public Sprite s2;
	public Sprite s3;

	private Text text;

	private Image img;

	private HealthManager hm;
	private ManaManager mm;

	private bool completed;

	private int counter;

	public GameObject text2;


	// Use this for initialization
	void Start () {

		counter = 0;

		hm = FindObjectOfType<HealthManager> ();
		mm = FindObjectOfType<ManaManager> ();
	
		img = this.GetComponent<Image> ();

		text = this.gameObject.transform.GetChild (0).GetComponent<Text>();

		img.sprite = s1;

		text.text = "I am a retired demon lord. I no longer wreck havoc as I used to... But then..";

		completed = false;


	}
	
	// Update is called once per frame
	void Update () {

		if (counter == 0) {
			hm.gameObject.SetActive(false);
			mm.gameObject.SetActive(false);
			text2.SetActive(false);

		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (img.sprite == s1) {
				img.sprite = s2;
				text.text = "At a college party...";
				counter ++;
			}
			else if (img.sprite == s2) {
				img.sprite = s3;
				text.text = "I need to get back home. Since all these 'summoners' are asleep, I suppose I'll have to do the ritual myself... I'll need 10 candles.";
				counter ++;
			}
			else {
				img.enabled = false;
				completed = true;
				text.text = "";
				hm.gameObject.SetActive(true);
				mm.gameObject.SetActive(true);
				text2.SetActive(true);
;			}
		}
	}

	public bool returnCompleted() {
		return completed;
	}
}
