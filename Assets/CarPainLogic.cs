using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPainLogic : MonoBehaviour
{

    [SerializeField] Material carro1N, VentanasN, carro1A, VentanasA, carro1Am, VentanasAm;
    [SerializeField] Material Naranja, Azul, Amarillo;
    [SerializeField] Material sanded;
    [SerializeField] MeshRenderer carroceria, ventana1, ventana2, capo;

    int random;

    private void Start()
    {
        random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                carroceria.material = carro1N;
                ventana1.material = VentanasN;
                ventana2.material = VentanasN;
                capo.material = VentanasN;

                break;

            case 1:
                carroceria.material = carro1A;
                ventana1.material = VentanasA;
                ventana2.material = VentanasA;
                capo.material = VentanasA;
                break;
            case 2:
                carroceria.material = carro1Am;
                ventana1.material = VentanasAm;
                ventana2.material = VentanasAm;
                capo.material = VentanasAm;
                break;
        }
    }


    public void SetToSanded()
    {
        carroceria.material = sanded;
        ventana1.material = sanded;
        ventana2.material = sanded;
        capo.material = sanded;
    }
    public void SetToPainted()
    {
        switch (random)
        {
            case 0:
                carroceria.material = Naranja;
                ventana1.material = Naranja;
                ventana2.material = Naranja;
                capo.material = Naranja;

                break;

            case 1:
                carroceria.material = Azul;
                ventana1.material = Azul;
                ventana2.material = Azul;
                capo.material = Azul;
                break;
            case 2:
                carroceria.material = Amarillo;
                ventana1.material = Amarillo;
                ventana2.material = Amarillo;
                capo.material = Amarillo;
                break;
        }
    }
}
