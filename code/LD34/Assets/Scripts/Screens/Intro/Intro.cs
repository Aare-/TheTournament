using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;


public class Intro : MonoBehaviour {

	public List<Text> labels;
	public List<string> twitters;
	public int iterator = 0;
	public float animationTime;
	private float animationProcess = 2.0f;

	// Use this for initialization
	void Start () {
		for (iterator = 0; iterator <= 5 ; iterator++) {
			StartCoroutine(writeText (twitters[iterator], labels [iterator]));
			writeText (twitters[iterator], labels [iterator]);
		}
	}

	void Update () {
		if (animationProcess <= 1.0) {
			animationProcess += 0.1f ;
		}
	}

	IEnumerator writeText(string tweeter, Text label) {
		yield return new WaitForSeconds (3.0f);
		animationProcess = 0.0f;
		int i = label.text.Length;
		string str = "";
		str = label.text;
			while (i > 0) {
			int countLetters =(int) Mathf.Floor(animationProcess * str.Length);
			str = str.Substring (0, str.Length - countLetters );
				label.text = str;
				yield return new WaitForSeconds (Time.deltaTime * animationTime);
				i--; 

				if (i == 0) {
					i = 0;
					label.text = "";
					animationProcess = 0.0f;
					string textToWrite = tweeter;
					str = "";
					while(i < textToWrite.Length){
						countLetters =(int) Mathf.Floor(animationProcess * textToWrite.Length);
						str = textToWrite.Substring (0, countLetters );
						label.text = str;
						yield return new WaitForSeconds(Time.deltaTime * animationTime);
				} 
				break;
			}

		} 
	}	
}
