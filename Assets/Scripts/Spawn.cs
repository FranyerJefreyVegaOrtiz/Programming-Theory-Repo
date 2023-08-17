using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.Hardware;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Image[] countdownObjects;

    private Vector3 spawnPosition;
    public float tiempoRecarga;

    private Dinero dineroScript;
    private Character characterScript;

    private int valorPredeterminado;

    private void Start()
    {
        dineroScript = FindObjectOfType<Dinero>();
        characterScript = FindObjectOfType<Character>();
        spawnPosition = new Vector3(-13, 1, 0);
    }

    public void ClickSpawn(int index)
    {
        if (index >= 0 && index < characterPrefabs.Length)
        {
            if (dineroScript.dineroTotal >= characterScript.costoCreacion || dineroScript.dineroTotal == valorPredeterminado)
            {
                Instantiate(characterPrefabs[index], spawnPosition, characterPrefabs[index].transform.rotation);
                countdownObjects[index].gameObject.SetActive(true);
                StartCoroutine(StartTimer(tiempoRecarga, index));
            }
        }
    }

    private IEnumerator StartTimer(float tiempo, int index)
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < tiempo)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        countdownObjects[index].gameObject.SetActive(false);
    }
    public void ClickSpawnMushRoom()
    {
        valorPredeterminado = 15;
        ClickSpawn(0);
    }
    public void ClickSpawnSlime()
    {
        valorPredeterminado = 20;
        ClickSpawn(1);
    }
    public void ClickSpawnTurtle()
    {
        valorPredeterminado = 50;
        ClickSpawn(2);
    }
    public void ClickSpawnBeholder()
    {
        valorPredeterminado = 75;
        ClickSpawn(3);
    }
    public void ClickSpawnChest()
    {
        valorPredeterminado = 100;
        ClickSpawn(4);
    }
    public void ClickSpawnCactus()
    {
        valorPredeterminado = 150;
        ClickSpawn(5);
    }
    public void ClickSpawnPartyYellow()
    {
        valorPredeterminado = 300;
        ClickSpawn(6);
    }
    public void ClickSpawnPartyBlue()
    {
        valorPredeterminado = 300;
        ClickSpawn(7);
    }
}
