using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class GameController : MonoBehaviour
{
    public Text displayText;

    public InputAction[] inputActions; 

    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public List<string> interactionDescriptionsInRoom = new List<string>(); 

    List<string> actionLog = new List<string>();
    


    // Start is called before the first frame update
    void Awake()
    {
        roomNavigation = GetComponent<RoomNavigation>();  
    }

    private void Start()
    {
        DisplayRoomText();
        DisplayLoggedText(); 
    }

    //Changed our text in the array into a string that can be displayed in the UI element. 
    public void DisplayLoggedText()
    {
        
        string logAsText = string.Join("\n", actionLog.ToArray());

        displayText.text = logAsText; 
    }


    public void DisplayRoomText()
    {
        ClearCollectionsForNewRoom(); 

        UnpackRoom();

        //adds all our rooms to string, and seperates them on a new line. 
        string joinedInteractionDescriptions = string.Join("\n", interactionDescriptionsInRoom.ToArray());

        string combinedText = roomNavigation.currentRoom.description + "\n" + joinedInteractionDescriptions;

        LogStringWithReturn(combinedText); 
    }


    void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom(); 
    }

    void ClearCollectionsForNewRoom()
    {
        interactionDescriptionsInRoom.Clear();
        roomNavigation.ClearExits(); 
    }



    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }


}
