using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameText : MonoBehaviour
{
    private Text nameText;
    private void Start()
    {
        nameText = GetComponent<Text>();
        nameText.text = "Player " + GameHandler.InName;      
    }
 }
