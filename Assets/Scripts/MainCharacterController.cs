using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{
    public bool IsTouchingGround, IsFacingWall, IsFacingLedge, IsLedgeDetected, IsGrabbingLedge;

    public Transform WallDetection, LedgeDetection;

    Vector3 ledgePositionBottom, ledgePosition1, LedgePosition2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGrabbingLedge)
        {
            LedgeDetectionCheck();
        }
        CanClimbLedge();
    }

    private void LedgeDetectionCheck()
    {
        IsFacingWall = Physics.BoxCast(WallDetection.position, new Vector3(0.2f, 0.001f, 0.001f), transform.forward, Quaternion.identity, 1f);
        IsFacingLedge = Physics.BoxCast(LedgeDetection.position, new Vector3(0.2f, 0.001f, 0.001f), transform.forward, Quaternion.identity, 1f);

        if (IsFacingWall && !IsFacingLedge && !IsLedgeDetected)
        {
            //Ledge Grab here
            IsLedgeDetected = true;

            ledgePositionBottom = WallDetection.position;
        }

        if (!IsFacingWall && !IsFacingLedge && IsLedgeDetected)
        {
            IsLedgeDetected = false;
        }
    }

    private void CanClimbLedge()
    {
        if (IsLedgeDetected && !IsGrabbingLedge)
        {
            IsGrabbingLedge = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            other.gameObject.GetComponent<InteractableObject>().IsInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            other.gameObject.GetComponent<InteractableObject>().IsInRange = false;
        }
    }
}
