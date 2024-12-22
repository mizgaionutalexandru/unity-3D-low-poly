using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestinationReached : MonoBehaviour
{
    private bool isColliding = false;
    public float destinationDelay = 1f;

    public void OnTriggerEnter(Collider other)
    {
        if (!isColliding)
        {
            isColliding = true;
            StartCoroutine(DeactivateAfterDelay(destinationDelay));
        }
    }

    public void OnTriggerExit(Collider other)
    {
        isColliding = false; 
    }

    private System.Collections.IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (isColliding)
        {
            EndGameTextController.text = "Destination reached!";
            SceneManager.LoadScene("EndGame");
        }
    }
}
