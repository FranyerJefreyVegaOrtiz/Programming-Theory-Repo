using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dinero : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpDineroTotal;

    public int dineroTotal;

    private void Start()
    {
        dineroTotal = MainManager.Instance.dineroDificultad;
        tmpDineroTotal.text = "$ " + dineroTotal.ToString();
    }
    private void FixedUpdate()
    {
        tmpDineroTotal.text = "$ " + dineroTotal.ToString();
    }
}
