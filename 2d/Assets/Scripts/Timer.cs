﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeNumber;
    [SerializeField] private TextMeshProUGUI timeup;
    private bool soundactive = false;

    private void Start()
    {
        PermanentUI.perm.time = 90;

    }
    private void Update()
    {
        if ((SceneManager.GetActiveScene().name != "Fourth Level") && (SceneManager.GetActiveScene().name != "first level")
            && (SceneManager.GetActiveScene().name != "Second Level final") && (SceneManager.GetActiveScene().name != "Third Level"))
        {

        }
        else
        {
            PermanentUI.perm.time -= 1 * Time.deltaTime;
            PermanentUI.perm.timescore = (int) Mathf.Round(PermanentUI.perm.time);
            timeNumber.text = ("Time: " + Mathf.Round(PermanentUI.perm.time).ToString() );
        }
        if (PermanentUI.perm.time <= 5.5 && soundactive == false && PermanentUI.perm.time >= 4)
        {
                PermanentUI.perm.timecrunch.Play();
            soundactive = true;
        } else if (PermanentUI.perm.time <= 0.2)
        {
            PermanentUI.perm.timecrunch.Stop();
            soundactive = false;
        }

        if (PermanentUI.perm.timescore <= 5)
       {
            if (PermanentUI.perm.timescore == 0)
            {
                timeup.text = "Time's up!";

            }
            else
            {

            timeup.enabled = true;
            timeup.text = PermanentUI.perm.timescore.ToString();
            }

        }

        else
        {
        timeup.enabled = false;
        }
        if (PermanentUI.perm.time <= 0)
        {
            PermanentUI.perm.checkpoint = 0;
            PermanentUI.perm.points = PermanentUI.perm.points - 20;
            PermanentUI.perm.lives = PermanentUI.perm.lives - 1;
            PermanentUI.perm.die.Play();
            SceneManager.LoadScene(PermanentUI.perm.LastScene);
            PermanentUI.perm.Reset();

        }

    }
}
