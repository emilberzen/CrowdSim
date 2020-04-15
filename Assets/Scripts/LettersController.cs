using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;
public class LettersController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    public GameObject[] Letters;
    public GameObject boid1;
    public GameObject boid2;
    void Start()
    {
        Debug.Log(Letters.Length);


    }

    // Update is called once per frame
    void Update()
    {
        string buttonPressed = Input.inputString;



        switch (buttonPressed)
        {

            case "a":
                Debug.Log("a pressed");
                
                hideLetters();
                Letters[0].SetActive(true);

                break;

            case "b":

                Debug.Log("b pressed");
                hideLetters();

                Letters[1].SetActive(true);
                break;

            case "c":

                Debug.Log("c pressed");
                hideLetters();

                Letters[2].SetActive(true);
                break;

            case "d":
                Debug.Log("d pressed");
                hideLetters();

                Letters[3].SetActive(true);
                break;

            case "e":
                Debug.Log("e pressed");
                hideLetters();

                Letters[4].SetActive(true);
                break;

            case "f":
                Debug.Log("f pressed");
                hideLetters();

                Letters[5].SetActive(true);
                break;

            case "g":
                Debug.Log("g pressed");
                hideLetters();

                Letters[6].SetActive(true);
                break;

            case " ":
                Debug.Log("Space Pressed");
                hideLetters();
                break;
        }
            
    }

    private void hideLetters()
    {


        for (int i = 0; i < Letters.Length; i++)
        {
            Letters[i].SetActive(false);
        }

    }
}
