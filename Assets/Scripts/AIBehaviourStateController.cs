using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviourStateController : MonoBehaviour {

    protected AIBehaviourState previousBehaviourState = AIBehaviourState.idle;
    protected AIBehaviourState currentBehaviourState = AIBehaviourState.idle;
    protected Coroutine changingStateCoroutine;

    protected void Start() {
    }

    protected void Update() {
    }

    public void ChangeState(AIBehaviourState newBehaviourState, float timeToStayInNewState = -1, float delay =-1) {
       // if (changingStateCoroutine != null) StopCoroutine(changingStateCoroutine);
        changingStateCoroutine = StartCoroutine(ChangeStateCoroutine(newBehaviourState, timeToStayInNewState, delay));
    }

    protected IEnumerator ChangeStateCoroutine(AIBehaviourState newBehaviourState, float timeToStayInNewState = -1, float delay = -1) {
        if (newBehaviourState == currentBehaviourState)
            yield break;
        float timeToWait = delay;
        float timeRemainingInNewState = timeToStayInNewState;
        while (timeToWait > 0) {
            timeToWait -= Time.deltaTime;
            yield return null;
        }
        //Switch to new
        SwitchState(newBehaviourState);
        while (timeRemainingInNewState > 0) {
            timeRemainingInNewState -= Time.deltaTime;
            yield return null;
        }
        if (timeRemainingInNewState < 0 && timeToStayInNewState > 0) {
            //Switch back to previous
            SwitchState(previousBehaviourState);
        }
    }

    protected void SwitchState(AIBehaviourState newBehaviourState) {
        if (newBehaviourState == currentBehaviourState)
            return;
        previousBehaviourState = currentBehaviourState;
        currentBehaviourState = newBehaviourState;
    }

    public AIBehaviourState GetCurrentState() {
        return currentBehaviourState;
    }
    public AIBehaviourState GetPreviousState() {
        return previousBehaviourState;
    }
}
