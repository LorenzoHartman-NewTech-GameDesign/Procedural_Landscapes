using UnityEngine;
using UnityEngine.UI;

public class SimpleTestVersion : MonoBehaviour
{
    public InputField mainInputField;
    public Text displayText;
    public string myText;

    public bool disabled = true;
    public Transform player; 
    public CharacterController characterController;
    public Canvas canvas;

    public GameObject ocean;
    public GameObject tree;
    public GameObject rock;
    public GameObject grass;

    public GameObject normalCamera;
    public GameObject snowCamera;

    public GameObject desertTerrain;
    public GameObject snowTerrain;

    private void Start()
    {
        //myText = mainInputField.text;
    }
    private void Update()
    {



        myText = mainInputField.text.ToLower();

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


        if (myText == "create desert")
        {
            mainInputField.text = "";
            displayText.text = "You regret wearing Crocs";
            desertTerrain.SetActive(true);
            snowTerrain.SetActive(false);
            normalCamera.SetActive(true);
            snowCamera.SetActive(false);
            player.transform.position += new Vector3 (0,65,0); 
        }

        if (myText == "create snow")
        {
            mainInputField.text = "";
            displayText.text = "Let it snow";
            desertTerrain.SetActive(false);
            snowTerrain.SetActive(true);
            normalCamera.SetActive(false);
            snowCamera.SetActive(true);
            player.transform.position += new Vector3(0, 65, 0);
        }

        if (myText == "create ocean")
        {
            mainInputField.text = "";
            displayText.text = "You should have brought flippers";
            ocean.SetActive(true);
        }

        if (myText == "create tree")
        {
            mainInputField.text = "";
            displayText.text = "Some green always looks nice";
            tree.SetActive(true);
        }


        if (myText == "create rock")
        {
            //mainInputField.text = "";
            displayText.text = "No not THE Rock";
            rock.SetActive(true);
        }

        if (myText == "create grass")
        {
            mainInputField.text = "";
            displayText.text = "Feel the wind blowing through your hair and grass...";
            grass.SetActive(true);
        }









    }




}
