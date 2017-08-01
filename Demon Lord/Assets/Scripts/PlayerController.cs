using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float moveSpeed;
	private float moveVelocity;
	public float jumpHeight;
	private Collider2D collider;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	private int counter;


	private Rigidbody2D myRigidBody2D;
	private ManaManager mm;
	private Animator anim;
	private bool dived;

	private Cutscene cutscene;

	private bool attack;



	void Start () {
		counter = 0;
		collider = GetComponent<BoxCollider2D>();
		myRigidBody2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		mm = FindObjectOfType<ManaManager> ();
		dived = false;

		cutscene = FindObjectOfType<Cutscene> ();
		attack = false;
	}

	
	// Update is called once per frame
	void Update () {

		//if (cutscene.returnCompleted ()) {


			grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		
			anim.SetBool ("grounded", grounded);

		
			if (Input.GetKeyDown (KeyCode.UpArrow) && grounded && !dived) {
				myRigidBody2D.velocity = new Vector2 (myRigidBody2D.velocity.x, jumpHeight);
			}
			Move (Input.GetAxisRaw ("Horizontal"));

		
			myRigidBody2D.velocity = new Vector2 (moveVelocity, myRigidBody2D.velocity.y);


		
			if (Input.GetKeyDown (KeyCode.Space)) {
				if (!anim.GetBool ("petrify")){
					anim.SetBool ("petrify", true);
					attack = true;
				}
			}
		
			if (GetComponent<Rigidbody2D> ().velocity.x > 0) {
				transform.localScale = new Vector3 (-100f, 100f, 100f);
			} else if (GetComponent<Rigidbody2D> ().velocity.x < 0) {
				transform.localScale = new Vector3 (100f, 100f, 100f);
			}
		

		

			anim.SetFloat ("speed", Mathf.Abs (myRigidBody2D.velocity.x));

			if (anim.GetBool ("petrify")) {
				counter ++;
				if (counter >= 15) {
					anim.SetBool ("petrify", false);
					counter = 0;
				}
			}	

			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				if (!dived && grounded && mm.getPlayerMana () >= mm.maxPlayerMana) {
					mm.under = true;
					anim.SetBool ("dived", true);
					dived = true;
					this.gameObject.layer = 11;
				} else {
					this.gameObject.layer = 9;
					mm.under = false;
					anim.SetBool ("dived", false);
					dived = false;
					//collider.isTrigger = false;
				}
			}
			if (mm.getPlayerMana () <= 0) {
				this.gameObject.layer = 9;
				anim.SetBool ("dived", false);
				mm.under = false;
				dived = false;
				//collider.isTrigger = false;
			}
		}

	//}

	public void Move(float moveInput){
		moveVelocity = moveSpeed * moveInput;
	}

	public bool getAttack() {
		return attack;
	}

	public void setAttack() {
		attack = false;
	}

}