using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimeManager : MonoBehaviour {

    //Texto del tiempo
    public Text timeLabel;

    //Texto GameOver
    public Text gameOverLabel;

    //Tiempo que dura la partida en segundos
    float maxTime = 30;

    // Booleano utilizado para decidir si el juego continua , con HideInInspector conseguimos que una variable publica no se muestre en el editor
    [HideInInspector] public bool gameOver = false;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        //Comienza la cuenta atras.
        maxTime -= Time.deltaTime;// con -= contamos hacia atrás.

        //Necesitamos convertirlo a segundos para que se muestre correctamente
        int segundos = Mathf.RoundToInt(maxTime % 60f);

        //Si no hemos llegado a 0 
        if (segundos >= 0)
        {
            //Actualizar la etiqueta Tiempo : con los segundos restantes
            timeLabel.text = "Tiempo: " + segundos.ToString("00");

        }
        else
        {
            //Solo se llama una vez en el Update.
            if (gameOver == false)
            {
                
                gameOver = true;
                //Activamos la Label de gameOver
                gameOverLabel.gameObject.SetActive(true);

                //Tras un corto periodo, cambia la escena.
                StartCoroutine(ChangeScene());
            }

        }

    }

    IEnumerator ChangeScene()
    {
        //Ajustamos el delay a 2 segundos, posteriormente se mostrará la puntuación
        yield return new WaitForSeconds(2);
        //Cambiamos la escena utilizando el SceneManager y uno de nuestros enum que pasaremos a String primero. 
        SceneManager.LoadSceneAsync(GameScenes.ScoreScene.ToString());

    }
}
