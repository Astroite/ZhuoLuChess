using UnityEngine;

namespace ZhuoLuChess
{
    public class InputManager : ManagerBase
    {
        public GameObject CurrentSelectedGameObject { get; private set; }

        public override void Init()
        {
            CurrentSelectedGameObject = null;

            UMAP.I.updateHander += Update;
        }

        public override void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                CurrentSelectedGameObject = GetRayHitGameObject(Input.mousePosition);
            }
        }

        //private GameObject GetChessSeat()
        //{
               
        //}

        private ChessBase GetChessPiece(Vector3 mousePosition)
        {
            ChessBase chessPiese = null;
            GameObject gameObject = GetRayHitGameObject(mousePosition);
#if UNITY_EDITOR
            if(gameObject != null)
            {
                GameObject parent = gameObject.transform.parent.gameObject;
                GameObject grandParent = parent.transform.parent.gameObject;
                Debug.Log(grandParent.name + " " + parent.name);
            }
#endif
            if (gameObject != null)
                chessPiese = gameObject.GetComponentInChildren<ChessBase>();
            return chessPiese;
        }

        private GameObject GetRayHitGameObject(Vector3 mousePosition)
        {
            Ray ray = UMAP.I.CameraManager.MainCamera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                GameObject gameObject = hitInfo.collider.gameObject;
#if UNITY_EDITOR
                Debug.DrawLine(ray.origin, hitInfo.point);
#endif
                return gameObject;
            }
            return null;
        }

        public void ClearCurrentSelectedObject()
        {
            CurrentSelectedGameObject = null;
        }
    }
}
