using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private const float _alarmIncrement = 0.1f;

    [SerializeField] private AudioSource _audioSource;

    private bool _hasThiefFound = false;

    private void Update()
    {
        if (_audioSource.isPlaying && _hasThiefFound)
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1f, _alarmIncrement * Time.deltaTime);

        if (_audioSource.isPlaying && _hasThiefFound == false)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0f, _alarmIncrement * Time.deltaTime);

            if (_audioSource.volume == 0)
                _audioSource.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Owner>() == false)
        {
            _hasThiefFound = true;
            Launch();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Disable();
    }

    private void Launch() => _audioSource.Play();

    private void Disable() => _hasThiefFound = false;
}
