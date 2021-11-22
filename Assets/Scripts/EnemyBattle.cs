using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle : MonoBehaviour
{
    string msgAction;

    public static int Amy_hp = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyActionTurn()
    {
        // Random float variable that will determine the enemy's action based on what range the value is.
        float rand = Random.RandomRange(0.0f, 2.0f);

        // Float values for the range of actions
        float smlAtk_range = 0.8f,
            heal_range = 1.0f,
            lrgAtk_range = 1.6f;

        float lowHealth = 20; // low health value for enemy
        float player_lowHealth = 25; // low health value for player

        if (Amy_hp <= lowHealth)
        {
            //Enemy heals, if she is very low on health
            Debug.Log("Enemy: heal");
            Amy_hp += 20;
            msgAction = "Amy drinks blood to heal herself!";
        }
        else if (Abilities.Kai_hp < player_lowHealth)
        {
            //if Enemy knows player is low on health, she will use powerful attacks to try to win the battle.
            Debug.Log("Enemy: Large Attack");
            Abilities.Kai_hp -= 20;
            msgAction = "Amy lays a Powerful Curse on Kai!";
        }
        else
        {
            if (rand <= smlAtk_range)
            {
                // Small Attack
                Debug.Log("Enemy: Samll Attack");
                Abilities.Kai_hp -= 10;

                if (Abilities.Kai_hp < 0)
                    Abilities.Kai_hp = 0;

                msgAction = "Amy poison spits on Kai";
            }
            else if (rand > smlAtk_range && rand <= heal_range)
            {
                //heal
                Debug.Log("Enemy: heal");
                Amy_hp += 20;

                if (Amy_hp > 100)
                    Amy_hp = 100;
                msgAction = "Amy drinks blood to heal herself!";
            }
            else if (rand > heal_range && rand <= lrgAtk_range)
            {
                // Large Attack
                Debug.Log("Enemy: Large Attack");
                Abilities.Kai_hp -= 20;

                if (Abilities.Kai_hp < 0)
                    Abilities.Kai_hp = 0;

                msgAction = "Amy lays a Powerful Curse on Kai!";
            }
            else
            {
                // Skiup turn
                Debug.Log("Enemy: Skiup Turn");
                msgAction = "Amy Skiups her Turn.";
            }
        }
    }

    public string actionMessage(string msg)
    {
        msg = msgAction;
        return msg;
    }
}
