using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhuoLuChess
{
    // TODO 设置委托
    public class UMAP : Singleton<UMAP>
    {
        // Managers
        public InputManager InputManager;
        public CameraManager CameraManager;
        public PlayerManager PlayerManager;

        // Delegates
        public delegate void UpdateHander();
        public UpdateHander updateHander;

        private void Awake()
        {
            Init();
        }

        private void Update()
        {
            updateHander();
        }

        private void Init()
        {
            InputManager = new InputManager();
            InputManager.Init();

            CameraManager = new CameraManager();
            CameraManager.Init();
            
            PlayerManager = new PlayerManager();
            PlayerManager.Init();

        }
    }
}

