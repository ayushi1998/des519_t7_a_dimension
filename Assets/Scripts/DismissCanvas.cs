using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine;
using UnityEngine.UI;
public class DismissCanvas : MonoBehaviour
{

    public GameObject welcomePanel;
    public Button dismissButton;
    public GameObject secondPanel;

    // Start is called before the first frame update
    void Start()
    {
        dismissButton.onClick.AddListener(Dismiss);
    }

    private void Dismiss(){
        welcomePanel.SetActive(false);
        secondPanel.SetActive(true);
    } 



    // Update is called once per frame
    void Update()
    {
        
    }
}
