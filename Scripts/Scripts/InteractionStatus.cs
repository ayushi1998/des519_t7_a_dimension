using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARSession))]

public class InteractionStatus : MonoBehaviour
{
    public Text sessionStatusText;
    // Start is called before the first frame update
    void Start()
    {
        ARSession.stateChanged += HandleStateChanged;

    }

    // Update is called once per frame
    /// <summary>
    /// </summary>
    /// <param name="stateEventArguments"></param>
   private void HandleStateChanged(ARSessionStateChangedEventArgs stateEventArguments)
    { 
    switch(stateEventArguments.state)
    {
        case ARSessionState.None:
            sessionStatusText.text = "Session Status Unkown";
            break;

        case ARSessionState.Unsupported:
            sessionStatusText.text = "Session Status ARFoundation not supported";
            break;
        case ARSessionState.CheckingAvailability:
            sessionStatusText.text = "CheckingAvailability";
            break;
        case ARSessionState.NeedsInstall:
            sessionStatusText.text = "NS";
            break;

        case ARSessionState.Installing:
            sessionStatusText.text = "Installing";
            break;
        case ARSessionState.Ready:
            sessionStatusText.text = "Ready";
            break;
        case ARSessionState.SessionInitializing:
            sessionStatusText.text = "Poor slam";
            break;

        case ARSessionState.SessionTracking:
            sessionStatusText.text = "T is good";
            break;
        default:
            sessionStatusText.text = "Unkown";
            break;
    }
}
}
