using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDetector2 : MonoBehaviour
{
    public bool isReached2 = false;
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("ContactDetector2");
        isReached2 = true;
    }
}
