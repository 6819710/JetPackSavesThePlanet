using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenSFXControler : MonoBehaviour {

    public List<AudioSource> oxygenSlurp;

    public void playOxygenSlurp()
    {
        // will atempt to play a random sfx that is not playing.
        // will run number of set sfx attemps
        // if not attempt susccessfull will play first avalible sfx.
        for (int i = 0; i < oxygenSlurp.Count; i++)
        {
            int toPlay = Random.Range(0, oxygenSlurp.Count);
            if (!oxygenSlurp[toPlay].isPlaying)
            {
                oxygenSlurp[toPlay].Play();
                return;
            }
        }
        for (int j = 0; j < oxygenSlurp.Count; j++)
        {
            if (!oxygenSlurp[j].isPlaying)
            {
                oxygenSlurp[j].Play();
                return;
            }
        }
    }
}
