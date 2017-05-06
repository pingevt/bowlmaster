using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

[TestFixture]
public class ActionMasterTest {
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

	private ActionMaster actionMaster;

	[SetUp]
	public void Setup() {
		actionMaster = new ActionMaster ();
	}

	[Test]
	public void T00PassingTest () {
		Assert.AreEqual (1, 1); 
	}

	[Test]
	public void T01OneStrikeRetunsEndTurn() {
		Assert.AreEqual (endTurn, actionMaster.Bowl(10));
	}

	[Test]
	public void T02Bowl8ReturnsTidy() {
		Assert.AreEqual (tidy, actionMaster.Bowl(8));
	}

	[Test]
	public void T03Bowl28ReturnsEndTurn() {
		
		//Assert.AreEqual (tidy, actionMaster.Bowl(8));
		actionMaster.Bowl(8);
		Assert.AreEqual (endTurn, actionMaster.Bowl(2));
	}

	[Test]
	public void T04CheckResetAtStrikeInLastFrame() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach (int roll in rolls) {
			actionMaster.Bowl(roll);
		}

		Assert.AreEqual (reset, actionMaster.Bowl(10)); 
	}

	[Test]
	public void T05CheckResetAtStrikeInLastFrame() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach (int roll in rolls) {
			actionMaster.Bowl(roll);
		}

		Assert.AreEqual (tidy, actionMaster.Bowl(1)); 
		Assert.AreEqual (reset, actionMaster.Bowl(9)); 
	}

	[Test]
	public void T06YoutubeRollsEndInEndGame() {
		int[] rolls = {8,2,7,3,3,4,10,2,8,10,10,8,0,10,8,2};
		foreach (int roll in rolls) {
			actionMaster.Bowl(roll);
		}
		 
		Assert.AreEqual (endGame, actionMaster.Bowl(9)); 
	}

	[Test]
	public void T07GameEndsAtBowl20() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach (int roll in rolls) {
			actionMaster.Bowl(roll);
		}

		actionMaster.Bowl (1);
		Assert.AreEqual (endGame, actionMaster.Bowl(1)); 
	}
		
	[Test]
	public void T08CheckResetAtStrikeInLastFrame() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach (int roll in rolls) {
			actionMaster.Bowl(roll);
		}

		Assert.AreEqual (reset, actionMaster.Bowl(10)); 
		Assert.AreEqual (tidy, actionMaster.Bowl(5)); 
	}

	[Test]
	public void T09CheckResetAt2StrikesInLastFrame() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach (int roll in rolls) {
			actionMaster.Bowl(roll);
		}

		Assert.AreEqual (reset, actionMaster.Bowl(10));
		Assert.AreEqual (tidy, actionMaster.Bowl(0));
		Assert.AreEqual (endGame, actionMaster.Bowl(10));
	}

	[Test]
	public void T10CheckResetAt2StrikesInLastFrame() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach (int roll in rolls) {
			actionMaster.Bowl(roll);
		}

		Assert.AreEqual (reset, actionMaster.Bowl(10));
		Assert.AreEqual (reset, actionMaster.Bowl(10));
		Assert.AreEqual (endGame, actionMaster.Bowl(10));
	}

	[Test]
	public void T11CheckInitialBowlCount() {
		Assert.AreEqual (1, actionMaster.GetCurrentBowl ());
	}

	[Test]
	public void T12Check1BowlCount() {
		actionMaster.Bowl (5);
		Assert.AreEqual (2, actionMaster.GetCurrentBowl ());
	}

	[Test]
	public void T13Check2BowlCount() {
		actionMaster.Bowl (4);
		actionMaster.Bowl (4);
		Assert.AreEqual (3, actionMaster.GetCurrentBowl ());
	}

	[Test]
	public void T14Check1GuttterBowlCount() {
		actionMaster.Bowl (0);
		Assert.AreEqual (2, actionMaster.GetCurrentBowl ());
	}

	[Test]
	public void T15Check2GutterBowlCount() {
		actionMaster.Bowl (0);
		actionMaster.Bowl (0);
		Assert.AreEqual (3, actionMaster.GetCurrentBowl ());
	}

	[Test]
	public void T16Check2bowlSpareBowlCount() {
		actionMaster.Bowl (2);
		actionMaster.Bowl (8);
		Assert.AreEqual (3, actionMaster.GetCurrentBowl ());
	}

	[Test]
	public void T17Check10PinSpareBowlCount() {
		actionMaster.Bowl (0);
		actionMaster.Bowl (10);
		Assert.AreEqual (3, actionMaster.GetCurrentBowl ());
	}
}