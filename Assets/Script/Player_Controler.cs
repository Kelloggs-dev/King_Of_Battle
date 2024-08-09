using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Player_Motor))]
public class Player_Controler : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    [SerializeField]
    private float Sensibilite_MouseX;

    [SerializeField]
    private float Sensibilite_MouseY;

    private Player_Motor Motor;

    private void Start()
    {
        Motor = GetComponent<Player_Motor>();
    }

    private void Update()
    {

        // Calcule du deplacement du joueur 
        float X_Mouve = Input.GetAxisRaw("Horizontal");
        float Z_Mouve = Input.GetAxisRaw("Vertical");

        Vector3 Deplacement_Horizontal = transform.right * X_Mouve;
        Vector3 Deplacement_Vertical = transform.forward * Z_Mouve;

        Vector3 Velocite = (Deplacement_Horizontal + Deplacement_Vertical).normalized * Speed;

        Motor.Deplace_Toi(Velocite);

        // Calcule rotation du joueur 
        float Y_Rot = Input.GetAxisRaw("Mouse X");

        Vector3 Rotation = new Vector3(0, Y_Rot, 0) * Sensibilite_MouseX;

        Motor.Rotation(Rotation);

        // Calcule rotation de la camera 
        float X_Rot = Input.GetAxisRaw("Mouse Y");

        Vector3 Camera_Rotation = new Vector3(X_Rot,0, 0) * Sensibilite_MouseY;

        Motor.Camera_Rotation(Camera_Rotation);
    }
}
