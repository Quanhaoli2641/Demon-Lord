using UnityEngine;
using System.Collections;

public class SIRPatrol : MonoBehaviour {
	/*
	public float moveSpeed;
	public bool moveRight;
	public float checkRadius;
	public float attackRadius;
	private float distanceBetween;
	
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;
	
	private bool atEdge;
	public Transform edgeCheck;
	
	private PlayerController player;
	public GameObject saif;
	private GameObject Saif;
	
	private Animator anim;
	
	private float timer;
	//private float copyTime;
	
	//private bool action;
	
	//Use this for initialization
	void Start () {
		anim = saif.GetComponent<Animator>();
		player = FindObjectOfType<PlayerController>();
		Saif = this.gameObject;
		//copyTime = timer;
		//action = false;
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		//if (!action) {
		//	timer -= Time.deltaTime;
		//}
		if (saif) {
			distanceBetween = saif.transform.position.x - player.transform.position.x;
		
			hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);
		
			atEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsWall);
		
			if (timer >= 2f || hittingWall || !atEdge) {
				moveRight = !moveRight;
				timer = 0f;
			}
		
			if (moveRight) {
				saif.transform.localScale = new Vector3 (-100f, 100f, 100f);
			} else if (!moveRight) {
				saif.transform.localScale = new Vector3 (100f, 100f, 100f);
			}
		
		
			if (distanceBetween < attackRadius && !hittingWall && atEdge) {
				//if ((moveRight && distanceBetween > 0) || (!moveRight && distanceBetween < 0)) {
				//	moveRight = !moveRight;
				//}
				//action = true;
				saif.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
				Saif.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
				anim.SetBool ("Attack", true);
				//action = false;
			} else if (distanceBetween < checkRadius && !hittingWall && atEdge) {
				anim.SetBool ("Attack", false);
				if (moveRight && distanceBetween < 0) {
					//action = true;
					//saif.transform.parent = null;
					saif.GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, 0f);
					Saif.GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, 0f);
				} else if (!moveRight && distanceBetween > 0) {
					//action = true;
					//saif.transform.parent = null;
					saif.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, 0f);
					Saif.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, 0f);
				}
			else if ((!moveRight && distanceBetween < 0) || (moveRight && distanceBetween > 0)) {
				timer += Time.deltaTime;
			}
			else {
					timer += Time.deltaTime;
				}
				//action = false;
			} else if (distanceBetween >= checkRadius || hittingWall || !atEdge) {
				anim.SetBool ("Attack", false);
				saif.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
				Saif.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
				timer += Time.deltaTime;
				//saif.transform.parent = Saif.transform;
			}
		
			anim.SetFloat ("Run", Mathf.Abs (saif.GetComponent<Rigidbody2D> ().velocity.x));
		}

		}
		
		
	//}
*/
	public float moveSpeed;
	public bool moveRight;
	public float checkRadius;
	private float distanceBetween;
	
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;
	
	private bool atEdge;
	public Transform edgeCheck;
	
	private PlayerController player;
	
	private Animator anim;
	
	private float timer;

	private float distanceBetweenY;
	public float yDistance;

	void Start(){
		anim = GetComponent<Animator>();
		player = FindObjectOfType<PlayerController>();
		timer = 2f;
	}

	void Update(){
			distanceBetweenY = Mathf.Abs(transform.position.y - player.transform.position.y);
			distanceBetween = transform.position.x - player.transform.position.x;
			hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);
			atEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsWall);

			if( (!atEdge || hittingWall) && ((distanceBetween > 0 && !moveRight) || (distanceBetween < 0 && moveRight)) && (distanceBetweenY<yDistance)) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
			}
			else if ((distanceBetweenY<yDistance) ) {

				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
			//saif.transform.position = new Vector3 (Saif.transform.position.x, Saif.transform.position.y, Saif.transform.position.z);
			//Saif.transform.position = new Vector3 (Saif.transform.position.x, Saif.transform.position.y, Saif.transform.position.z);
				//anim.SetBool ("Attack", true);
			}
			else if ((Mathf.Abs (distanceBetween) < checkRadius) && !hittingWall && distanceBetween > 0 &&!moveRight) {
				//anim.SetBool ("Attack", false);
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, 0f);
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, 0f);
			//moveRight = false;
			} else if ((Mathf.Abs (distanceBetween) < checkRadius) && !hittingWall && distanceBetween < 0 && moveRight) {
				//anim.SetBool ("Attack", false);
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, 0f);
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, 0f);
			//moveRight = true;
			} else {
				//anim.SetBool("Attack", false);
				timer -= Time.deltaTime;
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
				if (timer < 0){
					moveRight = !moveRight;
					timer = 2f;
				}

			}

			if (moveRight) {
				transform.localScale = new Vector3 (-100f, 100f, 100f);
			} else if (!moveRight) {
				transform.localScale = new Vector3 (100f, 100f, 100f);
			}

			anim.SetFloat ("speed", Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x));
	}
}
