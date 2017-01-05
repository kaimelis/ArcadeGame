using System;
using System.Drawing;
using GXPEngine;
using UI.MENU;

public class MyGame : Game //MyGame is a Game
{
    private Level _level;
    private MainMenu _menu;

    private string[] _levelNames;
    private string _state;

    //initialize game here
    public MyGame () : base(1024, 768, false)
	{
        PopulateLevelNames();
        SetState("MainMenu");
    }

    private void PopulateLevelNames()
    {
        _levelNames = new[]
        {
                "Level01"
            };
    }

    //update game here
    void Update ()
	{
        if (Input.GetKeyDown(Key.Q)) NextLevel();
    }
	
	//system starts here
	static void Main() 
	{
		new MyGame().Start();
	}

    public void SetState(string state, bool restart = false)
    {

        if (state == _state && !restart) return;
        StopState();
        _state = state;
        StartState();
    }

    private void StopState()
    {
        switch (_state)
        {
            case "MainMenu":
                _menu.StopMusic();
                _menu.Destroy();
                _menu = null;
                break;
            case "Level01":
               // _level.StopMusic();
                _level.Destroy();
                _level = null;
                break;
            //case "Level02":
            //    //_level.StopMusic();
            //    _level.Destroy();
            //    _level = null;
            //    break;
            //case "Credits":
            //    _credits.StopMusic();
            //    _credits.Destroy();
            //    _credits = null;
            //    break;
        }
    }

    private void StartState()
    {
        switch (_state)
        {
            case "MainMenu":
                _menu = new MainMenu(this);
                AddChild(_menu);
                break;
            case "Level01":
                _level = new Level("Level01.tmx", this);
                AddChild(_level);
                break;
            //case "Level02":
            //   // _level = new Level.Level("level02.tmx", this);
            //    //AddChild(_level);
            //    break;
            //case "Credits":
            //    _credits = new Credits(this);
            //    AddChild(_credits);
            //    break;
            case "Exit":
                Environment.Exit(0);
                break;
            default:
                throw new Exception("You tried to load a non-existant state");
        }
    }

    //public void StartWinScreen()
    //{
    //    _winScreen = new WinScreen(this);
    //    AddChild(_winScreen);
    //}

    //public void StartGameOver()
    //{
    //    _gameOver = new GameOver(this);
    //    AddChild(_gameOver);
    //}

    public void NextLevel()
    {
        for (int i = 0; i < _levelNames.Length; i++)
        {
            if (_levelNames[i] == _state)
            {
                if (i < _levelNames.Length - 1)
                {
                    SetState(_levelNames[i + 1]);
                    break;
                }
                else
                {
                  //  SetState("Credits");
                    break;
                }
            }
        }
    }
}
