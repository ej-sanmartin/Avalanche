using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceUIHandler : MonoBehaviour {
  // to get reference for checking if dice is rolled and the UI to be effected
  public GameObject riskButton;
  public GameObject choiceOfMovementUI;

  private bool isDiceRolled = false;

  void Awake(){
    IsUIVisible();
  }

  void Update(){
    IsUIVisible();
  }

  void IsUIVisible(){
    isDiceRolled = riskButton.GetComponent<RiskButton>().getDidRollStatus();
    if(isDiceRolled == false){
      choiceOfMovementUI.SetActive(false);
    } else {
      choiceOfMovementUI.SetActive(true);
    }
  }
}
