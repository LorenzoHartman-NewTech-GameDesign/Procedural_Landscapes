using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    // Start is called before the first frame update
    public Room currentRoom;

    Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>(); 
    

    GameController controller;

    private void Awake()
    {
        controller = GetComponent<GameController>(); 
    }

    public void UnpackExitsInRoom()
    {
        for (int i = 0; i < currentRoom.exits.Length; i++) 
        {
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom);

            //send the list of exit descriptions to our list of descriptions. 
            controller.interactionDescriptionsInRoom.Add(currentRoom.exits [i].exitDescription);
        }
    }

    public void AttemptToChangeRooms(string directionNoun)
    {
        if (exitDictionary.ContainsKey(directionNoun))
        {
            currentRoom = exitDictionary[directionNoun];
            controller.LogStringWithReturn("You have created the " + directionNoun);
            controller.DisplayRoomText();
           
        }
        else
        {
            controller.LogStringWithReturn("It seems like you do not have that power yet" + directionNoun); 
        }

    }

    public void ClearExits()
    {
        exitDictionary.Clear();
    }


}
