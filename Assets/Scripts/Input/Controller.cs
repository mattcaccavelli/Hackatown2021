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

        controls.Default.Move.performed += ctx => FarmManager.player.SetMove(ctx.ReadValue<Vector2>());
        controls.Default.Move.canceled += _ => FarmManager.player.SetMove(Vector2.zero);

        controls.Default.Interact.performed += _ => FarmManager.player.Interact();
    }
}