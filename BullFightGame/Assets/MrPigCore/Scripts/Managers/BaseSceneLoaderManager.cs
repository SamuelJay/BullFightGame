using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MrPigCore {
    public class BaseSceneLoaderManager : Manager {
        //public virtual  enum Scenes();

        public void LoadScene(int sceneNumber, LoadSceneMode sceneMode) {
            SceneManager.LoadScene(sceneNumber, sceneMode);
        }

        public void UnloadScene(int sceneNumber) {
            SceneManager.UnloadSceneAsync(sceneNumber);
        }
    }
}
