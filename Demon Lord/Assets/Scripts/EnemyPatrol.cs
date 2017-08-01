using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	private Animator anim;
	private Transform light;
	private Renderer rend;
	private int counter;
	private bool touched;
	private Collider2D collider;
	public bool right;
	private HealthManager hm;
	private PlayerController p;
	private CenaKilled ck;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rend = GetComponent<Renderer>();
		light = this.gameObject.transform.GetChild (0);
		touched = false;
		collider = GetComponent<BoxCollider2D>();
		counter = 0;
		hm = FindObjectOfType<HealthManager> ();
		p = FindObjectOfType<PlayerController> ();
		ck = FindObjectOfType<CenaKilled> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (counter == 0) anim.SetBool ("petrified", false);

		if (touched) {

			rend.material.color = Color.gray;
			Destroy (light.gameObject);
			collider.isTrigger = true;
			touched = false;
			p.setAttack();

			this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);

			this.gameObject.GetComponent<SIRPatrol>().enabled = false;
		}

	}

	void OnCollisionEnter2D (Collision2D other) {
		//if (other.gameObject.transform.GetChild(1).tag == "petrify" && other.gameObject.transform.GetChild(1).gameObject.activeSelf) {
		if (p.getAttack()) {
			if ((right && this.transform.position.x > other.gameObject.transform.position.x) || (!right && this.transform.position.x < other.gameObject.transform.position.x)){
				//rend.material.color = Color.red;
				ck.AddHomeworks(1);
				hm.addHealth();
				counter +=1;
				anim.SetBool ("petrified", true);
				touched = true;
				//rend.material.shader = Shader.Find("Specular");
				//rend.material.setColor("_SpecColor", Color.gray);
			}

		}
}
}