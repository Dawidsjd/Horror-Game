using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    // ustawienie maksymalnej odleg³oœci, z jakiej mo¿na podnosiæ obiekty
    public float pickupDistance = 2f;

    // ustawienie przycisku, który bêdzie podnosi³ obiekty
    public KeyCode pickupButton = KeyCode.E;

    // ustawienie przycisku, który bêdzie upuszcza³ obiekty
    public KeyCode dropButton = KeyCode.G;

    // zmienna przechowuj¹ca aktualnie podniesiony obiekt
    private GameObject heldObject;

    void Update()
    {
        // jeœli gracz naciœnie przycisk "E"
        if (Input.GetKeyDown(pickupButton))
        {
            // sprawdzamy, czy w pobli¿u gracza znajduje siê obiekt z Tagiem "PickUpObject"
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickupDistance);
            foreach (Collider hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("PickUpObject"))
                {
                    // jeœli tak, to podnosimy go
                    heldObject = hitCollider.gameObject;
                    heldObject.transform.SetParent(transform);
                    heldObject.transform.localPosition = new Vector3(-0.451f, -0.23f, 0.758f);
                    heldObject.transform.localRotation = Quaternion.Euler(-90f, 0f, -37.086f);
                    heldObject.GetComponent<Rigidbody>().isKinematic = true;

                    // sprawdzamy, czy podniesiony obiekt posiada komponent Audio Source
                    AudioSource audioSource = heldObject.GetComponent<AudioSource>();
                    if (audioSource != null)
                    {
                        // wy³¹czamy dŸwiêk w Audio Source
                        audioSource.mute = false;
                    }

                    break;
                }
            }
        }

        // jeœli gracz naciœnie przycisk "G"
        if (Input.GetKeyDown(dropButton))
        {
            // upuszczamy podniesiony obiekt
            if (heldObject != null)
            {
                // sprawdzamy, czy upuszczany obiekt posiada komponent Audio Source
                AudioSource audioSource = heldObject.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    // przywracamy oryginalny stan dŸwiêku w Audio Source
                    audioSource.mute = true;
                }

                heldObject.transform.SetParent(null);
                heldObject.GetComponent<Rigidbody>().isKinematic = false;
                // zresetuj zmienn¹ przechowuj¹c¹ obiekt
                heldObject = null;
            }
        }
    }
}
