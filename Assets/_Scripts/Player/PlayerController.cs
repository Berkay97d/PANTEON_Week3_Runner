using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private float limX;
    
    public static PlayerController Instance { get; private set; }
    private void OnEnable() 
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
    private void Update()
    {
        if (!GameController.isLevelStarted || GameController.Status is GameStatus.Lost or GameStatus.Win)
        {
            return;
        }
        
        MoveForward();
        MoveHorizontal();
    }

    private void MoveForward()
    {
        var newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + forwardSpeed * Time.deltaTime);
        transform.position = newPos;
    }

    private void MoveHorizontal()
    {

        float horizontalInput;
        

        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1;
        }
        else
        {
            horizontalInput = 0;
        }
        
        Debug.Log(horizontalInput);
        transform.Translate(Vector3.right * horizontalInput * horizontalSpeed * Time.deltaTime);
        
        if (transform.position.x > limX)
        {
            transform.position = new Vector3(limX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -limX)
        {
            transform.position = new Vector3(-limX, transform.position.y, transform.position.z);
        }
    }
    
    
}
