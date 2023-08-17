using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CombateCaC : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;

    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaques;

    private Character character;
    public bool atacaAUnEnemigo;
    public bool atacaAUnPlayer;
    public GameObject objetoContraElQueChoco;

    public float vida;
    public float da�oGolpe;

    private void Start()
    {
        character = FindObjectOfType<Character>();

        vida = character.vida;
        da�oGolpe = character.da�oGolpe;
    }
    private void FixedUpdate()
    {

        if (atacaAUnEnemigo)
        {
            if (tiempoSiguienteAtaques > 0)
            {
                tiempoSiguienteAtaques -= Time.deltaTime;
            }
            else if (atacaAUnPlayer && tiempoSiguienteAtaques <= 0)
            {
                // Aplicar da�o al jugador
                character.TomarDa�o(objetoContraElQueChoco.GetComponent<Character>().da�oGolpe);
                tiempoSiguienteAtaques = tiempoEntreAtaques;
            }
            else if (tiempoSiguienteAtaques <= 0)
            {
                // Aplicar da�o al enemigo
                character.TomarDa�o(objetoContraElQueChoco.GetComponent<Character>().da�oGolpe);

                // Verificar si el enemigo ha muerto (vida <= 0)
                if (objetoContraElQueChoco.GetComponent<Character>().vida <= 0)
                {
                    // Establecer isMoving a true nuevamente en el personaje (jugador)
                    character.isMoving = true;
                }

                tiempoSiguienteAtaques = tiempoEntreAtaques;
            }
        }else if (atacaAUnPlayer)
        {
            if (tiempoSiguienteAtaques > 0)
            {
                tiempoSiguienteAtaques -= Time.deltaTime;
            }
            else if (tiempoSiguienteAtaques <= 0)
            {
                // Aplicar da�o al jugador
                character.TomarDa�o(objetoContraElQueChoco.GetComponent<Character>().da�oGolpe);
                tiempoSiguienteAtaques = tiempoEntreAtaques;
            }
            else if (tiempoSiguienteAtaques <= 0)
            {
                // Aplicar da�o al enemigo
                character.TomarDa�o(objetoContraElQueChoco.GetComponent<Character>().da�oGolpe);

                // Verificar si el enemigo ha muerto (vida <= 0)
                if (objetoContraElQueChoco.GetComponent<Character>().vida <= 0)
                {
                    // Establecer isMoving a true nuevamente en el personaje (jugador)
                    character.isMoving = true;
                }

                tiempoSiguienteAtaques = tiempoEntreAtaques;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Obtener el objeto colisionado
        GameObject objetoColisionado = collision.gameObject;

        objetoContraElQueChoco = objetoColisionado;

        // Verificar si es el jugador el que colision�
        if (objetoColisionado.CompareTag("Enemigo"))
        {
            character.isMoving = false;
            atacaAUnEnemigo = true;
        }
        else if (objetoColisionado.CompareTag("Player"))
        {
            character.isMoving = false;
            atacaAUnPlayer = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
