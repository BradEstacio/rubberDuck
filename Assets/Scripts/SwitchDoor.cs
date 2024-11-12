using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoor : MonoBehaviour
{
    public bool doorOpen = false;
    public GameObject door;

    private int requiredSwitchesOpen = 1;

    private List<PressureSwitch> currentSwitchesOpen = new();
    
    public void AddPressureSwitch(PressureSwitch currentSwitch)
    {
        if(!currentSwitchesOpen.Contains(currentSwitch))
        {
            currentSwitchesOpen.Add(currentSwitch);
        }
        TryOpen();
    }

    public void RemovePressureSwitch(PressureSwitch currentSwitch)
    {
        if(currentSwitchesOpen.Contains(currentSwitch))
        {
            currentSwitchesOpen.Remove(currentSwitch);
        }
        TryOpen();
    }

    private void TryOpen()
    {
        if(currentSwitchesOpen.Count == requiredSwitchesOpen)
        {
            OpenDoor();
        }
        else if(currentSwitchesOpen.Count < requiredSwitchesOpen)
        {
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        doorOpen = true;
        door.gameObject.SetActive(false);
    }

    private void CloseDoor()
    {
        doorOpen = false;
        door.gameObject.SetActive(true);
    }
}
