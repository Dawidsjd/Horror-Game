using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnimator;
    public GameObject intText;
    public float distance = 0.6f; // odleg³oœæ, w której gracz mo¿e otworzyæ drzwi
    private bool isDoorOpen = false;

    private void Update()
    {
        // SprawdŸ, czy gracz nacisn¹³ klawisz "E" i jest w odpowiedniej odleg³oœci
        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < distance)
        {
            // Zmieñ stan drzwi w zale¿noœci od tego, czy s¹ otwarte czy zamkniête
            if (isDoorOpen)
            {
                doorAnimator.SetTrigger("close");
            }
            else
            {
                doorAnimator.SetTrigger("open");
            }

            // Zmiana wartoœci logicznej informuj¹cej o stanie drzwi
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
        // Wyœwietlenie tekstu, gdy gracz jest wystarczaj¹co blisko drzwi
        if (other.CompareTag("Player"))
        {
            intText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Ukrycie tekstu, gdy gracz siê oddali
        if (other.CompareTag("Player"))
        {
            intText.SetActive(false);
        }
    }
}
