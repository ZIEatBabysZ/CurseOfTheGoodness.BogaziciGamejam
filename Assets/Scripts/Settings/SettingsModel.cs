using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public static class SettingsModel
{
        [Serializable]
        public class PlayerSettingsModel
        {
            [Header("Movement values")]
            [Range(0,100)]
            public float movementSpeed;
            [Range(0, 100)]
            public float groundCheckDistance;
            public float jumpForce;

        }


        [Serializable]
        public class CameraSettingsModel
        {
                [Header("Camera follow values")]
                [Range(0, 10)]
                public float CameraSpeed;

        }

}






