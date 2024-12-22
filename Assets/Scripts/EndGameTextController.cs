using TMPro;
using UnityEngine;

public class EndGameTextController : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public static string text = "[end game]";

    public void Update()
    {
        textMesh.text = text;
    }
}
