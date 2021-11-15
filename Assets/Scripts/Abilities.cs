using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Abilities : MonoBehaviour
{
    public TMPro.TextMeshProUGUI BattleText;

    // Start is called before the first frame update
    void Start()
    {
        BattleText.text = "You have encountered an Enemy!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAttack1Pressed()
    {
        BattleText.text = "You Punched the Enemy.";
    }

    public void OnAttack2Pressed()
    {
        BattleText.text = "You fire Lazers";
    }

    public void OnHealPressed()
    {
        BattleText.text = "You have gave yourself health";
    }

    public void OnFleePressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
