using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Sashka.Infastructure
{
    public class LoadPortState //: IState
    {
        //private const string PortArea = "PortArea";
        //private readonly GameStateMachine _gameStateMachine;
        //private readonly ScenLoader _scenLoader;

        //public LoadPortState(GameStateMachine gameStateMachine, ScenLoader scenLoader)
        //{
        //    _gameStateMachine = gameStateMachine;
        //    _scenLoader = scenLoader;
        //}

        //public void Enter()
        //{
        //    _scenLoader.Load(PortArea, onLoaded: LoadHero);
        //}

        //public void Exit()
        //{
        //}

        //private void LoadHero()
        //{
        //    Debug.Log("OnLoaded");
        //    var initialPoint = GameObject.FindWithTag("InitialPoint");
        //    GameObject hero = Instantiate("Hero/player/player", point: initialPoint.transform.position);
        //    hero.transform.SetParent(Camera.main.transform);
        //}

        //private static GameObject Instantiate(string path, Vector3 point)
        //{
        //    var prefab = Resources.Load<GameObject>(path);
        //    return Object.Instantiate(prefab, point, Quaternion.identity);
        //}        
    }
}
