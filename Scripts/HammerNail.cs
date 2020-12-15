using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HammerNail : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject panel;
    public GameObject startpanel;
    public float f;
    public AudioSource audio;
    public Button dismissButton;
    void Start()
    {
      panel.SetActive(false);
      dismissButton.onClick.AddListener(Dismiss);
      f=1f;
       audio = GetComponent<AudioSource>();
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
      
      if(other.gameObject.tag=="nail1")
      {

        audio.Play();
         Destroy(other.gameObject);
      }
      if(other.gameObject.tag=="nail2")
      {
        Destroy(other.gameObject);
        f=0f;

        //  Destroy(other.gameObject);
      }
      if(f==0f)
      {
        panel.SetActive(true);
      }
    }
}
