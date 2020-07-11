﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightWayMovement : MonoBehaviour
{

    public float velocity;
    public float turnSpeed;

    Vector2 input;
    float angle;

    Quaternion targetRotation;
    Transform cam;

    Animator anim;


    void Start()
    {
        cam = Camera.main.transform;
        anim = GetComponent<Animator>();
    }

     void Update()
     {
        GetInput();
        if (Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1) return;

        CalculateDirection();
        Rotate();
        Move();
     }

    void GetInput() {

        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        anim.SetFloat("InputX", input.x);
        anim.SetFloat("InputY", input.y);

    }

    void CalculateDirection() {

        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle;
        angle += cam.eulerAngles.y;

    }

    void Rotate() {

        targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    void Move() {

        transform.position += transform.forward * velocity * Time.deltaTime;

    }
}
