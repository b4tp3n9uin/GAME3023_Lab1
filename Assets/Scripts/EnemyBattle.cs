using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle : MonoBehaviour
{
    string msgAction;

    public static int Amy_hp = 100;

    [Header("Particle System")]
    public ParticleSystem E_particle;
    public Abilities player;

    // Start is called before the first frame update
    void Start()
    {
        if (Amy_hp == 0)
            Amy_hp = 100;

        player = FindObjectOfType<Abilities>();
        E_particle.Stop();
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
            Heal();
        }
        else if (Abilities.Kai_hp < player_lowHealth)
        {
            //if Enemy knows player is low on health, she will use powerful attacks to try to win the battle.
            LargeAttack();
        }
        else
        {
            if (rand <= smlAtk_range)
            {
                // Small Attack
                SmallAttack();
            }
            else if (rand > smlAtk_range && rand <= heal_range)
            {
                //heal
                Heal();
            }
            else if (rand > heal_range && rand <= lrgAtk_range)
            {
                // Large Attack
                LargeAttack();
            }
            else
            {
                // Skiup turn
                SkiupTurn();
            }
        }
    }

    public string actionMessage(string msg) // Function is called in BattleScript to change the Text in the Pannel.
    {
        msg = msgAction;
        return msg;
    }

    void SmallAttack() // Actions for the small attack
    {
        Debug.Log("Enemy: Samll Attack");
        Abilities.Kai_hp -= 10;
        if (Abilities.Kai_hp < 0)
            Abilities.Kai_hp = 0;

        StartCoroutine(player.P_ParticleEff(Color.magenta));
        msgAction = "Amy poison spits on Kai";
    }

    void LargeAttack() // Actions for the large attack
    {
        Debug.Log("Enemy: Large Attack");
        Abilities.Kai_hp -= 20;
        if (Abilities.Kai_hp < 0)
            Abilities.Kai_hp = 0;

        StartCoroutine(player.P_ParticleEff(Color.black));
        msgAction = "Amy lays a Powerful Curse on Kai!";
    }

    void Heal() // Actions for heal
    {
        
        Debug.Log("Enemy: heal");
        Amy_hp += 20;

        if (Amy_hp > 100)
            Amy_hp = 100;

        StartCoroutine(E_ParticleEff(Color.blue));
        msgAction = "Amy drinks blood to heal herself!";
    }

    void SkiupTurn() // SKiup sKiuP skiuppity SKIUUUUUPPPPP!  Skiup is a MEME from https://www.youtube.com/watch?v=Pqf5b2JFEsA
    {
        Debug.Log("Enemy: Skiup Turn");
        msgAction = "Amy Skiups her Turn.";
    }

    public IEnumerator E_ParticleEff(Color clr)
    {
        E_particle.startColor = clr;
        E_particle.Play();
        yield return new WaitForSeconds(1);
        E_particle.Stop();
    }
}
