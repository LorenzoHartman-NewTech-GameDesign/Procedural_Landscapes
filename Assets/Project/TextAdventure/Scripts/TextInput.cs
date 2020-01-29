using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TextInput : MonoBehaviour
{
    public bool disabled = true;
    public CharacterController characterController; 
    public Canvas canvas; 
    public InputField inputField; 

    GameController controller;

    private void Awake()
    {
        controller = GetComponent<GameController>();
        inputField.onEndEdit.AddListener(AcceptStringInput);
    }

    public void Update()
    {


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



    }





    void AcceptStringInput(string userInput)
    {
        //Normalises all input the be small letters.
        userInput = userInput.ToLower();
        //Shows what the user has just typed.
        controller.LogStringWithReturn(userInput);

        //These are the characters that will seperate our words, space in this case. 
        char[] delimiterCharacters = { ' ' };
        //Breaks up it into two words.
        string[] separatedInputWords = userInput.Split(delimiterCharacters);

        //Check if we have an action that matches the typed keyword. 
        for (int i = 0; i < controller.inputActions.Length; i++)
        {
            InputAction inputAction = controller.inputActions[i];
            if (inputAction.keyWord == separatedInputWords[0])
            {
                //If the first word is correct then check the second word.
                inputAction.RespondToInput(controller, separatedInputWords); 
            }
        }

        //saves
        InputComplete(); 
    }


    void InputComplete()
    {
        controller.DisplayLoggedText();
        //Makes sure the input field stays focused if you want to type more than one. Input field should instead be de activated upon lowering the display. 
        inputField.ActivateInputField();
        inputField.text = null; 

    }


}
