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

    private sbyte _durantion = 90;

    private int _remainingDurantion;

    private void Start()
    {
        Being(_durantion);
    }

    private void Update()
    {
        if (_remainingDurantion >= 0 && Player.GetComponent<PlayerHealth>()._playerHealth <= 0)
        { 

        }
    }

    private void Being(int Second)
    {
        _remainingDurantion = Second;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (_remainingDurantion >= 0 && Player.GetComponent<PlayerHealth>()._playerHealth >= 0)
        {
            uiText.text = $"{_remainingDurantion}";
            uiFill.fillAmount = Mathf.InverseLerp(0, _durantion, _remainingDurantion);
            _remainingDurantion--;
            yield return new WaitForSeconds(1f);
        }
        OnEnd();
    }

    public void OnEnd()
    {
        canvasVictory.SetActive(true);
    }
}
