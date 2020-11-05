using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ZhuoLuChess
{
    public class CameraManager : Singleton<CameraManager>
    {
        private Camera m_activeCamera;

        public Camera ActiveCamera
        {
            get
            {
                return m_activeCamera;
            }
        }

        private void Awake()
        {
            if(m_activeCamera == null)
                m_activeCamera = gameObject.GetComponent<Camera>();
        }
    }
}
