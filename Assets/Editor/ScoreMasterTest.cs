using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ActionMasterTest {
	private List<int> pinFalls;
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

	[SetUp]
	public void Setup() {
		pinFalls = new List<int> ();
	}

	[Test]
	public void T00PassingTest () {
		Assert.AreEqual (1, 1); 
	}

	[Test]
	public void T01OneStrikeRetunsEndTurn() {
		pinFalls.Add (10);
		Assert.AreEqual (endTurn, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T02Bowl8ReturnsTidy() {
		pinFalls.Add (8);
		Assert.AreEqual (tidy, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T03Bowl28ReturnsEndTurn() {
		int[] rolls = {2, 8};
		Assert.AreEqual (endTurn, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T04CheckResetAtStrikeInLastFrame() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10};
		Assert.AreEqual (reset, ActionMaster.NextAction(rolls.ToList())); 
	}

	[Test]
	public void T05CheckResetAtStrikeInLastFrame() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1};
		int[] rolls2 = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1, 9};

		Assert.AreEqual (tidy, ActionMaster.NextAction(rolls.ToList())); 
		Assert.AreEqual (reset, ActionMaster.NextAction(rolls2.ToList())); 
	}

	[Test]
	public void T06YoutubeRollsEndInEndGame() {
		int[] rolls = {8,2,7,3,3,4,10,2,8,10,10,8,0,10,8,2, 9};
		 
		Assert.AreEqual (endGame, ActionMaster.NextAction(rolls.ToList())); 
	}

	[Test]
	public void T07GameEndsAtBowl20() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		Assert.AreEqual (endGame, ActionMaster.NextAction(rolls.ToList())); 
	}
		
	[Test]
	public void T08CheckResetAtStrikeInLastFrame() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10};
		int[] rolls2 = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10, 5};

		Assert.AreEqual (reset, ActionMaster.NextAction(rolls.ToList())); 
		Assert.AreEqual (tidy, ActionMaster.NextAction(rolls2.ToList())); 
	}

	[Test]
	public void T09CheckResetAt2StrikesInLastFrame() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10};
		int[] rolls2 = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10, 0};
		int[] rolls3 = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10, 0, 10};


		Assert.AreEqual (reset, ActionMaster.NextAction(rolls.ToList()));
		Assert.AreEqual (tidy, ActionMaster.NextAction(rolls2.ToList()));
		Assert.AreEqual (endGame, ActionMaster.NextAction(rolls3.ToList()));
	}

	[Test]
	public void T10CheckResetAt2StrikesInLastFrame() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10};
		int[] rolls2 = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10, 10};
		int[] rolls3 = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10, 10, 10};


		Assert.AreEqual (reset, ActionMaster.NextAction(rolls.ToList()));
		Assert.AreEqual (reset, ActionMaster.NextAction(rolls2.ToList()));
		Assert.AreEqual (endGame, ActionMaster.NextAction(rolls3.ToList()));
	}

//	[Test]
//	public void T11CheckInitialBowlCount() {
//		Assert.AreEqual (1, ActionMaster.GetCurrentBowl ());
//	}
//
//	[Test]
//	public void T12Check1BowlCount() {
//		ActionMaster.Bowl (5);
//		Assert.AreEqual (2, ActionMaster.GetCurrentBowl ());
//	}
//
//	[Test]
//	public void T13Check2BowlCount() {
//		ActionMaster.Bowl (4);
//		ActionMaster.Bowl (4);
//		Assert.AreEqual (3, ActionMaster.GetCurrentBowl ());
//	}
//
//	[Test]
//	public void T14Check1GuttterBowlCount() {
//		ActionMaster.Bowl (0);
//		Assert.AreEqual (2, ActionMaster.GetCurrentBowl ());
//	}
//
//	[Test]
//	public void T15Check2GutterBowlCount() {
//		ActionMaster.Bowl (0);
//		ActionMaster.Bowl (0);
//		Assert.AreEqual (3, ActionMaster.GetCurrentBowl ());
//	}
//
//	[Test]
//	public void T16Check2bowlSpareBowlCount() {
//		ActionMaster.Bowl (2);
//		ActionMaster.Bowl (8);
//		Assert.AreEqual (3, ActionMaster.GetCurrentBowl ());
//	}
//
//	[Test]
//	public void T17Check10PinSpareBowlCount() {
//		ActionMaster.Bowl (0);
//		ActionMaster.Bowl (10);
//		Assert.AreEqual (3, ActionMaster.GetCurrentBowl ());
//	}

	[Test]
	public void T18ZeroOne() {
		int[] rolls = {0, 1};
		Assert.AreEqual (endTurn, ActionMaster.NextAction(rolls.ToList()));
	}
}