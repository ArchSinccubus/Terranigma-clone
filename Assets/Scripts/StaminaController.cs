using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.UI;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class StaminaController : MonoBehaviour
{
    [SerializeField] float MaxStamina;

    [SerializeField] float StaminaRechargeMultiplier;

    ThirdPersonCharacter Character;

    public float currStamina;

    public bool StaminaFinished;

    public bool usingStamina;
    public bool RunOutOfStamina;
    public bool rechargingStamina;

    public Slider StaminaBar;

    // Start is called before the first frame update
    void Start()
    {
        currStamina = MaxStamina;

        Character = GetComponent<ThirdPersonCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        usingStamina = Input.GetKey(KeyCode.LeftControl) || Character.getUsingStamina();

        Character.setRechargingStamina(RunOutOfStamina);

        if (usingStamina)
        {
            currStamina -= Time.deltaTime;
            if (currStamina <= 0)
            {
                usingStamina = false;
                RunOutOfStamina = true;
                rechargingStamina = true;
            }
        }
        else rechargingStamina = true;

        if (rechargingStamina)
        {
            currStamina += Time.deltaTime / StaminaRechargeMultiplier;
            if (currStamina >= MaxStamina)
            {
                currStamina = MaxStamina;
                RunOutOfStamina = false;
                rechargingStamina = false;
            }
        }

        StaminaBar.value = Mathf.Clamp(currStamina / MaxStamina, 0, 1);
    }
}
