using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Abilities : MonoBehaviour
{
    public TMPro.TextMeshProUGUI BattleText;

    private BattleScript battle;

    public static int Kai_hp = 100;

    [Header("Entity's")]
    public EnemyBattle enemy;

    [Header("Particle System")]
    public ParticleSystem P_particle;

    // Start is called before the first frame update
    void Start()
    {
        if (Kai_hp == 0)
            Kai_hp = 100;
        battle = FindObjectOfType<BattleScript>();

        P_particle.Stop();
        
        enemy = FindObjectOfType<EnemyBattle>();
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

        StartCoroutine(enemy.E_ParticleEff(Color.yellow));
        battle.ChangeTurns();
    }

    //Major Attack
    public void OnAttack2Pressed()
    {
        BattleText.text = "Kai fires Lazers.";
        EnemyBattle.Amy_hp -= 25;

        if (EnemyBattle.Amy_hp < 0)
            EnemyBattle.Amy_hp = 0;

        StartCoroutine(enemy.E_ParticleEff(Color.red));
        battle.ChangeTurns();
    }

    // Heal Yourself
    public void OnHealPressed()
    {
        BattleText.text = "Kai eats an Apple to heal himself.";
        Kai_hp += 15;

        if (Kai_hp > 100)
            Kai_hp = 100;

        StartCoroutine(P_ParticleEff(Color.green));
        battle.ChangeTurns();
    }

    // Flee back to the level Map.
    public void OnFleePressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public IEnumerator P_ParticleEff(Color clr)
    {
        P_particle.startColor = clr;
        P_particle.Play();
        yield return new WaitForSeconds(1);
        P_particle.Stop();
    }
}
