using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject _canvasWin;
    [SerializeField] AudioSource _audioSource;
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Head"))
        {
            Time.timeScale = 0;
            _audioSource.Play();
            Instantiate(_canvasWin);
        }
    }
}
