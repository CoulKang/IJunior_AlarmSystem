using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private const float _alarmIncrement = 0.1f;

    [SerializeField] private AudioSource _audioSource;

    private Coroutine _volumeCoroutine;

    public void Launch()
    {
        _audioSource.Play();

        ToggleVolumeChange(1f);
    }

    public void Disable()
    {
        ToggleVolumeChange(0f);
    }

    private void ToggleVolumeChange(float targetVolue)
    {
        if (_volumeCoroutine != null)
            StopCoroutine(_volumeCoroutine);

        _volumeCoroutine = StartCoroutine(ChangeVolume(targetVolue));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _alarmIncrement * Time.deltaTime);

            yield return null;
        }

        _audioSource.volume = targetVolume;

        if (targetVolume == 0f && _audioSource.isPlaying)
            _audioSource.Stop();

        _volumeCoroutine = null;
    }
}
