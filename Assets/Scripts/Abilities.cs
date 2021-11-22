using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Abilities : MonoBehaviour
{
    public TMPro.TextMeshProUGUI BattleText;

    private BattleScript battle;

    public static int Kai_hp = 100;

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
        BattleText.text = "Kai Punches Amy.";
        EnemyBattle.Amy_hp -= 10;

        if (EnemyBattle.Amy_hp < 0)
            EnemyBattle.Amy_hp = 0;

        battle.ChangeTurns();
    }

    //Major Attack
    public void OnAttack2Pressed()
    {
        BattleText.text = "Kai fire Lazers.";
        EnemyBattle.Amy_hp -= 25;

        if (EnemyBattle.Amy_hp < 0)
            EnemyBattle.Amy_hp = 0;

        battle.ChangeTurns();
    }

    // Heal Yourself
    public void OnHealPressed()
    {
        BattleText.text = "Kai eats an Apple to heal himself.";
        Kai_hp += 15;

        if (Kai_hp > 100)
            Kai_hp = 100;
        
        battle.ChangeTurns();
    }

    // Flee back to the level Map.
    public void OnFleePressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
