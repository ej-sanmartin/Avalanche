using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUpChoiceButtons : MonoBehaviour {
  public Button moveTheseNumbersButton;
  public GameObject[] targetDiceResults; // from DiceArea Canvas
  public GameObject[] diceOnButtons; // The dice attatched to this button's UI

  public Sprite emptyDice; // for displaying null results or an unusable result
  public Sprite[] diceSides; // dice sprites
  private Image[] diceDisplayedOnThisButton;

  // references risk button to determine which phase of players turn it is
  public GameObject riskButton;
  private bool isDiceRolled = false;
  private bool allowedToSetUpDice = false;
  private bool coroutineStatusOfRolledDiceScript;

  // variabls needed for the logic for getting dice numbers and setting dice image in button
  List<int> diceNumbers = new List<int>();

  public void setDiceUp(){
    // sets up bool for if dice is rolled, initially set to false
    isDiceRolled = riskButton.GetComponent<RiskButton>().getDidRollStatus();

    // doesn't run if dice is not rolled
    if(isDiceRolled == false){
      return;
    }

    // if there are items in dice list at the start of this function, removes all items
    if(diceNumbers.Count != 0){
      for(int i = 0; i < diceNumbers.Count; i++){
        diceNumbers.RemoveAt(i);
      }
    }


    // adds dice sides as an int into a list, which will be used to set the dice's rendered sprite
    for(int i = 0; i < diceOnButtons.Length; i++){
      int diceNumber = GetTargetDiceResults(i);

      diceNumbers.Add(diceNumber);
    }

    for(int i = 0; i < diceOnButtons.Length; i++){
      int diceNumber = diceNumbers[i];

      diceOnButtons[i].GetComponent<ChoiceAreaDiceSetUpRenderedImage>().RenderDiceImage(diceNumber);
    }
  }

  private int GetTargetDiceResults(int diceInListToGet){
    if(isDiceRolled == true){
      targetDiceResults[diceInListToGet].GetComponent<Dice>().SetDiceNumber();
      return targetDiceResults[diceInListToGet].GetComponent<Dice>().GetDiceNumber();
    } else {
      return -1; // for errors
    }
  }
}
