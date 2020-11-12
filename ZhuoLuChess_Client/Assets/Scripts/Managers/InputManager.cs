using UnityEngine;

namespace ZhuoLuChess
{
    public class InputManager : ManagerBase
    {
        public bool NeedMonitorChessSeat;
        public GameObject CurrentPointedGameObject { get; private set; }
        public bool NeedMonitorChessPiece;
        public GameObject CurrentSelectedGameObject { get; private set; }

        public override void Init()
        {
            NeedMonitorChessSeat = false;
            CurrentSelectedGameObject = null;
            NeedMonitorChessPiece = false;
            CurrentPointedGameObject = null;

            UMAP.I.updateHander += Update;
        }

        public override void Update()
        {

            if (NeedMonitorChessPiece && Input.GetMouseButtonDown(0))
            {
                CurrentSelectedGameObject = GetRayHitGameObject(Input.mousePosition);
            }

            if(NeedMonitorChessSeat)
            {
                CurrentPointedGameObject = GetRayHitGameObject(Input.mousePosition);
            }
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
