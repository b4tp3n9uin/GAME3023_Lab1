using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Abilities : MonoBehaviour
{
    public TMPro.TextMeshProUGUI BattleText;

    private BattleScript battle;

    // Start is called before the first frame update
    void Start()
    {
        battle = FindObjectOfType<BattleScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Minor Attack
    public void OnAttack1Pressed()
    {
        BattleText.text = "You Punched the Enemy.";
        battle.ChangeTurns();
    }

    //Major Attack
    public void OnAttack2Pressed()
    {
        BattleText.text = "You fire Lazers.";
        battle.ChangeTurns();
    }

    // Heal Yourself
    public void OnHealPressed()
    {
        BattleText.text = "You have gave yourself health.";
        battle.ChangeTurns();
    }

    // Flee back to the level Map.
    public void OnFleePressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
