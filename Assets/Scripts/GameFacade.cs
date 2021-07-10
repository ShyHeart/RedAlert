using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class GameFacade
    {

        //私有的实例
        private static GameFacade _instance = new GameFacade();
        private bool m_IsGameOver = false;

        //单例模式
        public static GameFacade Instance{get{return _instance;}}

        public bool isGameOver{get{return m_IsGameOver;}}


        private GameFacade()
        {

        }

        public void Init()
        {

        }

        public void Updata()
        {

        }

        public void Release()
        {

        }

    }
