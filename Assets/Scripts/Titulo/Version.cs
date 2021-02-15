using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Version : MonoBehaviour
{
    private Text versionTexto;

    // Start is called before the first frame update
    void Start()
    {
        versionTexto = GetComponent<Text>();
        versionTexto.text = "V" + Application.version;
    }
}
