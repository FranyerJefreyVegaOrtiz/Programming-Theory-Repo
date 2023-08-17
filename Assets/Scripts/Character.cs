using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private PowerUp powerUp;

    public float vida;
    public float dañoGolpe;

    public float tiempoRecarga;
    public float speed;
    public bool isMoving = true;

    private Rigidbody Rigidbodyrb;
    private Vector3 constantVelocity;

    public int costoCreacion;
    public int gananciaAlMorir;

    private Dinero dineroScript;
    private Spawn spawnScript;
    private CombateCaC combateCaCScript;
    private void Awake()
    {
        combateCaCScript = FindObjectOfType<CombateCaC>();
        dineroScript = FindObjectOfType<Dinero>();
        spawnScript = FindObjectOfType<Spawn>();
        Rigidbodyrb = GetComponent<Rigidbody>();

        spawnScript.tiempoRecarga = tiempoRecarga;
        dineroScript.dineroTotal -= costoCreacion;
    }
    void Start()
    {
        if (GameManager.Instance.esJugador)
        {
            // Cambiar el tag del objeto al nuevoTag especificado
            gameObject.tag = "Player";

            // Establecer la velocidad constante en el eje X
            constantVelocity = Vector3.right * speed;
        }
        else
        {
            // Cambiar el tag del objeto al nuevoTag especificado
            gameObject.tag = "Enemigo";
            // Establecer la velocidad constante en el eje X
            constantVelocity = Vector3.right * -speed;
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            // Mover el objeto utilizando Rigidbody.MovePosition para un movimiento más suave
            Rigidbodyrb.MovePosition(transform.position + constantVelocity * Time.fixedDeltaTime);
        }
    }
    public void TomarDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            vida = 0;
            //activar animacion de muerte
            Debug.Log("Muerto x_x");
            powerUp = FindObjectOfType<PowerUp>();
            powerUp.EnemyDefeated();
            Destroy(gameObject);
            return;
        }
    }
}
