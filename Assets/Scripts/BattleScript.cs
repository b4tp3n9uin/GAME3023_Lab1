using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour // Scipt for the Battle Scene, connects to the game controller.
{
    public TMPro.TextMeshProUGUI InBattleText;
    public GameObject AbilityPannel;

    // Two float values for times to display texts.
    float TimeBetweenChars = 0.1f;
    float TimeBetweenTurns = 2.0f;
    bool PlayerTurn = false; // Bool value to determine turns.

    private IEnumerator animateTextCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        // Animate Text for Encounter
        animateTextCoroutine = AnimateTextCoroutine("You have Encountered an Enemy!     ");
        StartCoroutine((animateTextCoroutine));
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Determines whether it is your turn or the enemy's
    public void ChangeTurns()
    {
        animateTextCoroutine = EnemyTurnCoroutine();
        PlayerTurn = !PlayerTurn;

        if (PlayerTurn) // When it is your turn, the ability pannel is activated.
        {
            AbilityPannel.SetActive(true);
            InBattleText.text = "Your Turn:";
        }
        else
        {
            AbilityPannel.SetActive(false);
            StartCoroutine(animateTextCoroutine); // Call the Enemy Turn Coroutine to play for the enemy.
        }
    }

    IEnumerator AnimateTextCoroutine(string message) // The text animates in the Start of the Battle Scene
    {
        AbilityPannel.SetActive(false);
        InBattleText.text = "";

        for (int currentChar = 0; currentChar < message.Length; currentChar++)
        {
            InBattleText.text += message[currentChar];
            yield return new WaitForSeconds(TimeBetweenChars);
        }
        ChangeTurns();
        animateTextCoroutine = null;
    }

    IEnumerator EnemyTurnCoroutine() // Function to determine the Enemy AI's moves.
    {
        yield return new WaitForSeconds(TimeBetweenTurns);
        InBattleText.text = "Enemy's Turn: ";
        yield return new WaitForSeconds(3.0f);
        InBattleText.text = "Enemy Skiups her Turn.";
        yield return new WaitForSeconds(TimeBetweenTurns);
        ChangeTurns();
    }
}
