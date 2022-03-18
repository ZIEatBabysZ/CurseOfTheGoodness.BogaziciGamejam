using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public CharacterInfo playerInfo;
    public Slider slider;


    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    private void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInfo>();

        slider.minValue = 0;
        slider.maxValue = playerInfo.maxCurse;
    }


    private void Update()
    {
        slider.value = playerInfo.currentCurse;
    }
}
