using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Control : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameObject_Player;
    public BirdActions Current_Action;
    void Start()
    {
        Current_Action = BirdActions.SitShoulder;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public enum BirdActions
{
    Override = 0,
    SitShoulder = 1,
    FlyIdle = 2,
    GoAction = 3,
    ResourceDirection = 4,
}
