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
