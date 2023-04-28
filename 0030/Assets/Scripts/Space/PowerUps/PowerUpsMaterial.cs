using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsMaterial : MonoBehaviour //Animar os PowerUps com mudanças de cor.
{
    Material PowerUps;

    void Start()
    {
        PowerUps = GetComponent<Renderer>().material;
        InvokeRepeating("ChangeColor", 1.5f, 1.5f);
    }

    void ChangeColor()
    {
        PowerUps.color = Color.HSVToRGB(Random.Range(0, 1.0f), 1, 1);
    }
}
