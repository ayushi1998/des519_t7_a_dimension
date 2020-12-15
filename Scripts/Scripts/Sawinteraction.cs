using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARSession))]
public class Sawinteraction : MonoBehaviour
{
    public Text sessionStatusText;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (ARSession.state == ARSessionState.SessionTracking)
        {
            FollowPlamCenter();
        }

    }
    public GameObject saw;
    private TrackingInfo tracking;
    public Vector3 currentPosition;
    private void FollowPlamCenter()
    {
        HandInfo currentlyDetectedHand = ManomotionManager.Instance.Hand_infos[0].hand_info;
        Debug.Log(currentlyDetectedHand);
        ManoClass currentlyDetectedManoClass = currentlyDetectedHand.gesture_info.mano_class;

        Vector3 palmCenterPosition = currentlyDetectedHand.tracking_info.palm_center;
        sessionStatusText.text = palmCenterPosition.ToString();

        if (currentlyDetectedManoClass == ManoClass.GRAB_GESTURE)
        {
            GameObject item = Instantiate(saw);
            tracking = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info;
            currentPosition = Camera.main.ViewportToWorldPoint(new Vector3(tracking.palm_center.x, tracking.palm_center.y, tracking.depth_estimation));
            sessionStatusText.text = currentPosition.ToString();

            item.transform.position = currentPosition;

        }


    }
    ///<summary>
    /// </summary>
    ///<param name="other"></param>

    private void onTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="wood")
        {
            Handheld.Vibrate();
            Destroy(other.gameObject);
        }
    }


}
