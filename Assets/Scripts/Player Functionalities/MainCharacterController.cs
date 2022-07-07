using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{
    ///<summary> Class for player functionalities only, for movement refer to the CharacterMovementController class instead </summary>
    public IFunctionInteract functionInteractable;
    void Start()
    {
        functionInteractable = GetComponent<IFunctionInteract>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            functionInteractable.UseTool();
        }
    }
}
