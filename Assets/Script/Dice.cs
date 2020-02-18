using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// script for identifying dice
public class Dice : MonoBehaviour {
  private string _diceSideName;
  private int _diceSideNumber;
  private Image _diceImage;

  void Awake(){
    _diceImage = GetComponent<Image>();
  }

  public void SetDiceNumber(){
    if(_diceImage.sprite.name != null){
      _diceSideName = GetComponent<Image>().sprite.name;
    }

    switch(_diceSideName){
      case null:
        _diceSideNumber = -1;
        break;
      case "dice_1":
        _diceSideNumber = 0;
        break;
      case "dice_2":
        _diceSideNumber = 1;
        break;
      case "dice_3":
        _diceSideNumber = 2;
        break;
      case "dice_4":
        _diceSideNumber = 3;
        break;
      case "dice_5":
        _diceSideNumber = 4;
        break;
      case "dice_6":
        _diceSideNumber = 5;
        break;
      default:
        _diceSideNumber = -1;
        break;

    }
  }

  public int GetDiceNumber(){
    return _diceSideNumber;
  }
}
