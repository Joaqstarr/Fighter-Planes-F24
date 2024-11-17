using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private float amplitude;
    
    [SerializeField] private float speed;
    
    private float startX;
    private void Start()
    {
        startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((Mathf.Sin(Time.time * speed) * amplitude) + startX, transform.position.y, transform.position.z);
    }
}
