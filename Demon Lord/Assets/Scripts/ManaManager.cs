using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour {

	public int maxPlayerMana;
	
	public static float playerMana;

	public Slider manaBar;
	
	private LevelManager levelManager;
	
	public bool isDead;

	public bool under;
	
	// Use this for initialization
	void Start () {
		
		//text = GetComponent<Text> ();
		
		manaBar = GetComponent<Slider> ();
		
		playerMana = maxPlayerMana;
		
		levelManager = FindObjectOfType<LevelManager> ();
		
		isDead = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		//if(){
		//	playerMana -= 0.1f;
		//}
		if (under) {
			playerMana -= 0.5f;
		}

		if(playerMana < 150){
			playerMana+= 0.2f;
		}
		if (playerMana <= 0 && !isDead) {
			
			playerMana = 0;
			isDead = true;
		}
		
		manaBar.value = playerMana;
		//text.text = "" + playerMana;
		
	}

	public float getPlayerMana() {
		return playerMana;
	}


}
