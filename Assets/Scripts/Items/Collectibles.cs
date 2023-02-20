using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{
    private Text gemText;
    public int gemNumber;

    // Start is called before the first frame update
    void Start()
    {

        gemNumber = 0;
        Debug.Log(gemNumber);

        gemText = GameObject.FindGameObjectWithTag("GemUI").GetComponentInChildren<Text>();
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void UpdateText()
    {
        gemText.text = gemNumber.ToString();
    }
    public void GemCollected()
    {
        gemNumber += 1;
        UpdateText();
    }

}
