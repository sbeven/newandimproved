﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputName : MonoBehaviour
{
    public GameObject inputField;
    public Text Score;

    private void Awake()
    {
        if(PermanentUI.perm.points >= 2000)
        {
            Score.text = "Congratulations! You scored " + PermanentUI.perm.points.ToString() + "!";
        } else
        {
            Score.text = "You scored " + PermanentUI.perm.points.ToString() + "!";
        }
    }

    public void StoreName()
    {
        PermanentUI.perm.name = inputField.GetComponent<Text>().text;
    }
    
    public void toScoreboard()
    {
        SceneManager.LoadScene("Score Board");
    }

}
