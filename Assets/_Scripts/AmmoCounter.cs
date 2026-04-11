using System;
using UnityEngine;
using TMPro;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI leftAmmoTxt;
    [SerializeField] private TextMeshProUGUI rigthAmmoTxt;

    private PlayerMovement playerMovement;

    private void Start()
    {
        if (!playerMovement)
        {
            playerMovement = FindAnyObjectByType<PlayerMovement>();
        }
    }

    private void Update()
    {
        leftAmmoTxt.text = playerMovement.balasIzquierda.ToString();
        rigthAmmoTxt.text = playerMovement.balasDerecha.ToString();
    }
}