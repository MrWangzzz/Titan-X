using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TitanX
{
    public class ISceneManger : SingletonMono<ISceneManger>
    {

        public int PlayerInMapID;

        public void LoadMap(int index) 
        {
            SceneManager.LoadScene(index, LoadSceneMode.Additive);
        }
        public void LoadMap(string name )
        {
            SceneManager.LoadScene(name, LoadSceneMode.Additive);
        }
    }
}
