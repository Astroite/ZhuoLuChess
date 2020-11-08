using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhuoLuChess
{
    public class CameraManager : ManagerBase
    {
        private Camera m_activeCamera;

        public Camera MainCamera
        {
            get
            {
                return m_activeCamera;
            }
        }

        public override void Init()
        {
            if (m_activeCamera == null) 
                m_activeCamera = Camera.main;
        }
    }
}
