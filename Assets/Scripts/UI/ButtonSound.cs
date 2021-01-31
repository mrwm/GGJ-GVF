using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource mySFX;
    public AudioClip HoverFx;
    public AudioClip ClickFx;
    public AudioClip BackFx;
    public void BackButton_Hover()
    {
        mySFX.PlayOneShot(BackFx);
    }
    public void HoverSound()
    {
        mySFX.PlayOneShot(HoverFx);
    }

    public void ClickSound()
    {
        mySFX.PlayOneShot(ClickFx);
    }
}
