using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[Serializable]
public class Dialogue
{
    public string name;
    public bool choice;


    [TextArea(3,10)]
    public string[] sentences;
}
