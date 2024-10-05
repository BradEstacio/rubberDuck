using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureSwitch : MonoBehaviour
{
    [SerializeField] private SwitchDoor currentDoor;
    public GameObject associatedSpider;

    void Update()
    {
        if(associatedSpider.gameObject.activeSelf)
        {
            currentDoor.RemovePressureSwitch(this);
        }
    }
 
    private void OnTriggerStay(Collider other)
    {
        currentDoor.AddPressureSwitch(this);
    }

    private void OnTriggerExit(Collider other)
    {
        currentDoor.RemovePressureSwitch(this);
    }
}
