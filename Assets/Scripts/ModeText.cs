using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ModeText : MonoBehaviour {

    public string[] mode;
    ShopController sc;
    Text text;

    void Start()
    {
        sc = FindObjectOfType<ShopController>();
        text = GetComponent<Text>();
    }

    public void changeText()
    {
        text.text = mode[sc.ModeId()];
    }
}
