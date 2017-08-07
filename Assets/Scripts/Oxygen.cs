using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : MonoBehaviour {
    // Oxygen Resource Values
    public int oxygen;
    public int maxOxygen;

	// Use this for initialization
	void Start () {
        // Set oxygen to its max value
        oxygen = maxOxygen;
	}

    /// <summary>
    /// Applys given delta to oxygen level
    /// </summary>
    /// <param name="delta">delta, amount of oxygen to add or remove, use negitive value to remove oxygen</param>
    public void ApplyDelta(int delta)
    {
        oxygen += delta;

        // prevent oxygen overflow
        if (oxygen > maxOxygen)
            oxygen = maxOxygen;

        // prevent oxygen underflow
        if (oxygen < 0)
            oxygen = 0;
    }

    /// <summary>
    /// Checks if there is no oxygen remaining.
    /// </summary>
    /// <returns>True if there is no oxygen remaining.</returns>
    public bool Empty()
    {
        return oxygen == 0;
    }

    /// <summary>
    /// Checks if oxygen is at max.
    /// </summary>
    /// <returns>True if oxygen is at max.</returns>
    public bool Full()
    {
        return oxygen == maxOxygen;
    }
}
