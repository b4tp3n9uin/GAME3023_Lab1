using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI InBattleText;
    public GameObject AbilityPannel;


    float TimeBetweenChars = 0.1f;
    

    private IEnumerator animateTextCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        // Animate Text for Encounter
        animateTextCoroutine = AnimateTextCoroutine("You have Encountered an Enemy!");
        StartCoroutine((animateTextCoroutine));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator AnimateTextCoroutine(string message)
    {
        AbilityPannel.SetActive(false);
        InBattleText.text = "";

        for (int currentChar = 0; currentChar < message.Length; currentChar++)
        {
            InBattleText.text += message[currentChar];
            yield return new WaitForSeconds(TimeBetweenChars);
        }
        AbilityPannel.SetActive(true);
        animateTextCoroutine = null;
    }
    
}
