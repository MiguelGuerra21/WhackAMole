using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Los tipos de puntuación que guardaremos, o datos que necesitemos para calcular la puntuacion.
/// </summary>
public enum ScoreTypes
{
    PlayerScore,
    Golpes,
    Fallos

}

public class ScoreManager : MonoBehaviour {
    
    public Text scoreLabel;

    //Creamos la variable aqui para poder usarla en cualquier lugar del script.
    int score = 0;

	// Use this for initialization
	void Start()
	{
		//resetea toda la informacion de la partida para no fallar al calcular la puntuacion. 
		PlayerPrefs.SetInt(ScoreTypes.Golpes.ToString(), 0);
		PlayerPrefs.SetInt(ScoreTypes.Fallos.ToString(), 0);
		PlayerPrefs.SetInt(ScoreTypes.PlayerScore.ToString(), 0);


	}
    
    public void Puntuar(int cantidad, bool acertado){

        if(acertado == true)
        {
			//Si acertado es true significa que ha acertado y debemos sumar

			//puntuacion actual 
			score = PlayerPrefs.GetInt(ScoreTypes.PlayerScore.ToString());
			//le sumamos la amount
			score += cantidad;
			//La guardamos
			PlayerPrefs.SetInt(ScoreTypes.PlayerScore.ToString(), score);

			//Aumentamos los golpes acertados tambien.
            int golpes = PlayerPrefs.GetInt(ScoreTypes.Golpes.ToString());
			golpes += 1;
			PlayerPrefs.SetInt(ScoreTypes.Golpes.ToString(), golpes);

		}
        else
        {
			//Aumentamos los golpes fallidos para mostrarlos al final de partida.
            int fallos = PlayerPrefs.GetInt(ScoreTypes.Fallos.ToString());
			fallos += 1;
			PlayerPrefs.SetInt(ScoreTypes.Fallos.ToString(), fallos);
        }

        //Actualizamos la Puntuacion.
        scoreLabel.text = "Puntuacion:" + score;

    }

}
