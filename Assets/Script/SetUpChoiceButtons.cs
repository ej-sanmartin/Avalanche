using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SetUpChoiceButtons : MonoBehaviour {
  public Button moveTheseNumbersButton;
  public GameObject[] targetDiceResults;
  public GameObject[] diceOnButtons;

  public Sprite emptyDice;
  public Sprite[] diceSides;
  private Image[] diceDisplayedOnThisButton;

  // references risk button to determine which phase of players turn it is
  public GameObject riskButton;
  private bool isDiceRolled = false;

  void Awake(){
    setDiceUp();
  }

  void setDiceUp(){
    // sets up bool for if dice is rolled, initially set to false
    isDiceRolled = riskButton.GetComponent<RiskButton>().getDidRollStatus();

    if(isDiceRolled == false){
      //for(int i = 0; )
    }
  }
}
