using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    // ustawienie maksymalnej odleg�o�ci, z jakiej mo�na podnosi� obiekty
    public float pickupDistance = 2f;

    // ustawienie przycisku, kt�ry b�dzie podnosi� obiekty
    public KeyCode pickupButton = KeyCode.E;

    // ustawienie przycisku, kt�ry b�dzie upuszcza� obiekty
    public KeyCode dropButton = KeyCode.G;

    // zmienna przechowuj�ca aktualnie podniesiony obiekt
    private GameObject heldObject;

    void Update()
    {
        // je�li gracz naci�nie przycisk "E"
        if (Input.GetKeyDown(pickupButton))
        {
            // sprawdzamy, czy w pobli�u gracza znajduje si� obiekt z Tagiem "PickUpObject"
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickupDistance);
            foreach (Collider hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("PickUpObject"))
                {
                    // je�li tak, to podnosimy go
                    heldObject = hitCollider.gameObject;
                    heldObject.transform.SetParent(transform);
                    heldObject.transform.localPosition = new Vector3(-0.451f, -0.23f, 0.758f);
                    heldObject.transform.localRotation = Quaternion.Euler(-90f, 0f, -37.086f);
                    heldObject.GetComponent<Rigidbody>().isKinematic = true;

                    // sprawdzamy, czy podniesiony obiekt posiada komponent Audio Source
                    AudioSource audioSource = heldObject.GetComponent<AudioSource>();
                    if (audioSource != null)
                    {
                        // wy��czamy d�wi�k w Audio Source
                        audioSource.mute = false;
                    }

                    break;
                }
            }
        }

        // je�li gracz naci�nie przycisk "G"
        if (Input.GetKeyDown(dropButton))
        {
            // upuszczamy podniesiony obiekt
            if (heldObject != null)
            {
                // sprawdzamy, czy upuszczany obiekt posiada komponent Audio Source
                AudioSource audioSource = heldObject.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    // przywracamy oryginalny stan d�wi�ku w Audio Source
                    audioSource.mute = true;
                }

                heldObject.transform.SetParent(null);
                heldObject.GetComponent<Rigidbody>().isKinematic = false;
                // zresetuj zmienn� przechowuj�c� obiekt
                heldObject = null;
            }
        }
    }
}
