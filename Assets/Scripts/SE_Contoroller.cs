using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_Contoroller : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] SE_Sounds;

    [SerializeField]
    AudioSource BGM;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        BGM.Play();
    }

    public void PlayDicideSound()
    {
        audioSource.PlayOneShot(SE_Sounds[0]);
    }

    public void PlayCancelSound()
    {
        audioSource.PlayOneShot(SE_Sounds[1]);
    }

    public void PlayMainContentBtnSound()
    {
        audioSource.PlayOneShot(SE_Sounds[2]);
    }

    public void PlayAttensionSound()
    {
        audioSource.PlayOneShot(SE_Sounds[3]);
    }


}
