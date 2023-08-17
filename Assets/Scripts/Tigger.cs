using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Tigger : MonoBehaviour
{
    public GameObject objetoContraElQueChoco;
    public GameObject elCharacter;

    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaques;

    public bool isMovingT;
    public float vida;
    public float da�oGolpe;

    private Character characterScript;
    bool atacaElEnemigo;
    bool atacaElJugador;

    private void Start()
    {
        characterScript = FindObjectOfType<Character>();
        vida = characterScript.vida;
        da�oGolpe = characterScript.da�oGolpe;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject objetoColisionado = other.gameObject;

        if (gameObject.CompareTag("Enemigo") && objetoColisionado.CompareTag("Player"))
        {
            characterScript.isMoving = false;
            atacaElJugador = true;
        }

        else if (gameObject.CompareTag("Player") && objetoColisionado.CompareTag("Enemigo"))
        {
            characterScript.isMoving = false;
            atacaElEnemigo = true;
        }
        if (gameObject.CompareTag("Enemigo") && isMovingT == true)
        {
            characterScript.isMoving = true;
        }
        objetoContraElQueChoco = objetoColisionado;
    }

    private void FixedUpdate()
    {
        if (atacaElJugador)
        {
            if (tiempoSiguienteAtaques > 0)
            {
                tiempoSiguienteAtaques -= Time.deltaTime;
                vida = characterScript.vida;
                da�oGolpe = characterScript.da�oGolpe;
            }
            else if (tiempoSiguienteAtaques <= 0)
            {
                // Si no es el jugador, asumimos que es el enemigo, entonces aplicamos da�o al enemigo
                characterScript.TomarDa�o(objetoContraElQueChoco.GetComponent<Tigger>().da�oGolpe);
                tiempoSiguienteAtaques = tiempoEntreAtaques;
            }
        }
    }
}
