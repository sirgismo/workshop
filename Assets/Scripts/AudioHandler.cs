using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioClip _secondClip ;
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            _audioSource.clip = _secondClip;
            _audioSource.Play();
        }
    }
    // Update is called once per frame

}
