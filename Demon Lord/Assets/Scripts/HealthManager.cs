using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public int maxPlayerHealth;
	
	public static float playerHealth;
	
	//Text text;
	public Slider healthBar;
	
	private LevelManager levelManager;
	
	public bool isDead;

	// Use this for initialization
	void Start () {
	
		//text = GetComponent<Text> ();

		healthBar = GetComponent<Slider> ();

		playerHealth = maxPlayerHealth;
		
		levelManager = FindObjectOfType<LevelManager> ();
		
		isDead = false;

	}
	
	// Update is called once per frame
	void Update () {

		playerHealth -= 0.05f;

		if (playerHealth <= 0 && !isDead) {
			
			playerHealth = 0;
			levelManager.RespawnPlayer();
			isDead = true;
		}

		healthBar.value = playerHealth;
		//text.text = "" + playerHealth;

	}
	public static void HurtPlayer (int damageToGive) {
		if (playerHealth > 0) {
			playerHealth -= damageToGive;
		}
	}

	public void fullHealth () {
		playerHealth = maxPlayerHealth;
	}

	public void addHealth() {
		playerHealth += 50;
	}

	public void zeroHealth () {
		playerHealth = 0;
	}

}
