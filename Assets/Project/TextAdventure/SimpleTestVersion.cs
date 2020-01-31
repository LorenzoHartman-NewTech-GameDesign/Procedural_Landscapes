using UnityEngine;
using UnityEngine.UI;
using GlobalSnowEffect; 

public class SimpleTestVersion : MonoBehaviour
{
    public InputField mainInputField;
    public Text displayText;
    public string myText;

    public ItemAreaSpawner treeSpawner;
    public ItemAreaSpawner rockSpawner;
    public ItemAreaSpawner grassSpawner;

    public GlobalSnow globalSnowEffect; 

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

    public Light directionalLight;
    public Material originalSkybox;
    public Material rainSkybox;

    public GameObject rainParticles; 


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
            mainInputField.ActivateInputField();
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
            GameObject.Find("SnowParticleSystem").SetActive(false);

        }

        if (myText == "create snow")
        {
            mainInputField.text = "";
            displayText.text = "Let it snow";
            desertTerrain.SetActive(false);
            snowTerrain.SetActive(true);
            normalCamera.SetActive(false);
            snowCamera.SetActive(true);
            GameObject.Find("SnowParticleSystem").SetActive(true);


            globalSnowEffect.UpdateProperties(); 
        }


        if (myText == "rain on")
        {
            mainInputField.text = "";
            displayText.text = "The world looks a lot more grey all of the sudden...";
            RenderSettings.skybox = rainSkybox;
            rainParticles.SetActive(true);
            directionalLight.enabled = false;           
        }

        if (myText == "rain off")
        {
            mainInputField.text = "";
            displayText.text = "All must fade eventually, even the dark";
            RenderSettings.skybox = originalSkybox;
            rainParticles.SetActive(false);
            directionalLight.enabled = true;
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
            displayText.text = "There is nothing wrong with having a tree as a friend. ― Bob Ross";
            treeSpawner.Spawn();
            globalSnowEffect.UpdateProperties();
        }


        if (myText == "create rock")
        {
            mainInputField.text = "";
            displayText.text = "No not THE Rock";
            rockSpawner.Spawn();
            globalSnowEffect.UpdateProperties();
        }

        if (myText == "create grass")
        {
            mainInputField.text = "";
            displayText.text = "Feel the wind blowing through your hair and grass...";
            grassSpawner.Spawn();
        }









    }




}
