using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verification : MonoBehaviour
{
    public GameObject ImagemCanvas;
    [SerializeField] private Verification[] _input = new Verification[2];
    [SerializeField] private Verification _output;
    [SerializeField] private bool _status;

    private void Active()
    {
        _status = true;
        if (_output != null && _status)
            _output.Connect();
    }

    private void OnMouseDown()
    {
        Active();
        gameObject.SetActive(false);
    }

    private void Connect()
    {
        for (int i = 0; i < _input.Length; i++)
        {
            if (_input[i]._status == false)
            {
                _status = false;
                return;
            }
        }

        _status = true;
        gameObject.SetActive(true);

        if (_output != null && _status)
            _output.Connect();
    }
}
