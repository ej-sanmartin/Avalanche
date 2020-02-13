using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RiskButton : MonoBehaviour {
  public Button riskButton;
  public GameObject[] dice;

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
    yield return new WaitForSeconds(2f);
  }

  public bool getDidRollStatus() {
    return !_coroutineAllowed;
  }

  public void turnReRollOn(){
    _coroutineAllowed = true;
  }
}
