using Core;
using Core.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UserInputSystem
{

    public class UserInputInitialization: ICleanable, IController
    {
        public Input UserInput { get; private set; }

        public UserInputInitialization()
        {
            UserInput = new Input();
            UserInput.Enable();
        }

        public void CleanUp()
        {
            UserInput.Disable();
        }
    }
}