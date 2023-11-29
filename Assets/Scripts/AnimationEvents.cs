using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    GameObject carParticles, car;
    [SerializeField] GameObject taskManager;


    [SerializeField] GameObject windowsFather, wheelsFather, trashFather, trashSon, windowsSon, wheelsSon;



    public void FindNewCarParticles()
    {
        if (GameObject.Find("--CarManager--1(Clone)") != null) carParticles = GameObject.Find("--CarManager--1(Clone)").transform.Find("Coche (2)").transform.Find("EfectosParticulas").gameObject;
        if (GameObject.Find("--CarManager--1(Clone)") != null) car = GameObject.Find("--CarManager--1(Clone)").gameObject;

    }
    public void SonWorkingToTrue()
    {


        WhereToLookSon();
        GameManager.Instance.isSonWorking = true;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    public void SonWorkingToFalse()
    {
        GameManager.Instance.isSonWorking = false;
    }
    public void FatherWorkingToTrue()
    {
        WhereToLookFather();
        GameManager.Instance.isFatherWorking = true;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    public void FatherWorkingToFalse()
    {
        GameManager.Instance.isFatherWorking = false;
    }


    public void SandedParticleSystem()
    {

        //Poner effectos visuales q cambiarian en el coche
        carParticles.transform.Find("Sanded").GetComponent<ParticleSystem>().Play();
        car.GetComponent<CarPainLogic>().SetToSanded();
        taskManager.GetComponent<TaskManager>().sandPaintState = 2;
    }
    public void PaintedParticleSystem()
    {
        //Este metodo se llamara cunado termines la animacion de lijar
        //Poner effectos visuales q cambiarian en el coche
        carParticles.transform.Find("Painted").GetComponent<ParticleSystem>().Play();
        car.GetComponent<CarPainLogic>().SetToPainted();
        taskManager.GetComponent<TaskManager>().SandPaintDone = true;
    }


    public void PlaceWheelSon()
    {
        taskManager.GetComponent<TaskManager>().PlaceSonWheel();
        carParticles.transform.Find("Placed").GetComponent<ParticleSystem>().Play();
    }
    public void PlaceWheelFather()
    {
        taskManager.GetComponent<TaskManager>().PlaceFatherWheel();
        carParticles.transform.Find("Placed").GetComponent<ParticleSystem>().Play();
    }

    public void PlaceWindowSon()
    {
        taskManager.GetComponent<TaskManager>().PlaceSonWindow();
        carParticles.transform.Find("Placed").GetComponent<ParticleSystem>().Play();
    }
    public void PlaceWindowFather()
    {
        taskManager.GetComponent<TaskManager>().PlaceFatherWindow();
        carParticles.transform.Find("Placed").GetComponent<ParticleSystem>().Play();
    }



    private void WhereToLookSon()
    {
        if (GameManager.Instance.canSonInteractWithCar)
        {
            Vector3 direccion = carParticles.transform.position - transform.position;
            direccion.y = 0;
            transform.rotation = Quaternion.LookRotation(direccion);
        }
        if (GameManager.Instance.canSonInteractWithTrash)
        {
            Vector3 direccion = trashSon.transform.position - transform.position;
            direccion.y = 0;
            transform.rotation = Quaternion.LookRotation(direccion);
        }
        if(GameManager.Instance.canSonInteractWithWeels)
        {
            Vector3 direccion = wheelsSon.transform.position - transform.position;
            direccion.y = 0;
            transform.rotation = Quaternion.LookRotation(direccion);
        }
        if(GameManager.Instance.canSonInteractWithWindows)
        {
            Vector3 direccion = windowsSon.transform.position - transform.position;
            direccion.y = 0;
            transform.rotation = Quaternion.LookRotation(direccion);
        }
    }
    private void WhereToLookFather()
    {
        if (GameManager.Instance.canFatherInteractWithCar)
        {
            Vector3 direccion = carParticles.transform.position - transform.position;
            direccion.y = 0;
            transform.rotation = Quaternion.LookRotation(direccion);
        }
        if (GameManager.Instance.canFatherInteractWithTrash)
        {
            Vector3 direccion = trashFather.transform.position - transform.position;
            direccion.y = 0;
            transform.rotation = Quaternion.LookRotation(direccion);
        }
        if (GameManager.Instance.canFatherInteractWithWeels)
        {
            Vector3 direccion = wheelsFather.transform.position - transform.position;
            direccion.y = 0;
            transform.rotation = Quaternion.LookRotation(direccion);
        }
        if (GameManager.Instance.canFatherInteractWithWindows)
        {
            Vector3 direccion = windowsFather.transform.position - transform.position;
            direccion.y = 0;
            transform.rotation = Quaternion.LookRotation(direccion);
        }
    }
}
