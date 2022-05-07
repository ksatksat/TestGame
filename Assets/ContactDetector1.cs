using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDetector1 : MonoBehaviour
{
    public bool isReached1 = false;
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("ContactDetector1");
        isReached1 = true;
    }
}
