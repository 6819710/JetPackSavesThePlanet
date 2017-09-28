using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFXControler : MonoBehaviour {

    public AudioSource smallAsteroid;
    public AudioSource mediumAsteroid;
    public AudioSource largeAsteroid;

    public AudioSource deathByWorm;
    public AudioSource deathByOxygen;

    public AudioSource thruster;
    public AudioSource enemyFound;
    
	public void playSmallAsteroid()
    {
        smallAsteroid.Play();
    }

    public void playMediumAsteroid()
    {
        mediumAsteroid.Play();
    }

    public void playLargeAsteroid()
    {
        largeAsteroid.Play();
    }

    public void playDeathByWorm()
    {
        if (!deathByWorm.isPlaying)
            deathByWorm.Play();
    }

    public void playDeathByOxygen()
    {
        if (!deathByOxygen.isPlaying)
            deathByOxygen.Play();
    }

    public void playJetpack()
    {
        if (!thruster.isPlaying)
            thruster.Play();
    }

    public void playEnemyFound()
    {
        if(!enemyFound.isPlaying)
            enemyFound.Play();
    }
}
