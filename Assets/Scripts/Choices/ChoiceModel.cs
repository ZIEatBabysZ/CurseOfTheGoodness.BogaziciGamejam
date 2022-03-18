using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ChoiceModel
{

    public string title;
    public string content;
    public string infoText;
    public string goodChoice;
    public string badChoice;
    public string successChoice;
    public Decision decision;




    public enum Decision
    {
        Accept,
        Decline
    }
    
}
