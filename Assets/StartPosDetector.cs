using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosDetector : MonoBehaviour
{
    public bool isShootingTime = true;
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("player moved out from here");
        isShootingTime = false;
    }
}
