using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Desbloquear : MonoBehaviour
{
    private Spawn spawnScript;
    private List<int> unidadActiva = new List<int>();
    public Image[] countdownObjects;
    private int costoDesbloquear = 150;
    private Dinero dineroScript;

    private void Start()
    {
        dineroScript = FindObjectOfType<Dinero>();
        // Inicializar la lista con los números disponibles
        for (int i = 0; i <= 5; i++)
        {
            unidadActiva.Add(i);
        }
    }

    public void GenerarNumeroAleatorioUnico()
    {
        if (dineroScript.dineroTotal >= costoDesbloquear)
        {
            spawnScript = FindObjectOfType<Spawn>();

            if (unidadActiva.Count == 0)
            {
                Debug.Log("Ya se han generado todos los números.");
                return;
            }

            int indiceAleatorio = Random.Range(0, unidadActiva.Count);
            countdownObjects[unidadActiva[indiceAleatorio]].gameObject.SetActive(false);

            // Mostrar el número generado y quitarlo de la lista de disponibles
            unidadActiva.RemoveAt(indiceAleatorio);

            // Restar el costo del boton
            dineroScript.dineroTotal -= costoDesbloquear;
        }
    }
}
