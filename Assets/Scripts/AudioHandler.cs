using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioHandler : MonoBehaviour
{
    #region Variables
    public AudioMixer masterAudio;
    #endregion
    public void ChangeVolume(float volume)
    {
        masterAudio.SetFloat("Volume", volume);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
