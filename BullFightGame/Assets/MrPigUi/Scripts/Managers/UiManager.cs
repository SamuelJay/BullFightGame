using System.Collections;
using System.Collections.Generic;
using MrPigCore;
using UnityEngine;

namespace MrPigUi {

    public class UiManager : Manager {

        private GameObject canvasObject;

        public GameObject CreateCanvas(string canvasName) {
            GameObject canvasPrefab;
            GameObject canvasObject;
            canvasName = "Canvases/" + canvasName;
            canvasPrefab = Resources.Load(canvasName) as GameObject;
            canvasObject = Instantiate<GameObject>(canvasPrefab);
            return canvasObject;
        }


        public void LoadMainMenu() {

        }

        private void Start() {

        }

        private void Update() {

        }

        public override void Setup(BaseManagerHelper baseManagerHelperIn) {
            base.Setup(baseManagerHelperIn);

        }

    }
}
