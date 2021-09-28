using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassController : MonoBehaviour
{
    public Image compass, arrow;

    public Transform Target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateArrow();
    }

    public void UpdateCompass()
    { 
        
    }

    public void UpdateArrow()
    {
        Vector3 dir = GameController.instance.mainCharacter.transform.position;
        dir = new Vector3(dir.x, 0, dir.z) - new Vector3(Target.position.x, 0, Target.position.z);

        float angle = Vector3.SignedAngle(dir, Vector3.forward, Vector3.up) + 180;

        arrow.rectTransform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
