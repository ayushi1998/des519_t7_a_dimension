using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ayushi_TouchPlace : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject wood1Cube;
    public GameObject wood2Cube;
      public GameObject wood3Cube;
      public GameObject wood4Cube;
      public GameObject wood5Cube;
        public GameObject wood6Cube;
    public GameObject panel;
    public GameObject startpanel;
    public Button dismissButton;
public float f=0f;
    void Start()
    {
      wood1Cube.SetActive(false);
      wood2Cube.SetActive(false);
      panel.SetActive(false);
      dismissButton.onClick.AddListener(Dismiss);
    }
    private void Dismiss(){
        startpanel.SetActive(false);

    }

    /// <summary>
    /// Change material when exit the cube
    /// </summary>
    /// <param name="other">The collider that exits</param>
    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag=="cube")
      {
        wood3Cube.SetActive(false);
      }
else if (other.gameObject.tag=="wood") {
      Destroy(other.gameObject);
      wood1Cube.SetActive(true);
      wood2Cube.SetActive(true);
      wood4Cube.SetActive(true);
      f=1f;
    }
    else if(other.gameObject.tag=="nail1")
    {
      Destroy(other.gameObject);
      wood1Cube.SetActive(false);
      wood2Cube.SetActive(false);
      wood5Cube.SetActive(true);
      wood6Cube.SetActive(true);
      f=2f;
    }
      if(f==2f)
      {
        panel.SetActive(true);
        wood5Cube.SetActive(false);
      }

      }

}
