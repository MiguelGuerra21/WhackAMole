using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveScore : MonoBehaviour
{

    public Text scoreText;
    public InputField nameText;

    public static int playerScore;
    public static string playerName;


    // Start is called before the first frame update
    void Start()
    {
        playerScore = PlayerPrefs.GetInt(ScoreTypes.PlayerScore.ToString());
        scoreText.text = "Tu puntuación : " + playerScore;
    }

    //Se lo añadimos al boton de guardar para que recoja el nombre del input y llame a la BBDD
    private void SaveButton()
    {
        playerName = nameText.text;
        SubirABaseDatos();

    }

    public void BackButton()
    {
        SceneManager.LoadSceneAsync(GameScenes.MainMenu.ToString());
    }

    //Crea un usuario con los datos del jugador y lo sube a la BBDD, devuelve al main menu
    private void SubirABaseDatos()
    {
        User user = new User();
        RestClient.Put("https://whackamoledb.firebaseio.com/.json", user);
        SceneManager.LoadSceneAsync(GameScenes.MainMenu.ToString());
    }

    //public void CogerDeBaseDatos()
    //{
        //RestClient.Get<User>("https://whackamoledb.firebaseio.com/" + playerName + ".json").Then(response =>
        //{

            //return response;

        //});

    //}
}
