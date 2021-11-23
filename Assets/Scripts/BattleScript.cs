using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleScript : MonoBehaviour // Scipt for the Battle Scene, connects to the game controller.
{
    public TMPro.TextMeshProUGUI InBattleText;
    public TMPro.TextMeshProUGUI PlayerHP_txt;
    public TMPro.TextMeshProUGUI EnemyHP_txt;
    public GameObject AbilityPannel;

    // Two float values for times to display texts.
    float TimeBetweenChars = 0.1f;
    float TimeBetweenTurns = 2.0f;
    bool PlayerTurn = false; // Bool value to determine turns.

    private IEnumerator animateTextCoroutine;
    private EnemyBattle enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObjectOfType<EnemyBattle>();

        // Animate Text for Encounter
        animateTextCoroutine = AnimateTextCoroutine("Kai has encountered Amy the Witch!     ");
        StartCoroutine((animateTextCoroutine));
    }

    // Update is called once per frame
    void Update()
    {
        AttackEffect();
    }

    // Determines whether it is your turn or the enemy's
    public void ChangeTurns()
    {
        animateTextCoroutine = EnemyTurnCoroutine();
        PlayerTurn = !PlayerTurn;
        string nextScene;

        if (Abilities.Kai_hp == 0)
        {
            //Amy defeats Kai
            InBattleText.color = Color.red;
            InBattleText.text = "Amy has Defeated Kai! Amy WINS!     ";
            nextScene = "StartingScene";
            StartCoroutine(GameOverDelay(nextScene));
        }
        else if (EnemyBattle.Amy_hp == 0)
        {
            //Kai defeats Amy
            InBattleText.color = Color.yellow;
            InBattleText.text = "Kai has Defeated Amy! Kai WINS!     ";
            nextScene = "SampleScene";
            StartCoroutine(GameOverDelay(nextScene));
        }
        else
        {
            //Continue Battle
            if (PlayerTurn) // When it is your turn, the ability pannel is activated.
            {
                InBattleText.color = Color.green;
                AbilityPannel.SetActive(true);
                InBattleText.text = "Kai's Turn:";
            }
            else
            {
                AbilityPannel.SetActive(false);
                StartCoroutine(animateTextCoroutine); // Call the Enemy Turn Coroutine to play for the enemy.
            }
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
        InBattleText.color = Color.red;
        InBattleText.text = "Amy's Turn: ";
        yield return new WaitForSeconds(3.0f);
        enemy.EnemyActionTurn();
        InBattleText.text = enemy.actionMessage(InBattleText.text);
        yield return new WaitForSeconds(TimeBetweenTurns);
        ChangeTurns();
    }

    IEnumerator GameOverDelay(string scene) // Delay the Battle for a few seconds to display who won.
    {
        yield return new WaitForSeconds(4.5f);
        SceneManager.LoadScene(scene);
    }

    public void AttackEffect() // Text lable to show how much HP Player and Enemy has.
    {
        PlayerHP_txt.text = "HP: " + Abilities.Kai_hp + "/100";
        EnemyHP_txt.text = "HP: " + EnemyBattle.Amy_hp + "/100";
    }

}
