using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUpChoiceButtons : MonoBehaviour {
  // variables for holding all objects effected by this script
  public Button moveTheseNumbersButton;
  public GameObject[] targetDiceResults; // from DiceArea Canvas
  public GameObject[] diceOnButtons; // The dice attatched to this button's UI

  // variables handling rendering image logic
  public Sprite emptyDice; // for displaying null results or an unusable result
  public Sprite[] diceSides; // dice sprites
  private Image[] diceDisplayedOnThisButton;

  // references risk button to determine which phase of players turn it is
  public GameObject riskButton;
  private bool isDiceRolled = false;
  private bool coroutineStatusOfRolledDiceScript;

  // variable needed for the logic for getting dice numbers and setting dice image in button
  List<int> diceNumbers = new List<int>();
  // variable needed to move pieces on board at certain values from the board.
  List<int> diceValues = new List<int>();


  // will be called by riskbutton script when dice finishes rolling
  public void setDiceUp(){
    // sets up bool for if dice is rolled, initially set to false
    isDiceRolled = riskButton.GetComponent<RiskButton>().getDidRollStatus();

    // doesn't run if dice is not rolled
    if(isDiceRolled == false){
      return;
    }

    // if there are items in dicenumbers and dicevalues list at the start of this function, removes all items. So it empties list whenever theres a roll to ensure list are properly populated
    if(diceNumbers.Count != 0){
      diceValues.RemoveAt(0);
      diceValues.RemoveAt(1);

      for(int i = 0; i < diceNumbers.Count; i++){
        diceNumbers.RemoveAt(i);
      }
    }


    // adds dice sides as an int into a list, which will be used to set the dice's rendered sprite
    for(int i = 0; i < diceOnButtons.Length; i++){
      int diceNumber = GetTargetDiceResults(i);

      diceNumbers.Add(diceNumber);
    }

    // renders dice side onto the button UI using the data collected into the diceNumbers list
    for(int i = 0; i < diceOnButtons.Length; i++){
      int diceNumber = diceNumbers[i];

      diceOnButtons[i].GetComponent<ChoiceAreaDiceSetUpRenderedImage>().RenderDiceImage(diceNumber);
    }

    // sets up dice values
    for(int i = 0; i < diceOnButtons.Length; i += 2){
      int diceValue = diceNumbers[i] + 1; // first dice value of set, + 1 because dice sides from 1 - 6 start at index 0.
      diceValue += diceNumbers[i + 1] + 1; // second dice value of set

      Debug.Log(diceValue); // making sure correct values are being added up TODO: REMOVE ON FINAL BUILD
      diceValues.Add(diceValue);
    }
  }

  // returns an int that corresponds to a dice side (0 => side 1, 1 => side 2, etc)
  private int GetTargetDiceResults(int diceInListToGet){
    if(isDiceRolled == true){
      targetDiceResults[diceInListToGet].GetComponent<Dice>().SetDiceNumber(); // makes sure to set dice only when this script's functions are called AND after a player has rolled. Timed in this instance as to not prematurely set the dice's number
      return targetDiceResults[diceInListToGet].GetComponent<Dice>().GetDiceNumber();
    } else {
      return -1; // for errors
    }
  }
}
