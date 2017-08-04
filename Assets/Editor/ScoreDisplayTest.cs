using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest {

	[Test]
	public void T00PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01Bowl1 () {
		int[] rolls = { 1 };
		string rollsString = "1";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T02Bowl10 () {
		int[] rolls = { 10 };
		string rollsString = "X ";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T03RegFrame () {
		int[] rolls = { 1,2 };
		string rollsString = "12";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T04SpareFrame () {
		int[] rolls = { 1,2, 3,7 };
		string rollsString = "123/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T04SpareFrameWith10 () {
		int[] rolls = { 1,2, 0,10 };
		string rollsString = "12-/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T05Strike () {
		int[] rolls = { 1,2, 3,7, 10 };
		string rollsString = "123/X ";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T06StrikeAfter () {
		int[] rolls = { 1,2, 3,7, 10, 1 };
		string rollsString = "123/X 1";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T07FullGame () {
		int[] rolls = { 1,2, 3,7, 10, 1,9, 2,5, 8,2, 10, 10, 1,6, 1,2 };
		string rollsString = "123/X 1/258/X X 1612";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T07FullGame00 () {
		int[] rolls = { 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0 };
		string rollsString = "--------------------";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T08FullGameSpare () {
		int[] rolls = { 1,2, 3,7, 10, 1,9, 2,5, 8,2, 10, 10, 1,6, 4,6, 1 };
		string rollsString = "123/X 1/258/X X 164/1";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T09FullGameSpareStrike () {
		int[] rolls = { 1,2, 3,7, 10, 1,9, 2,5, 8,2, 10, 10, 1,6, 4,6, 10 };
		string rollsString = "123/X 1/258/X X 164/X";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T10FullGameStrikeOpen () {
		int[] rolls = { 1,2, 3,7, 10, 1,9, 2,5, 8,2, 10, 10, 1,6, 10, 1,2 };
		string rollsString = "123/X 1/258/X X 16X12";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T11FullGameStrikeSpare () {
		int[] rolls = { 1,2, 3,7, 10, 1,9, 2,5, 8,2, 10, 10, 1,6, 10, 4,6 };
		string rollsString = "123/X 1/258/X X 16X4/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T11FullGameStrikeSpareAlt () {
		int[] rolls = { 1,2, 3,7, 10, 1,9, 2,5, 8,2, 10, 10, 1,6, 10, 0,10 };
		string rollsString = "123/X 1/258/X X 16X-/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T12FullGameStrikeStrikeOpen () {
		int[] rolls = { 1,2, 3,7, 10, 1,9, 2,5, 8,2, 10, 10, 1,6, 10, 10, 4 };
		string rollsString = "123/X 1/258/X X 16XX4";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T13FullGameStrikeStrikeStrike () {
		int[] rolls = { 1,2, 3,7, 10, 1,9, 2,5, 8,2, 10, 10, 1,6, 10, 10, 10 };
		string rollsString = "123/X 1/258/X X 16XXX";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T99PerfectGame () {
		int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
		string rollsString = "X X X X X X X X X XXX";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}





	[Test]
	public void T03 () {
		int[] rolls = { 1,9 };
		string rollsString = "1/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T04 () {
		int[] rolls = { 1,9, 1};
		string rollsString = "1/1";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T05 () {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9,3};
		string rollsString = "1111111111111111111/3";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T06 () {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,1,1};
		string rollsString = "111111111111111111X11";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T07 () {
		int[] rolls = { 0 };
		string rollsString = "-";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	//http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
	[Category ("Verification")]
	[Test]
	public void TG01GoldenCopyB1of3 () {
		int[] rolls = { 10, 9,1, 9,1, 9,1, 9,1, 7,0, 9,0, 10, 8,2, 8,2,10};
		string rollsString = "X 9/9/9/9/7-9-X 8/8/X";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	
	//http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
	[Category ("Verification")]
	[Test]
	public void TG02GoldenCopyB2of3 () {
		int[] rolls = { 8,2, 8,1, 9,1, 7,1, 8,2, 9,1, 9,1, 10, 10, 7,1};
		string rollsString = "8/819/718/9/9/X X 71";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	
	//http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
	[Category ("Verification")]
	[Test]
	public void TG03GoldenCopyB3of3 () {
		int[] rolls = { 10, 10, 9,0, 10, 7,3, 10, 8,1, 6,3, 6,2, 9,1,10};
		string rollsString = "X X 9-X 7/X 8163629/X";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	
	// http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
	[Category ("Verification")]
	[Test]
	public void TG04GoldenCopyC1of3 () {
		int[] rolls = { 7,2, 10, 10, 10, 10, 7,3, 10, 10, 9,1, 10,10,9};
		string rollsString = "72X X X X 7/X X 9/XX9";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	
	// http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
	[Category ("Verification")]
	[Test]
	public void TG05GoldenCopyC2of3 () {
		int[] rolls = { 10, 10, 10, 10, 9,0, 10, 10, 10, 10, 10,9,1};
		string rollsString = "X X X X 9-X X X X X9/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
}
