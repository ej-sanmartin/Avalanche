using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RiskButton : MonoBehaviour {
  public Button riskButton;
  public GameObject[] dice;
  public GameObject[] choiceButtons;

  private bool _coroutineAllowed = true;

  void Awake(){
    riskButton.onClick.RemoveAllListeners();
    riskButton.onClick.AddListener(() => ActivateDiceRolls());
  }

  public void ActivateDiceRolls(){
    // should also check how current player is progressing through turn
    if(_coroutineAllowed){
      StartCoroutine(DiceRolls());
    }
  }

  private IEnumerator DiceRolls(){
    _coroutineAllowed = false;
    for(int i = 0; i < dice.Length; i++){
      dice[i].GetComponent<RollDice>().DicePhase();
    }

    StartCoroutine(ActivateAndSetUpChoiceButtons());
    yield return new WaitForSeconds(2f);
  }

  private IEnumerator ActivateAndSetUpChoiceButtons(){
    yield return new WaitForSeconds(2.01f);
    for(int i = 0; i < choiceButtons.Length; i++){
      choiceButtons[i].GetComponent<SetUpChoiceButtons>().setDiceUp();
    }
  }

  public bool getDidRollStatus() {
    return !_coroutineAllowed;
  }

  public void turnReRollOn(){
    _coroutineAllowed = true;
  }
}
