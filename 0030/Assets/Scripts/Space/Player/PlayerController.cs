using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private byte _speedPlayer = 120;
    private float xAxis, yAxis;
    private float moveAmount;

    void Start()
    {

    }

    private void Update()
    {
        moveAmount = _speedPlayer * Time.deltaTime;

        ShipMovementInput();
        
        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
            moveAmount *= 2;

        ShipMovementConsederingSceneLimits();
    }

    void FixedUpdate()
    {
        
    }

    private void ShipMovementInput()
    {
        xAxis = Input.GetAxis("Horizontal") * moveAmount;
        yAxis = Input.GetAxis("Vertical") * moveAmount;
    }

    private void ShipMovementConsederingSceneLimits()
    {
        Vector3 totalMovement = new Vector3(xAxis, yAxis, 0.0f);

        Vector3 movementIfApplied = totalMovement + transform.position;

        if (movementIfApplied.x <= -50)
            transform.position = new Vector3(-49.95f, transform.position.y, 0.0f);

        if (movementIfApplied.y >= 100)
            transform.position = new Vector3(transform.position.x, 99.95f, 0.0f);

        if (movementIfApplied.y <= -100)
            transform.position = new Vector3(transform.position.x, -99.95f, 0.0f);

        transform.Translate(totalMovement);
    }
}
