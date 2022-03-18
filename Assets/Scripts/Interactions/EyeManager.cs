using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeManager : MonoBehaviour
{
    public GameObject eye;
    public CharacterInfo player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInfo>();
    }


    private void FixedUpdate()
    {
        if(player.candleCount >= 2)
        {
            if(eye != null) { 
            eye.gameObject.SetActive(true);
            }
        }
    }


}
