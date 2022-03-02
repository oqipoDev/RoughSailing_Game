using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public float RotationDuration = 1;

    private enum CamState {Moving, NotMoving}

    private CamState CurrentState = CamState.NotMoving;

    private float SmoothVal, SmoothVelRef;
    private Quaternion  NextRotation, PrevRotation;
    private float RotState;

    // Update is called once per frame
    void Update()
    {
        switch(CurrentState)
        {
            case CamState.NotMoving:
                //Look for move request     
                if (Input.GetKey(KeyCode.Semicolon))
                {
                    SetCamRot(false);
                }
                else if (Input.GetKey(KeyCode.L))
                {
                    SetCamRot(true);
                }
            break;

            case CamState.Moving:
                //Smooth
                SmoothVal = Mathf.SmoothDamp(SmoothVal, 1, ref SmoothVelRef, RotationDuration);
                //Rotate according to smoothed value
                transform.rotation = Quaternion.Lerp(PrevRotation, NextRotation, SmoothVal / 10);

                //Exit movement
                if(1 - SmoothVal < 0.001f)
                {
                    CurrentState = CamState.NotMoving;
                    transform.rotation = NextRotation;
                }
            break;

            default:
            break;
        }
    }

    void SetCamRot(bool positive)
    {
        PrevRotation = transform.rotation;

        if (positive)
        {
            transform.Rotate(90 * Vector3.up, Space.World);
        }
        else
        {
            transform.Rotate(-90 * Vector3.up, Space.World);
        }

        NextRotation = transform.rotation;

        transform.rotation = PrevRotation;

        CurrentState = CamState.Moving;
        SmoothVal = 0;
    }
}
