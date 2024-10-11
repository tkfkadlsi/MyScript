using Karin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tkfkadlsi
{
    public class BuildModes : MonoBehaviour
    {
        [SerializeField] private GameObject selectTileForBuild;
        [SerializeField] private GameObject selectTileForDestroy;
        [SerializeField] private GameObject buildCanvas;
        [SerializeField] private GameObject unitCanvas;
        [SerializeField] private GameObject techCanvas;
        [SerializeField] private GameObject settingCanvas;

        [SerializeField] private Sprite defaultCursor;
        [SerializeField] private Sprite buildCursor;
        [SerializeField] private Sprite destroyCursor;

        public BuildMode buildMode;
        [SerializeField] private InputReaderSO inputReader;

        public enum BuildMode
        {
            None = 0,
            Select = 1,
            Build = 2,
            Destroy = 3,
            Exception = 4,
            Setting = 5
        }

        private void OnEnable()
        {
            inputReader.EscEvent += Cancer;
        }
        private void OnDisable()
        {
            inputReader.EscEvent -= Cancer;
        }

        private void Start()
        {
            buildMode = BuildMode.None;
            buildCanvas.SetActive(false);
            unitCanvas.SetActive(false);
            techCanvas.SetActive(false);
            settingCanvas.SetActive(false);
        }

        private void Cancer()
        {
            switch (buildMode)
            {
                case BuildMode.None:
                    break;
                case BuildMode.Select:
                    CancleSelectMode();
                    break;
                case BuildMode.Build:
                    CancleBuildMode();
                    break;
                case BuildMode.Destroy:
                    CancleDestroyMode();
                    break;
                case BuildMode.Exception:
                    CancleExceptionMode();
                    break;
                case BuildMode.Setting:
                    CancleSettingMode();
                    break;
            }
        }

        public void OnSelectMode()
        {
            if (buildMode != BuildMode.None) return;

            buildMode = BuildMode.Select;
            CursorPosition.Instance.SetPlusPosition(new Vector2(0, 0));
            buildCanvas.SetActive(true);
            unitCanvas.SetActive(false);
            techCanvas.SetActive(false);
            selectTileForDestroy.SetActive(false);
            selectTileForBuild.SetActive(false);
            //이걸 보면 버튼을 만들고 Select와 Destroy를 연결해라 미래의 나야
        }

        private void CancleSelectMode()
        {
            buildMode = BuildMode.None;
            CursorPosition.Instance.SetPlusPosition(new Vector2(0, 0));
            buildCanvas.SetActive(false);
        }

        public void OnBuildMode()
        {
            buildMode = BuildMode.Build;
            SetCursorSprite(buildCursor);
            CursorPosition.Instance.SetPlusPosition(new Vector2(0.5f, 0.5f));
            buildCanvas.SetActive(false);
            unitCanvas.SetActive(false);
            techCanvas.SetActive(false);
            selectTileForDestroy.SetActive(false);
        }

        private void CancleBuildMode()
        {
            buildMode = BuildMode.None;
            SetCursorSprite(defaultCursor);
            CursorPosition.Instance.SetPlusPosition(new Vector2(0, 0));
            selectTileForBuild.SetActive(false);
        }

        public void BuildComplete()
        {
            buildMode = BuildMode.None;
            SetCursorSprite(defaultCursor);
            CursorPosition.Instance.SetPlusPosition(new Vector2(0, 0));
            selectTileForBuild.SetActive(false);
        }

        public void OnDestroyMode()
        {
            if (buildMode != BuildMode.None) return;

            buildMode = BuildMode.Destroy;
            SetCursorSprite(defaultCursor);
            CursorPosition.Instance.SetPlusPosition(new Vector2(0.5f, 0.5f));
            selectTileForDestroy.SetActive(true);
            selectTileForBuild.SetActive(false);
            buildCanvas.SetActive(false);
            unitCanvas.SetActive(false);
            techCanvas.SetActive(false);
        }

        private void CancleDestroyMode()
        {
            buildMode = BuildMode.None;
            SetCursorSprite(defaultCursor);
            CursorPosition.Instance.SetPlusPosition(new Vector2(0, 0));
            selectTileForDestroy.SetActive(false);
        }

        public void OnUnitSelectMode()
        {
            if (buildMode != BuildMode.None) return;

            buildMode = BuildMode.Exception;
            buildCanvas.SetActive(false);
            unitCanvas.SetActive(true);
            techCanvas.SetActive(false);
            selectTileForBuild.SetActive(false);
            selectTileForDestroy.SetActive(false);
        }

        public void OnTechTreeMode()
        {
            if (buildMode != BuildMode.None) return;

            buildMode = BuildMode.Exception;
            buildCanvas.SetActive(false);
            unitCanvas.SetActive(false);
            techCanvas.SetActive(true);
            selectTileForBuild.SetActive(false);
            selectTileForDestroy.SetActive(false);
        }

        public void CancleExceptionMode()
        {
            if (TechMaster.Instance.IsRunning) return;

            buildMode = BuildMode.None;
            unitCanvas.SetActive(false);
            techCanvas.SetActive(false);
        }

        public void OnSettingMode()
        {
            if (buildMode != BuildMode.None) return;

            buildMode = BuildMode.Setting;
            buildCanvas.SetActive(false);
            unitCanvas.SetActive(false);
            techCanvas.SetActive(false);
            selectTileForBuild.SetActive(false);
            selectTileForDestroy.SetActive(false);
            settingCanvas.SetActive(true);
        }

        public void CancleSettingMode()
        {
            buildMode = BuildMode.None;
            settingCanvas.SetActive(false);
        }
        

        private void SetCursorSprite(Sprite sprite)
        {
            CursorPosition.Instance.SetCursorSprite(sprite);
        }
    }
}
