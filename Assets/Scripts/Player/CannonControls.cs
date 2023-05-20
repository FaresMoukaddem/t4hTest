using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class CannonControls : MonoBehaviour
{
    public PlayerInput playerInput;
    
    public GameObject objectToRotate;

    public float multiplier;

    public float maxAngle = 35;

    private bool isClicked;

    private Vector3 tempVec3;

    [HideInInspector]
    public UnityEvent OnCannonShoot;

    private bool controlsToggled;

    public void ToggleControls(bool on)
    {
        if((controlsToggled && on) || (!controlsToggled && !on)) return;

        if(on)
        {
            playerInput.enabled = true;
            controlsToggled = true;

            playerInput.actions.FindAction("Fire").performed += OnClicked;
            playerInput.actions.FindAction("Fire").canceled += OffClicked;
            playerInput.actions.FindAction("Look").performed += OnLooked;
        }
        else
        {
            controlsToggled = false;

            playerInput.actions.FindAction("Fire").performed -= OnClicked;
            playerInput.actions.FindAction("Fire").canceled -= OffClicked;
            playerInput.actions.FindAction("Look").performed -= OnLooked;

            playerInput.enabled = false;
        }
    }

    void OnClicked(InputAction.CallbackContext ctx)
    {
        if(!isClicked)
        {
            isClicked = true;
        }
    }

    void OffClicked(InputAction.CallbackContext ctx)
    {
        if(isClicked)
        {
            isClicked = false;
            OnCannonShoot?.Invoke();
        }
    }

    void OnLooked(InputAction.CallbackContext ctx)
    {
        if(isClicked)
        {
            objectToRotate.transform.Rotate(new Vector3(0, ctx.ReadValue<Vector2>().x * multiplier,0), Space.Self);

            LimitRotation();
        }
    }

    void LimitRotation()
    {
        tempVec3 = objectToRotate.transform.localEulerAngles;

        tempVec3.y = (tempVec3.y > 180) ? tempVec3.y - 360 : tempVec3.y;
        tempVec3.y = Mathf.Clamp(tempVec3.y, -maxAngle, maxAngle);
        tempVec3.x = 0;
        tempVec3.z = 0;

        objectToRotate.transform.localRotation = Quaternion.Euler(tempVec3);
    }
}
