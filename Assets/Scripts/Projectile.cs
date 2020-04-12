using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
    public float lifeTime;
    public object direction;

    private float startTime;

    private void OnTriggerEnter2D(Collider2D c)
    {
        moveSpeed = 1;
    }

    private void Start()
    {
        startTime = Time.time;
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        // print(transform.position);
        // _pos += Vector2.right * (moveSpeed * Time.deltaTime);
        // transform.Translate(_pos); //+ _axis * Mathf.Sin (Time.time * frequency) * magni
        // float x = startTime - Time.time;
        // float q = (float) (a + b*x + c*Math.Pow(x,2) + d*Math.Pow(x,3) + e*Math.Pow(x,4));
        // print(gameObject);
        transform.Translate(Vector3.right * (moveSpeed * Time.deltaTime));
        // print(Vector3.right * (moveSpeed * Time.deltaTime)
              // + _axis * q);
    }

}



/*
* SIN WAVE PROJECTTILE MOVEMENT
*/
// public class Projectile : MonoBehaviour
// {
//     public float moveSpeed;
//     public float lifeTime;
//     public object direction;
//
//     [Header("sin wave movement")]
//     public float frequency = 20f;  // Speed of sine movement
//     public float magnitude = 0.2f;   // Size of sine movement
//
//     private Vector3 _pos;
//     private Vector3 _axis;
//
//     private void Start()
//     {
//         Destroy(gameObject, lifeTime);
//         _pos = transform.position;
//         _axis = Vector3.up;
//     }
//
//     private void Update()
//     {
//         // _pos += Vector2.right * (moveSpeed * Time.deltaTime);
//         // transform.Translate(_pos); //+ _axis * Mathf.Sin (Time.time * frequency) * magni
//         transform.Translate(Vector3.right * (moveSpeed * Time.deltaTime)
//                             + _axis * Mathf.Sin(Time.time * frequency) * magnitude);
//     }
//
// }