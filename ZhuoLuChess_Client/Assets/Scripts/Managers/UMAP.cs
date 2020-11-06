using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhuoLuChess
{
    // TODO 设置委托
    public class UMAP : Singleton<UMAP>
    {
        public InputManager InputManager;
        public CameraManager CameraManager;
        public PlayerManager PlayerManager;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            InputManager = new InputManager();
            CameraManager = new CameraManager();
            PlayerManager = new PlayerManager();
        }
    }
}

