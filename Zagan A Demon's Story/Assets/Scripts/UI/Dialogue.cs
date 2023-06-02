using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [HideInInspector]public float ShowTime = 0;
    [HideInInspector]public string dialogueText;
    [SerializeField]private GameObject dialogueGO;
    [SerializeField]private TMP_Text dialogueTextGO;

    public bool startTimer;


    private void Update()
    {
        if (startTimer)
        {
            Timer();

            if(ShowTime >= 0)
            {
                ShowDialogue();
            }
            else
            {
                dialogueGO.SetActive(false);
                startTimer = false;
            }
        }

    }

    public void SetDialogueScreen(float _showTime,string _dialogue)
    {
        ShowTime = _showTime;
        dialogueText = _dialogue;
        startTimer = true;
    }

    private void ShowDialogue()
    {
        dialogueGO.SetActive(true);
        dialogueTextGO.text = dialogueText;
    }

    private void Timer()
    {
        ShowTime -= Time.deltaTime;
    }
}
