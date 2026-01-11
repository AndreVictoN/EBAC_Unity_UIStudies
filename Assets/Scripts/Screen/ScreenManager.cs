using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

namespace Screens
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        public List<ScreenBase> screenBases;
        public ScreenType startScreen = ScreenType.Panel;
        
        private ScreenBase _currentScreen;


        void Start()
        {
            HideAll();
            ShowByType(startScreen);
        }

        public void ShowByType(ScreenType type)
        {
            if(_currentScreen != null) _currentScreen.Hide();

            var nextScreen = screenBases.Find(screen => screen.screenType == type);

            nextScreen.Show();
            _currentScreen = nextScreen;
        }

        public void HideAll() => screenBases.ForEach(screen => screen.Hide());
    }
}
