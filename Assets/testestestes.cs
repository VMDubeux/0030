using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colidor : MonoBehaviour
{
    private Rigidbody rb;
  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube")) // Certifique-se de que o objeto colidido seja um cubo, se necess�rio.
        {
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse); // Adiciona uma for�a para cima (no eixo Y) como um impulso.

        }
    }
}