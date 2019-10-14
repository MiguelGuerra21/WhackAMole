using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{

    public ScoreManager scoreManager;
    public TimeManager timeManager;
    public AudioSource soundFx;

    public Sprite imagenTopoGolpeado;
    public Sprite imagenTopoSinGolpear;

    public AudioClip[] audios = new AudioClip[2];

    //Si añadimos un Tooltip y pasamos el ratón por encima en el editor, nos mostrara este mensaje.
    [Tooltip("Conectar todos los botones a esto")]
    public GameObject[] botones;//Creamos un Array de botones.


    //Comenzamos con 0,5 segundos, luego será aleatorio.
    float randomTime = .5f;

    //Poniendolo publico podemos controlarlo mas facilmente desde ejecucion cambiando los valores para ver que es mas natural.
    public float hideTime = 1.0f;

    // Use this for initialization
    void Start()
    {

        //Al comienzo de la partida ponemos todos los botones a inactivo.
        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].SetActive(false);
        }

        //Tambien comenzamos una coroutine, un evento tardío que comienza a iterar los topos aleatoriamente.
        StartCoroutine(ShowButton());
    }

    //Esto se lo añadiremos a los botones
    public void PressedBtn()
    {
        //Permite al jugador puntuar si el juego esta activo.
        if (timeManager.gameOver == false)
        {
            //Referenciamos el boton pulsado.
            GameObject myButton = EventSystem.current.currentSelectedGameObject;

            //Cambia la imagen para saber que le hemos dado.
            //Ejecuta un sonido de Topo Aleatorio.
            myButton.GetComponentInChildren<Image>().sprite = imagenTopoGolpeado;
            soundFx.PlayOneShot(audios[Random.Range(0,2)]);

            //Suma puntuacion.
            scoreManager.Puntuar(10, true);

            //Comenzamos otra coroutine para esconder el boton hasta la proxima activacion.
            StartCoroutine(HitButton(myButton));
        }

    }

    //Esto se repite hasta el fin del juego.
    IEnumerator ShowButton()
    {

        yield return new WaitForSeconds(randomTime);

        //Permite que la coroutine funcione siempre y cuando el juego este activo.
        if (timeManager.gameOver == false)
        {
            //Escoge un boton aleatorio.
            int randomButton = Random.Range(0, botones.Length);

            //Comprobamos que el boton al que estamos accediendo este inactivo.
            if (botones[randomButton].activeInHierarchy == false)
            {
                botones[randomButton].SetActive(true);//Lo activamos

            }

            //Creamos un nuevo tiempo aleatorio
            randomTime = Random.Range(0, 1f);

            //Llamamos a la coroutine en ella misma para que se repita constantemente.  
            StartCoroutine(ShowButton());

            //Desactiva el botón al cabo de un rato para que ya no sea pulsable.
            StartCoroutine(HideButton(botones[randomButton]));
        }

    }

    /// <summary>
    /// Desactiva el boton al cabo de un rato
    /// LLamado desde la coroutine "ShowButton".
    /// </summary>
    /// <returns>The button.</returns>
    /// <param name="myBtn">My button.</param>
    /// 
    IEnumerator HideButton(GameObject myBtn)
    {
        yield return new WaitForSeconds(hideTime);

        //Comprobamos que siga activo para no esconder un boton que ha sido pulsado.
        if (myBtn.activeInHierarchy)
        {
            //Lo ponemos inactivo para poder llamarlo de nuevo
            myBtn.gameObject.SetActive(false);

            //Reducimos la puntuacion del jugador al no darle.
            scoreManager.Puntuar(5, false);

        }



    }

    /// <summary>
    /// LLamado cuando pulsamos un boton, para devolverle al estado inactivo
    /// Pasamos el boton en el metodo anterior para tenerlo en este como parametro.
    /// </summary>
    /// <returns>The button.</returns>
    /// <param name="myBtn">My button.</param>
	IEnumerator HitButton(GameObject myBtn)
    {
        yield return new WaitForSeconds(.25f);
        //cambia el color de nuevo a verde y resetea el texto
        myBtn.GetComponentInChildren<Image>().sprite = imagenTopoSinGolpear;

        //Lo ponemos inactivo para que pueda ser llamado de nuevo.
        myBtn.gameObject.SetActive(false);


    }
}
