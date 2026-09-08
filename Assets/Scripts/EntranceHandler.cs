using UnityEngine;

public class EntranceHandler : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Owner>() == null)
            _alarm.Launch();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Owner>() == null)
            _alarm.Disable();
    }
}
