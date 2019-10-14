using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class User
{
    public string userName;
    public int playerScore;

    public User()
    {
        userName = SaveScore.playerName;
        playerScore = SaveScore.playerScore;
    }

    override
    public string ToString()
    {
        return userName + " " + playerScore;
    }
}
