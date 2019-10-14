using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class PlaceData : MonoBehaviour
{

    public Text campoPlayerName;
    public Text campoPlayerScore;
    


    // Start is called before the first frame update
    void Start()
    {
        PlaceScores();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync(GameScenes.MainMenu.ToString());
    }

    public void PlaceScores()
    {

        User datosUsuario = RetrieveData();

        if (datosUsuario != null)
        {
            campoPlayerName.text = datosUsuario.userName;
            campoPlayerScore.text = datosUsuario.playerScore.ToString();
        }
        else
        {
            campoPlayerName.text = "Empty";
            campoPlayerScore.text = "Empty";
            Debug.Log("No se han recibido datos de la BBDD");
        }
    }

    //Recoge la informacion de la BBDD (datosUsuario se recibe null)
    public User RetrieveData()
    {
        User userData = new User();
        RestClient.Get<User>("https://whackamoledb.firebaseio.com/.json").Then(response => {

            userData.playerScore = response.playerScore;
            userData.userName = response.userName;

        });

        return userData;
    }
}
