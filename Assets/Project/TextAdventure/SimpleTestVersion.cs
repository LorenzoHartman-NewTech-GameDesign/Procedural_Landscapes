using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleTestVersion : MonoBehaviour
{
    public InputField mainInputField;
    public Text displayText;
    public string myText;

    public bool disabled = true;
    public CharacterController characterController;
    public Canvas canvas;

    public GameObject terrain;
    public GameObject ocean;
    public GameObject tree;
    public GameObject rock;
    public GameObject grass;

    private void Start()
    {
        //myText = mainInputField.text;
    }
    private void Update()
    {

        myText = mainInputField.text;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            disabled = !disabled;
        }
        if (disabled)
        {
            canvas.gameObject.SetActive(false);
            characterController.enabled = true;
        }
        if (!disabled)
        {
            canvas.gameObject.SetActive(true);
            characterController.enabled = false;
        }


        if (myText == "Create Desert")
        {
            mainInputField.text = " ";
            displayText.text = "You regret wearing Crocs";
            terrain.SetActive(true);
        }

        if (myText == "Create Ocean")
        {
            mainInputField.text = " ";
            displayText.text = "You should have brought flippers";
            ocean.SetActive(true);
        }

        if (myText == "Create Tree")
        {
            mainInputField.text = " ";
            displayText.text = "Some green always looks nice";
            tree.SetActive(true);
        }


        if (myText == "Create Rock")
        {
            mainInputField.text = " ";
            displayText.text = "No not THE Rock";
            rock.SetActive(true);
        }

        if (myText == "Create Grass")
        {
            mainInputField.text = " ";
            displayText.text = "Feel the wind blowing through your hair and grass...";
            grass.SetActive(true);
        }








    }
    



}
