using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private const float _alarmIncrement = 0.1f;

    [SerializeField] private AudioSource _audioSource;

    private bool _isActive = false;

    private void Update()
    {
        if (_audioSource.isPlaying && _isActive)
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1f, _alarmIncrement * Time.deltaTime);

        if (_audioSource.isPlaying && _isActive == false)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0f, _alarmIncrement * Time.deltaTime);

            if (_audioSource.volume == 0)
                _audioSource.Stop();
        }
    }

    public void Launch()
    {
        _isActive = true;
        _audioSource.Play();
    }

    public void Disable() => _isActive = false;
}
