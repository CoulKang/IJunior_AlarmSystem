using System;
using UnityEngine;

[RequireComponent (typeof(BoxCollider))]
public class House : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Owner>() == false)
            _alarm.Launch();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Owner>() == false)
            _alarm.Disable();
    }
}
