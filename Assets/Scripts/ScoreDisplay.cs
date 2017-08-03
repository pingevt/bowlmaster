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

	public void FillRollCard (List<int> rolls) {
		rolls [-1] = 1;
	}

}
