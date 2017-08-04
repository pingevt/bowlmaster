using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public Text[] rollTexts, frameTexts;

	// Use this for initialization
	void Start () {
		for (int i = 0; i <= 20; i++) {
			rollTexts [i].text = "";
		}
		for (int i = 0; i <= 9; i++) {
			frameTexts [i].text = "";
		}
	}

	public void FillRolls (List<int> rolls) {
		string scoresString = FormatRolls (rolls);
		for (int i = 0; i < scoresString.Length; i++) {
			rollTexts [i].text = scoresString [i].ToString ();
		}

	}

	public void FillFrames (List<int> frames) {
		for (int i = 0; i < frames.Count; i++) {
			frameTexts [i].text = frames [i].ToString ();
		}
	}

	public static string FormatRolls (List<int> rolls) {
		string output = "";
		List<string> frameVals = new List<string>();
		int c = 0;

		for (int i = 0; i < rolls.Count; i++) {
			frameVals.Add(rolls [i].ToString());
			if (c % 2 == 1) {
				if (rolls [i - 1] + rolls [i] == 10 && rolls [i - 1] != 10) {
					frameVals[c] = "/";
				}
				if (c == 19 && rolls [i] == 10) {
					frameVals[c] = "X";
				}
			} else {
				if (rolls [i] == 10) {
					frameVals[c] = "X";
					if (c < 18) {
						frameVals.Add (" ");
						c++;
					}
				}
				if (c == 20 && rolls [i - 1] + rolls [i] == 10) {
					frameVals[c] = "/";
				}
			}
			c++; 
		}
			
		for (int i = 0; i < frameVals.Count; i++) {
			if (frameVals [i] == "0")
				output += "-";
			else 
				output += frameVals [i];
		}

		return output;
	}

}
