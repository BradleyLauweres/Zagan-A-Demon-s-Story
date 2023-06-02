using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    Dialogue dialogueManager;

    void Start()
    {
        dialogueManager = Player.GetComponent<Dialogue>();
        dialogueManager.SetDialogueScreen(4f,"Hey jordy");
    }
}
