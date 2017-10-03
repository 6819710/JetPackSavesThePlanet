using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAsteroidSFXControler : MonoBehaviour {

    public List<AudioSource> iceAsteroidSource;

    public void playRandom()
    {
        // will atempt to play a random sfx that is not playing.
        // will run number of set sfx attemps
        // if not attempt susccessfull will play first avalible sfx.
        for (int i = 0; i < iceAsteroidSource.Count; i++)
        {
            int toPlay = Random.Range(0, iceAsteroidSource.Count);
            if (!iceAsteroidSource[toPlay].isPlaying)
            {
                iceAsteroidSource[toPlay].Play();
                return;
            }
        }
        for (int j = 0; j < iceAsteroidSource.Count; j++)
        {
            if (!iceAsteroidSource[j].isPlaying)
            {
                iceAsteroidSource[j].Play();
                return;
            }
        }
    }
}
