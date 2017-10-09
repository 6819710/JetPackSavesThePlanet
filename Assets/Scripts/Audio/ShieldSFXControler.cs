using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSFXControler : MonoBehaviour {

    public List<AudioSource> shieldSource;

    public void playRandom()
    {
        // will atempt to play a random sfx that is not playing.
        // will run number of set sfx attemps
        // if not attempt susccessfull will play first avalible sfx.
        for (int i = 0; i < shieldSource.Count; i++)
        {
            int toPlay = Random.Range(0, shieldSource.Count);
            if (!shieldSource[toPlay].isPlaying)
            {
                shieldSource[toPlay].Play();
                return;
            }
        }
        for (int j = 0; j < shieldSource.Count; j++)
        {
            if (!shieldSource[j].isPlaying)
            {
                shieldSource[j].Play();
                return;
            }
        }
    }

    public void playSource(int i)
    {
        if (!shieldSource[i].isPlaying)
        {
            shieldSource[i].Play();
            gameObject.GetComponent<DestroyAfterPlayed>().mySource = shieldSource[i];
        }
    }
}
