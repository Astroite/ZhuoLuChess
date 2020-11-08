using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhuoLuChess
{
    public class ChessBase : MonoBehaviour
    {
        //private Vector3 m_c

        protected bool m_isEatable;

        public bool IsEatable
        {
            get { return true; }
        }

        public void SuspendChessPieceObject()
        {
            Debug.Log(this.gameObject.name + "I am Flying!");
        }

        public void ResetChessPieceObject()
        {
            Debug.Log(this.gameObject.name + "I return to ground!");
        }
    }
}

