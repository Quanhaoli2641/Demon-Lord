using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class cutscene2 : MonoBehaviour {

	private PlayerController player;
	public Sprite s4;
	public Sprite s5;
	public Sprite s6;
	private Text text;
	
	private Image img;
	private HealthManager hm;
	private ManaManager mm;
	public Text text2;
	public Text text3;

	private Camera camera;

	private bool m;
	private CenaKilled ck;

	private HomeworkScoreManager hs;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		camera = FindObjectOfType<Camera> ();
		hm = FindObjectOfType<HealthManager> ();
		mm = FindObjectOfType<ManaManager> ();
		hs = FindObjectOfType<HomeworkScoreManager> ();
		
		img = this.GetComponent<Image> ();
		
		text = this.gameObject.transform.GetChild (0).GetComponent<Text> ();

		img.enabled = false;
		text.enabled = false;

		m = false;
		ck = FindObjectOfType<CenaKilled> ();


	}
	
	// Update is called once per frame
	void Update () {
		if (player.gameObject.transform.position.y < -1000 && hs.hwAmt () >= 10 && ck.hwAmt() >= 10) {
			text2.enabled = false;
			text3.enabled = false;
			m=true;
			img.enabled = true;
			text.enabled = true;
			camera.cullingMask = 0;
			if (img.sprite == s4) {
				
				text.text = "Finally! I can return back home! INITIATING THE RITUAL!";
			}

			this.gameObject.SetActive(true);
			hm.gameObject.SetActive (false);
			mm.gameObject.SetActive (false);
			
			if (Input.GetKeyDown (KeyCode.Space)) {
				if (img.sprite == s4) {
					img.sprite = s5;
					text.text = "What.";

				} else if (img.sprite == s5) {
					img.sprite = s6; 
					text.text = "Made By: Andrew Luong, " +
						"MD Kabir, " +
						"Quanhao Li, " +
						"Saif Rahman";
				} else {
					Application.Quit();

				}
			}
		}
	}


}
