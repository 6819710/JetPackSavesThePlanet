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
    
	public void playAsteroidCollision(AsteroidSizes size)
    {
		switch (size) {
			case AsteroidSizes.Small:
				smallAsteroid.Play ();
				break;
			case AsteroidSizes.Medium:
				mediumAsteroid.Play ();
				break;
			case AsteroidSizes.Large:
				largeAsteroid.Play ();
				break;
		}
    }

	public void playDeath(Health.DamageType cause)
	{
		switch (cause) {
			case Health.DamageType.Suffocation:
				playDeathByOxygen ();
				break;
			case Health.DamageType.Worm:
				playDeathByWorm ();
				break;
		}
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
