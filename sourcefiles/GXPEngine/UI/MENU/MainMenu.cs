using GXPEngine;
using Utility;
using XMLReader;

namespace UI.MENU
{
    class MainMenu : GameObject
    {
        private Button[] _buttons;
        private MyGame _game;
        private Sprite _background;
        private Sprite _background1;
        private Sprite _background2;
        private Sprite _title;
        private Sprite _cloud1;
        private Sprite _cloud2;
        private Sprite _cloud11;
        private SoundChannel _musicChannel;
        private Sound _selectedSound;

        private int _speed;
        private int _selection;
        private bool _scrolling;
        private float _cloudSpeed;

        public MainMenu(MyGame pGame)
        {
            _game = pGame;

            _speed = 5;
            _scrolling = true;
            _cloudSpeed = 0.5f;

            SetBackground();
            SetButtons();
            AddMusic();
          
        }

        private void AddMusic()
        {
            // _selectedSound = new Sound(UtilStrings.SoundsMenu + "sound_selected.wav");
            Sound music = new Sound(UtilStrings.SoundsMenu + "Grasslands Theme.mp3", true, true);
            _musicChannel = music.Play();
        }

        private void SetBackground()
        {
            _background = new Sprite(UtilStrings.SpritesMenu + "background.png");
            AddChild(_background);

            _background2 = new Sprite(UtilStrings.SpritesMenu + "background2.png");
            AddChild(_background2);

            _background1 = new Sprite(UtilStrings.SpritesMenu + "background1.png");
            AddChild(_background1);

            _title = new Sprite(UtilStrings.SpritesMenu + "title.png");
            _title.x = _game.width / 2 - _title.width / 2;
            _title.y = -_title.height;
            AddChild(_title);

            _cloud1 = new Sprite(UtilStrings.SpritesMenu + "clouds_1.png");
            _cloud1.alpha = 0.3f;
            AddChild(_cloud1);

            _cloud11 = new Sprite(UtilStrings.SpritesMenu + "clouds_1.png");
            _cloud11.alpha = 0.3f;
            _cloud11.SetXY(-3840, 0);
            AddChild(_cloud11);

            _cloud2 = new Sprite(UtilStrings.SpritesMenu + "clouds_2.png");
            _cloud2.alpha = 0.4f;
            _cloud2.SetXY(0, -400);
            AddChild(_cloud2);
        }

        void HandleClouds()
        {
            _cloud2.x += 0.1f;
            _cloud1.x += _cloudSpeed * 3;
            _cloud11.x += _cloudSpeed * 3;
            if (_cloud1.x > 1000) _cloud1.x = -1000;
            if (_cloud2.x > 3840) _cloud2.x = -3840;
            if (_cloud11.x > 3840) _cloud11.x = -3840;

        }

        void HandleBackground()
        {
            _background2.x -= _cloudSpeed;
            if (_background2.x > 6400) _background2.x = -6400;
        }


        private void SetButtons()
        {
            _buttons = new[]
            {
                new Button(UtilStrings.SpritesMenu + "Start.png", 2, 600, -100, "Level01"),
                new Button(UtilStrings.SpritesMenu + "credits.png",2,600,-100, "Credits"),
                new Button(UtilStrings.SpritesMenu + "quit.png",2,600, -100, "Exit"),
            };

            foreach (var button in _buttons)
            {
                AddChild(button);
            }
            _buttons[0].Selected();
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(Key.UP) || Input.GetKeyDown(Key.W)) SelectionUp();
            if (Input.GetKeyDown(Key.DOWN) || Input.GetKeyDown(Key.S)) SelectionDown();
            if (Input.GetKeyDown(Key.ENTER) || Input.GetKeyDown(Key.SPACE)) Select();

            HandleClouds();
            HandleBackground();

            if (_title.y < 50)
            {
                _title.y += _speed;
                _scrolling = true;
            }
            else
            {
                _scrolling = false;
                _speed = 9;
            }
            if (_buttons[0].y < 300 && !_scrolling) _buttons[0].y += _speed;
            if (_buttons[1].y < 450 && !_scrolling) _buttons[1].y += _speed;
            if (_buttons[2].y < 600 && !_scrolling) _buttons[2].y += _speed;
        }

        private void SelectionDown()
        {
            //_selectedSound.Play();
            _buttons[_selection].DeSelect();
            if (_selection < _buttons.Length - 1) _selection++;
            else _selection = 0;
            _buttons[_selection].Selected();



        }

        private void SelectionUp()
        {
            //_selectedSound.Play();
            _buttons[_selection].DeSelect();
            if (_selection > 0) _selection--;
            else _selection = _buttons.Length - 1;
            _buttons[_selection].Selected();
        }

        private void Select()
        {
            _game.SetState(_buttons[_selection].Pressed());
        }

        public void StopMusic()
        {
            _musicChannel.Stop();
        }
    }
}
