using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Proyecto26;
using System;

public class SummaryManager : MonoBehaviour {

    public Text golpesText;
    public Text fallosText;
    public Text scoreText;

    public User datosBBDD;



	// Use this for initialization
	void Start () {
        //Colocamos el texto junto a los datos del jugador
        golpesText.text = "Golpes : " + PlayerPrefs.GetInt(ScoreTypes.Golpes.ToString());
        fallosText.text = "Fallos : " + PlayerPrefs.GetInt(ScoreTypes.Fallos.ToString());
        scoreText.text = "Puntuación : " + PlayerPrefs.GetInt(ScoreTypes.PlayerScore.ToString());


        datosBBDD = RetrieveData();


        int puntuacion = PlayerPrefs.GetInt(ScoreTypes.PlayerScore.ToString());

        if (puntuacion > datosBBDD.playerScore)
        {
            Invoke("Guardar",3);     //Los segundos que debe esperar antes de ir a la pantalla de guardado
        }
        else
        {
            Debug.Log("Seleccione volver al menu principal o reiniciar la partida");
        }

	}
	

    public void Reiniciar(){

        //Que vuelva a la escena del juego si se pulsa reiniciar.
        SceneManager.LoadSceneAsync(GameScenes.GameScene.ToString());

    }

    public void Guardar()
    {
        //Que nos lleve a una escena nueva en la que introducir nuestros datos de usuario.
        SceneManager.LoadSceneAsync(GameScenes.SaveScene.ToString());

    }

    public void Exit()
    {

        //Que se vuelva al menu principal si se pulsa exit.
        SceneManager.LoadSceneAsync(GameScenes.MainMenu.ToString());

    }

    public User RetrieveData()
    {
        User userData = new User();
        try
        {
            RestClient.Get<User>("https://whackamoledb.firebaseio.com/.json").Then(response => {

                userData.playerScore = response.playerScore;
                userData.userName = response.userName;

            });
        }
        catch
        {
            userData.userName = "No se ha guardado un nombre aún";
            userData.playerScore = -1;
        }

        return userData;
    }

}
