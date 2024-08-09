using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Player_Motor : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    private Vector3 Velocite;
    private Vector3 Rotation_;
    private Vector3 Rotation_Camera_;
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Deplace_Toi(Vector3 P_Velocite)
    {
        Velocite = P_Velocite;
    }

    public void Rotation(Vector3 P_Rotation)
    {
        Rotation_ = P_Rotation;
    }

    public void Camera_Rotation(Vector3 P_Camera_Rotation)
    {
        Rotation_Camera_ = P_Camera_Rotation;
    }

    private void FixedUpdate()
    {
        Effecttue_Le_Deplacement();
        Effectue_Rotation();
    }

    private void Effectue_Rotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(Rotation_));
        camera.transform.Rotate(-Rotation_Camera_);
    }

    private void Effecttue_Le_Deplacement()
    {
        if(Velocite != Vector3.zero)
        {
            rb.MovePosition(rb.position + Velocite * Time.fixedDeltaTime);
        }
    }
}
