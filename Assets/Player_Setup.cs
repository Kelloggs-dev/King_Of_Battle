using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mirror;

public class Player_Setup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] Composant_Desactiver;

    Camera Scene_Camera;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            // Desactive les composant si le joueur n'est pas le notre
            for (int Index = 0; Index < Composant_Desactiver.Length; Index++)
            {
                Composant_Desactiver[Index].enabled = false;
            }
        }else
        {
            Scene_Camera = Camera.main;

            if(Scene_Camera != null)
            {
                Scene_Camera.gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        if(Scene_Camera != null)
        {
            Scene_Camera.gameObject.SetActive(true);
        }
    }
}
