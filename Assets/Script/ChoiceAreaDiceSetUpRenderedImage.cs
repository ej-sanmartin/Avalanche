using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceAreaDiceSetUpRenderedImage : MonoBehaviour {
  public Sprite[] _diceSides;
  public Sprite blankDice;
  private Image _diceImage;


  void Awake(){
    _diceImage = GetComponent<Image>();
  }

  public void RenderDiceImage(int sideNumber){
    if(sideNumber == -1){
      _diceImage.sprite = blankDice;
      return;
    }

    _diceImage.sprite = _diceSides[sideNumber];
  }
}
