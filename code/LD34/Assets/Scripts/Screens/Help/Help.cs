using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Help : MonoBehaviour {
	
	public string history;
	public Text historyLabel;
	public float animationTime;
	private float animationProcess = 0.0f;
	
	// Use this for initialization
	void Start () {
		history = historyLabel.text;
		StartCoroutine(writeText (history, historyLabel));
	}
	
	void Update () {
		if (animationProcess <= 1.0) {
			animationProcess += 0.001f ;
		}
	}
	
	IEnumerator writeText(string history, Text label) {
		int i = 0;
		label.text = "";
		animationProcess = 0.0f;
		string textToWrite = history;
		string str = "";
		while(i < textToWrite.Length){
			int countLetters =(int) Mathf.Floor(animationProcess * textToWrite.Length);
			str = textToWrite.Substring (0, countLetters );
			label.text = str;
			yield return new WaitForSeconds(Time.deltaTime * animationTime);
		} 
	}	
}
