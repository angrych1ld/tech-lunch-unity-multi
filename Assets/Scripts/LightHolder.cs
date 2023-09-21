using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHolder : MonoBehaviour
{
    [SerializeField] private GameObject lightOffFrame;
    [SerializeField] private GameObject lightOnFrame;
    [SerializeField] private GameObject lightSource;

    public bool IsLightOn { get; private set; }

    private void Awake()
    {
        SetLightActive(true);
    }

    public void SetLightActive(bool on)
    {
        IsLightOn = on;

        lightOffFrame.SetActive(!on);
        lightOnFrame.SetActive(on);

        lightSource.SetActive(on);
    }
}
