﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhuoLuChess
{
    public class ChessBase : MonoBehaviour
    {
        protected bool m_isEatable;

        public bool IsEatable
        {
            get { return true; }
        }
    }
}

