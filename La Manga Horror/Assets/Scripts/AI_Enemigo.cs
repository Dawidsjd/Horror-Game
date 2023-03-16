using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Enemigo : MonoBehaviour
{
     public Transform Objetivo;
    public float Velocidad;
    public NavMeshAgent IA;

    public Animator animator;
    public RuntimeAnimatorController controller1;
    public RuntimeAnimatorController controller2;

    private bool isStopping = false;

    void Start()
    {
        // Przypisanie pocz¹tkowego kontrolera animacji
        animator.runtimeAnimatorController = controller1;
    }

    void Update()
    {
        IA.speed = Velocidad;
        IA.SetDestination(Objetivo.position);

        // Warunek zmiany kontrolera animacji
        if (Vector3.Distance(transform.position, Objetivo.position) < 2.0f)
        {
            SetController(controller2);

            // Dodajemy warunek, który zatrzyma przeciwnika na 1 sekundê, gdy jest blisko gracza
            if (!isStopping)
            {
                isStopping = true;
                IA.isStopped = true;
                Invoke("ResumeMovement", 1f);
            }
        }
        else
        {
            SetController(controller1);
        }
    }

    void SetController(RuntimeAnimatorController controller)
    {
        // Ustawienie nowego kontrolera animacji
        animator.runtimeAnimatorController = controller;
    }

    void ResumeMovement()
    {
        // Wznawiamy ruch po zatrzymaniu na 1 sekundê
        isStopping = false;
        IA.isStopped = false;
    }
}
