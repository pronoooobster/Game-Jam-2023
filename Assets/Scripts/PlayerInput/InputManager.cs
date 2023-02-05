using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletonPersistent<InputManager>
{
    public struct PlayerInput
    {
        public Vector2 MousePosition;
        public bool SelectInput;
        public bool UnselectInput;
    }

    public PlayerInput Current;

    // Start is called before the first frame update
    void Start()
    {
        Current = new PlayerInput();
    }

    // Update is called once per frame
    void Update()
    {
        // If the game is paused, don't register the input
        MyInput();
    }

    private void MyInput()
    {
        Vector2 mousePosition = Input.mousePosition;

        bool selectInput = Input.GetMouseButtonDown(0);
        bool unselectInput = Input.GetKeyDown(KeyCode.Escape);

        Current = new PlayerInput()
        {
            MousePosition = mousePosition,
            SelectInput = selectInput,
            UnselectInput = unselectInput
        };

    }
}
