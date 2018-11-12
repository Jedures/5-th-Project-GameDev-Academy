using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletPcController : MonoBehaviour {

    #region vars
    [Header ("UI Elements")]
    public Text LightOnOff;
    public Slider _slider;

    [Header ("Tablet PC")]
    public GameObject TabletPc;
    public AudioClip[] audioClips;
    public AudioSource trackS;

    [Header("Light")]
    public Light DirectionalLight;
    public Light FlashLighter;

    private GameObject[] lights;
    private bool _isOpen = false;
    private bool _isOnLight = true;
    private bool _isFlashlight = false;
    #endregion

    #region UnityMethods
    void Start () {
        lights = GameObject.FindGameObjectsWithTag("Light");
        LightOnOff.text = "On";
	}
	
	
	void Update () {

        if(Input.GetKeyDown(KeyCode.Tab))
          InputController();
        if (Input.GetKeyDown(KeyCode.G))
            FlashLight();

	}
    #endregion

    #region Controller
    private void InputController()
    {
        if (_isOpen)
        {
            TabletPc.SetActive(false);
            _isOpen = false;
        }
        else
        {
            TabletPc.SetActive(true);
            _isOpen = true;
        }
    }

    private void FlashLight()
    {
        if(_isFlashlight)
        {
            _isFlashlight = false;
            FlashLighter.enabled = false;
        }
        else
        {
            _isFlashlight = true;
            FlashLighter.enabled = true;
        }
    }

    #endregion

    #region UIButtons
    public void OnOffLight()
    {
        if (_isOnLight)
        {
            for (int i = 0; i < lights.Length;i++) lights[i].GetComponent<Light>().enabled = false;
            _isOnLight = false;
            LightOnOff.text = "No";
        }
        else
        {
            for (int i = 0; i < lights.Length;i++) lights[i].GetComponent<Light>().enabled = true;
            _isOnLight = true;
            LightOnOff.text = "Yes";
        }
    }

    public void DirectionIntens()
    {
        DirectionalLight.intensity = _slider.value;
    }

    public void Audio(int i)
    {
        trackS.clip = audioClips[i];
        trackS.Play();
    }
    #endregion

}
