using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.Hardware;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] slots;
    public GameObject[] comprarButtons;
    public GameObject[] venderButtons;
    private Dictionary<int, int> slotStates; // slotId, estado (0: desactivado, 1: activo)

    public int slotActivo;
    public bool esJugador;
    public int valorCrear;
    public int valorVenta;

    private Dinero dineroScript;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        slotStates = new Dictionary<int, int>();
        for (int i = 0; i < slots.Length; i++)
        {
            slotStates[i] = 0; // Inicialmente todos los slots están desactivados
        }

        slotActivo = -1; // Ningún slot activo al principio
    }
    public void EsJugador()
    {
        esJugador = true;
    }

    public void ComprarSlotArma(int slotId)
    {
        dineroScript = FindObjectOfType<Dinero>();
        if (dineroScript.dineroTotal >= valorCrear && slotStates[slotId] == 0 && slotId < 3)
        {
            dineroScript.dineroTotal -= valorCrear;
            slots[slotId].SetActive(true);
            comprarButtons[slotId].SetActive(false);
            venderButtons[slotId].SetActive(true);
            if (slotId > 0)
            {
                venderButtons[slotId-1].SetActive(false);
            }
            if (slotId < 2)
            {
                comprarButtons[slotId + 1].SetActive(true);
            }
            slotActivo = slotId;
            slotStates[slotId] = 2;

            // Desactivar el slot anterior (si lo hay)
            //if (slotId > 0 && slotStates[slotId - 1] == 1)
            //{
            //    slots[slotId - 1].SetActive(false);
            //    venderButtons[slotId - 1].SetActive(false);
            //    comprarButtons[slotId - 1].SetActive(true);
            //    slotStates[slotId - 1] = 0;
            //}
        }
    }

    public void VenderSlotArma(int slotId)
    {
        if (slotStates[slotId] == 2)
        {
            dineroScript.dineroTotal += valorVenta;
            slots[slotId].SetActive(false);
            venderButtons[slotId].SetActive(false);
            comprarButtons[slotId].SetActive(true);
            if (slotId > 0)
            {
                venderButtons[slotId - 1].SetActive(true);
            }
            if (slotId < 2)
            {
                comprarButtons[slotId + 1].SetActive(false);
            }

            slotStates[slotId] = 0;
            slotActivo = -1;
        }
    }
}





