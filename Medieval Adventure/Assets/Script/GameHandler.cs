
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    HighscoreHandler highscoreHandler;
    InputField nameInput;
     public void AddPlayer()
    {
        highscoreHandler.AddHighscoreIfPossible(new HighscoreElement(nameInput.text, MoneyText.Coin));
    }
}