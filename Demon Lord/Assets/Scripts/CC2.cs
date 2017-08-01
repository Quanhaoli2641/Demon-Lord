using UnityEngine;
using System.Collections;

public class CC2 : MonoBehaviour {
	
	public PlayerController player;
	
	public bool isFollowing;
	
	public float xOffset;
	public float yOffset;
	
	private Camera camera;
	private Cutscene cutscene;
	
	public float counter;
	
	// Use this for initialization
	void Start () {
		
		player = FindObjectOfType<PlayerController> ();
		
		isFollowing = true;
		
		camera = FindObjectOfType<Camera> ();
		
		counter = 0;
		
		cutscene = FindObjectOfType<Cutscene> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (!cutscene.returnCompleted()) {
			camera.cullingMask = 0;
			counter ++;
		} else
			camera.cullingMask = -1;
		
		if(isFollowing)
			transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, transform.position.z);
		
	}
}
