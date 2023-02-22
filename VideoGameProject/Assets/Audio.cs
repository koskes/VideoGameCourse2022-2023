using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
  public void MuteButton(bool muted)
    {
        if (muted)
        {
            AudioListener.volume= 1;
        }
        else
        {
            AudioListener.volume= 0;
        }
    }
}
