using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    InputMaster controls;

    private void Awake()
    {

        controls = new InputMaster();
        controls.Default.Enable();

        //controls.Player.Move.performed += ctx =>

    }
}