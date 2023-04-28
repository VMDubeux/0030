using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject canvasVictory;
    [SerializeField] private GameObject MenuManager;
    [SerializeField] private Image uiFill;
    [SerializeField] private Text uiText;
    public GameObject Player;

    public int Durantion;

    private int remainingDurantion;

    private void Start()
    {
        Being(Durantion);
    }

    private void Update()
    {
        if (remainingDurantion >= 0 && Player.GetComponent<PlayerHealth>()._playerHealth <= 0)
        { 

        }
    }

    private void Being(int Second)
    {
        remainingDurantion = Second;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDurantion >= 0 && Player.GetComponent<PlayerHealth>()._playerHealth >= 0)
        {
            uiText.text = $"{remainingDurantion / 60:00} : {remainingDurantion % 60:00}";
            uiFill.fillAmount = Mathf.InverseLerp(0, Durantion, remainingDurantion);
            remainingDurantion--;
            yield return new WaitForSeconds(1f);
        }
        OnEnd();
    }

    public void OnEnd()
    {
        canvasVictory.SetActive(true);
    }
}
