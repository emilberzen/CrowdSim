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

    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.anyKeyDown)
        {
            string buttonPressed = Input.inputString;

            if (Input.GetKeyDown(buttonPressed) && buttonPressed != " ")
            {
                hideLetters();
                GameObject.Find(Input.inputString).GetComponent<PolygonCollider2D>().enabled = true;
                Debug.Log(GameObject.Find(Input.inputString));
                


            }

            if (Input.GetKeyDown("space"))
            {
                hideLetters();
            }
        }

        /*

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

            case "h":
                Debug.Log("h pressed");
                hideLetters();

                Letters[7].SetActive(true);
                break;

            case "i":
                Debug.Log("i pressed");
                hideLetters();

                Letters[8].SetActive(true);
                break;

            case "j":
                Debug.Log("j pressed");
                hideLetters();

                Letters[9].SetActive(true);
                break;

            case "k":
                Debug.Log("k pressed");
                hideLetters();

                Letters[10].SetActive(true);
                break;

            case "l":
                Debug.Log("l pressed");
                hideLetters();

                Letters[11].SetActive(true);
                break;

            case "m":
                Debug.Log("m pressed");
                hideLetters();

                Letters[12].SetActive(true);
                break;

            case "n":
                Debug.Log("n pressed");
                hideLetters();

                Letters[13].SetActive(true);
                break;


            case "o":
                Debug.Log("o pressed");
                hideLetters();

                Letters[14].SetActive(true);
                break;


            case "p":
                Debug.Log("p pressed");
                hideLetters();

                Letters[15].SetActive(true);
                break;


            case "q":
                Debug.Log("q pressed");
                hideLetters();

                Letters[16].SetActive(true);
                break;

            case "r":
                Debug.Log("r pressed");
                hideLetters();

                Letters[17].SetActive(true);
                break;

            case "s":
                Debug.Log("r pressed");
                hideLetters();

                Letters[18].SetActive(true);
                break;

            case "t":
                Debug.Log("r pressed");
                hideLetters();

                Letters[19].SetActive(true);
                break;

            case "u":
                Debug.Log("r pressed");
                hideLetters();

                Letters[20].SetActive(true);
                break;

            case "v":
                Debug.Log("v pressed");
                hideLetters();

                Letters[21].SetActive(true);
                break;

            case "w":
                Debug.Log("w pressed");
                hideLetters();

                Letters[22].SetActive(true);
                break;
                
            case "x":
                Debug.Log("x pressed");
                hideLetters();

                Letters[23].SetActive(true);
                break;

            case "y":
                Debug.Log("y pressed");
                hideLetters();

                Letters[24].SetActive(true);
                break;

            case "z":
                Debug.Log("z pressed");
                hideLetters();

                Letters[25].SetActive(true);
                break;

            case " ":
                Debug.Log("Space pressed");
                hideLetters();

                break;


        }
        */

    }

    private void hideLetters()
    {


        for (int i = 0; i < Letters.Length; i++)
        {
           // Letters[i].SetActive(false);
            Letters[i].GetComponent<PolygonCollider2D>().enabled = false;


        }

    }
}
