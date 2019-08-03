using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Pawn ControlledPawn;

    private void Update()
    {
        HandleInput();
    }

    protected virtual void HandleInput()
    {
        ControlledPawn?.PassMovementHorizontal(Input.GetAxis("Horizontal"));
        ControlledPawn?.PassMovementVertical(Input.GetAxis("Vertical"));
        ControlledPawn?.PassJump(Input.GetButtonDown("Jump"));
        ControlledPawn?.PassSprint(Input.GetButton("Sprint"));
        ControlledPawn?.PassCrouch(Input.GetButton("Crouch"));

        ControlledPawn?.PassLook(new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")));

        if(Input.GetButtonDown("Cancel"))
        {
            ControlledPawn?.ToggleCursorLock();
        }
    }
}
