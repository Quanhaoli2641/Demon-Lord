﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CenaKilled : MonoBehaviour {
	
	public static int numberOfHomeworks;
	
	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		
		numberOfHomeworks = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (numberOfHomeworks < 0)
			numberOfHomeworks = 0;
		
		text.text = "Souls Absorbed: " + numberOfHomeworks;
	}
	
	public void AddHomeworks(int HomeworkToAdd) {
		numberOfHomeworks += HomeworkToAdd;
	}
	
	public static void Reset() {
		numberOfHomeworks = 0;
	}
	
	public int hwAmt(){
		return numberOfHomeworks;
	}
}
