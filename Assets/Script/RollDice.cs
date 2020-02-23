using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class RollDice : MonoBehaviour {
  public Sprite[] _diceSides;
  public Sprite emptyDice;
  private Image _img;
  private int _playerTurn = 1;
  private bool _coroutineAllowed = true;

  void Awake(){
    _img = GetComponent<Image>();
    _img.sprite = emptyDice;
  }

  public void DicePhase(){
    if(_coroutineAllowed){
      StartCoroutine(RollTheDice());
    }
  }

  private IEnumerator RollTheDice(){
    _coroutineAllowed = false;
    int randomDiceSide = 0;
    for (int i = 0; i <= 20; i++){
      randomDiceSide = Random.Range(0, 6);
      _img.sprite = _diceSides[randomDiceSide];
      yield return new WaitForSeconds(0.06f);
    }

    if(GameManager.gm){
      GameManager.gm.diceSideThrown(randomDiceSide + 1);
      if(_playerTurn == 1){
        GameManager.gm.MovePlayer(1);
      } else if(_playerTurn == 2){
        GameManager.gm.MovePlayer(2);
      } else if(_playerTurn == 3){
        GameManager.gm.MovePlayer(3);
      } else if(_playerTurn == 4){
        GameManager.gm.MovePlayer(4);
      }
    }

    _coroutineAllowed = true;
  }
}
