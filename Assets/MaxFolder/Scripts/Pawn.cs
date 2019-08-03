using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public LookScript myLookScript;
    public MovementScript myMoveScript;
    
    public void PassMovementHorizontal(float value)
    {
        myMoveScript?.MoveHorizontal(value);
    }
    public void PassMovementVertical(float value)
    {
        myMoveScript?.MoveVertical(value);
    }
    public void PassJump(bool value)
    {
        myMoveScript?.Jump(value);
    }
    public void PassSprint(bool value)
    {
        myMoveScript?.Sprint(value);
    }
    public void PassCrouch(bool value)
    {
        myMoveScript?.Crouch(value);
    }

    public void PassLook(Vector2 value)
    {
        if(myLookScript)
        {
            myLookScript.MouseInput = value;
        }
    }
}
