using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextUpdater : MonoBehaviour
{
    public string updatedText;

    // Use this for initialization
    void Start()
    {
        GetComponent<Text>().text = updatedText;
    }
}
