using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameScript : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject resultPanel;
    public TextMeshProUGUI prevResult;
    private int[] betValues = { 0, 0, 0};

    // Returns the player to title screen
    public void Return()
    {
        int prevSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        SceneManager.LoadScene(prevSceneIndex);
    }

    // This function is called by the onscreen buttons.  
    //  The int represents the luck of the button pressed, with 0 being unlucky, 1 random, and 2 lucky.
    public void RollDice(int luck)
    {
        DiceButton button;

        // This translates the luck variable into a button class.  Technically any number other than
        //  0 or 2 creates a random button, I couldn't think of a better solution to cover other numbers.
        switch (luck)
        {
            case 0:
                button = new BadButton();
                break;
            case 2:
                button = new GoodButton();
                break;
            default:
                button = new RandButton();
                break;
        }

        
        // True means the player successfully called the bet, false means they failed.
        if (button.RTD())
        {
            resultPanel.GetComponentInChildren<TextMeshProUGUI>().text = "You won!";
            prevResult.text = "Previous Result: " + betValues[luck];
        } else
        {
            // Shows the player a bet they didn't select if they lost.
            resultPanel.GetComponentInChildren<TextMeshProUGUI>().text = "You lost!  The result was: " + button.ReturnAnythingBut(betValues);
            prevResult.text = "Previous Result: " + button.ReturnAnythingBut(betValues);
        }

        ToggleResults(true);
        GenerateBets();
    }

    

    // Takes the buttons and generates new 'bets' for their text.  Avoids duplicate numbers on screen.
    public void GenerateBets()
    {
        // Loops through each on screen button
        for (int i = 0; i < buttons.Length; i++)
        {
            int n;
            do
            {
                // Attempts to generate a random number, and checks if said number is already present on screen.  Try again if it is.
                n = Random.Range(2, 12);
            } while (n == betValues[0] || n == betValues[1] || n == betValues[2]);

            // Set the button in question's bet number to the number generated.
            betValues[i] = n;
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "Bet: " + betValues[i];
        }
    }

    // Toggles the result screen on or off.
    public void ToggleResults(bool active)
    {
        resultPanel.SetActive(active);
    }

    //On wakeup, call GenerateBets() so the user is greeted by fresh bets
    void Start()
    {
        BadButton badBet = new BadButton();
        GoodButton goodBet = new GoodButton();
        RandButton ranBet = new RandButton();

        GenerateBets();
    }
}