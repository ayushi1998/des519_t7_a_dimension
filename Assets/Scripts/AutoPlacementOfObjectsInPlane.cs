using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlaneManager))]
public class AutoPlacementOfObjectsInPlane : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    //[SerializeField]
    //private GameObject welcomePanel;

    [SerializeField]
    private GameObject placedPrefab_woodPlank;

    private GameObject placedObject_woodPlank;

    [SerializeField]
    private ARPlaneManager arPlaneManager;

    private void Start()
    {

    }

    void Awake()
    {
        //dismissButton.onClick.AddListener(Dismiss);
        arPlaneManager = GetComponent<ARPlaneManager>();
        arPlaneManager.planesChanged += PlaneChanged;
    }

    private void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if (args.added != null && placedObject_woodPlank == null)
        {
            ARPlane arPlane = args.added[0];
            placedObject_woodPlank = Instantiate(placedPrefab_woodPlank, arPlane.transform.position, arPlane.transform.rotation);

        }
    }
}
