using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//da acceso a interfaces de usuario
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Dificulty[] bancoDePreguntas;

    public Text enunciado;

    public Text[] respuesta;

    public int nivelPregunta;

    protected int questionRandom;

    // Start is called before the first frame update
    void Start()
    {
        nivelPregunta = 0;
        SeleccionarPregunta();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Este metodo recibe la respuesta seleccionada por el jugador
    /// </summary>
    /// <param name="playerAnswer"></param>
    public void Respuesta(int playerAnswer)
    {
        Debug.Log("Ha seleccionado la opcion" + playerAnswer.ToString());

        EvaluarPregunta(playerAnswer);
    }
    /// <summary>
    /// prueba
    /// </summary>
    public void SeleccionarPregunta()
    {
        //se elige un indice del arreglo al azar
        questionRandom = Random.Range(0, bancoDePreguntas[nivelPregunta].questions.Length);

        //sacamos el texto del banco de preguntas y lo ponemos en el UI donde se despliega el enunciado.
        enunciado.text = bancoDePreguntas[nivelPregunta].questions[questionRandom].enunciado;

        //cargar los textos de cada boton del UI
        for(int i = 0; i < respuesta.Length; i++)
        {
            respuesta[i].text = bancoDePreguntas[nivelPregunta].questions[questionRandom].answers[i].text;
        }
    }

    public bool EvaluarPregunta(int playerAnswer)
    {
        if(playerAnswer == bancoDePreguntas[nivelPregunta].questions[questionRandom].correctAnswer)
        {
            //reinicio del problema con mayor dificultad
            nivelPregunta++;
            //refresca interfaz con nuevo nivel
            

            if(nivelPregunta == bancoDePreguntas.Length)
            {
                //desplegar la pantalla de fin de juego ganado
                SceneManager.LoadScene("Win");
            }
            else
            {
                //subir de nivel
                SeleccionarPregunta();
            }
            return true;
        }
        else
        {
            SceneManager.LoadScene("Lose");
            return false;
        }
        
    }
}
