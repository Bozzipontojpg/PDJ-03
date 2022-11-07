using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private int _snakeLength = 3;
    [SerializeField]
    private TrailRenderer _trailRenderer;
    private float snakeSpeed => speed * Time.deltaTime;
    private Vector3 direction => new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    private Vector3 rawDirection => new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    private Vector3 lastDirection;
    private Vector3 smoothDirection;
    private float trailTime => _snakeLength * 0.1f;
    
    private void Start()
    {
        _trailRenderer.time = trailTime;
        lastDirection = transform.forward;
    }

    private void Update()
    {
        if (rawDirection.magnitude < 1f)
        {
            var dir = new Vector3(Mathf.Clamp(lastDirection.x * 10, -1, 1), 0,
                Mathf.Clamp(lastDirection.z * 10, -1, 1));
            smoothDirection = Vector3.Lerp(smoothDirection, dir, Time.deltaTime * 3);
        }
        else
        {
            lastDirection = direction;
            var distance = Vector3.Distance(smoothDirection, lastDirection);
            var lerpTime = Time.deltaTime * (distance*speed);
            
            smoothDirection = Vector3.Lerp(smoothDirection, lastDirection, Mathf.Clamp(lerpTime, .0001f, 10));
        }
        
        transform.Translate(smoothDirection * snakeSpeed, Space.World);
    }

    private void AddBody()
    {
        _snakeLength++;
        _trailRenderer.time = trailTime;
    }

    public void UpdatePoints(int value)
    {
        _snakeLength += value;
        _trailRenderer.time = trailTime;
    }

    public void StartGame()
    {
        UpdatePoints(1);
        transform.position = Vector3.zero;
        Debug.Log(_snakeLength);
    }
    
    public void EndGame()
    {
        UpdatePoints(-_snakeLength);
        _trailRenderer.Clear();
        transform.position = Vector3.zero;
    }

    private void OnTriggerEnter(Collider col)
    { 
        if(col.CompareTag("Wall"))
        {
            lastDirection *= -1;
            smoothDirection *= -1;
            
            if(_snakeLength <= 0) Destroy(gameObject);
        }
    }
}
