using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnimator;
    public GameObject intText;
    public float distance = 0.6f; // odleg�o��, w kt�rej gracz mo�e otworzy� drzwi
    private bool isDoorOpen = false;

    private void Update()
    {
        // Sprawd�, czy gracz nacisn�� klawisz "E" i jest w odpowiedniej odleg�o�ci
        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < distance)
        {
            // Zmie� stan drzwi w zale�no�ci od tego, czy s� otwarte czy zamkni�te
            if (isDoorOpen)
            {
                doorAnimator.SetTrigger("close");
            }
            else
            {
                doorAnimator.SetTrigger("open");
            }

            // Zmiana warto�ci logicznej informuj�cej o stanie drzwi
            isDoorOpen = !isDoorOpen;
        }

        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < distance)
        {
            intText.SetActive(true);
        }
        else
        {
            intText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Wy�wietlenie tekstu, gdy gracz jest wystarczaj�co blisko drzwi
        if (other.CompareTag("Player"))
        {
            intText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Ukrycie tekstu, gdy gracz si� oddali
        if (other.CompareTag("Player"))
        {
            intText.SetActive(false);
        }
    }
}
