using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LocalizationText : MonoBehaviour
{
    [SerializeField] private string key;
    private Text text;

    void Awake()
    {
        text = transform.GetComponent<Text>();
    }

    void Start()
    {
        text.text = Localization.GetText(key);
    }
}