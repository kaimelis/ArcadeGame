using System;
using GXPEngine;
using Objects;
using Utility;
using Vectors;
using XMLReader;
//enum for level of tiles. then check on which we are and if button pressed turn off collision :P
public class Level : GameObject
{
    private int _tileWeight;
    private int _tileHeight;
    private string _tilesName;

    private const int Leftborder = 200;
    private const int Rightborder = 500;

    private Map _map;
    private MyGame _game;
    private Player.Player _player;
    private Tile1 _tile1;
    private Tile2 _tile2;
    private Tile3 _tile3;
    private Grass _grass;
    private Sprite _background1;
    private Sprite _background2;
    private Sprite _background22;
    private Sprite _background3;
    private Sprite _background33;
    private Sprite _clouds1;
    private Sprite _clouds11;
    private Sprite _clouds2;
    private Sprite _clouds22;
    private SoundChannel _musicChannel;

    public Level(string filename, MyGame game)
    {
        _game = game;
        CreateLevel(filename);
        AddMusic();
    }

    void Update()
    {
        Camera();
        HandleClouds();
        HandleBackground();
        
    }

    private void AddMusic()
    {
        Sound music = new Sound(UtilStrings.SoundsLevel + "level.mp3", true, true);
        _musicChannel = music.Play();
    }

    private void Camera()
    {
        if (_player.x > Rightborder)
        {
            x = Rightborder - _player.x;
        }
        if (_player.x < Leftborder)
            x = Leftborder - _player.x;
    }

    private void SetBackground()
    {
        _background1 = new Sprite(UtilStrings.SpritesBack + "background.png");
        AddChild(_background1);

        _background2 = new Sprite(UtilStrings.SpritesBack + "background2.png");
        _background2.SetOrigin(-130,0);
        AddChild(_background2);

        _background22 = new Sprite(UtilStrings.SpritesBack + "background2.png");
        _background22.SetOrigin(-130, 0);
        AddChild(_background22);
        _background22.x = _background2.x + _background2.width;

        _background3 = new Sprite(UtilStrings.SpritesBack + "background1.png");
        _background3.SetOrigin(-130,-70);
        AddChild(_background3);

        _background33 = new Sprite(UtilStrings.SpritesBack + "background1.png");
        _background33.SetOrigin(-130, -70);
        AddChild(_background33);
        _background33.x = _background3.x + _background3.width;

        _clouds1 = new Sprite(UtilStrings.SpritesMenu + "clouds_1.png");
        _clouds1.alpha = 0.3f;
        AddChild(_clouds1);

        _clouds11 = new Sprite(UtilStrings.SpritesMenu + "clouds_1.png");
        _clouds11.alpha = 0.3f;
        AddChild(_clouds11);
        _clouds11.x = _clouds1.x + _clouds1.width;

        _clouds2 = new Sprite(UtilStrings.SpritesMenu + "clouds_2.png");
        _clouds2.alpha = 0.4f;
        _clouds2.SetXY(0, -400);
        AddChild(_clouds2);

        _clouds22 = new Sprite(UtilStrings.SpritesMenu + "clouds_2.png");
        _clouds22.alpha = 0.4f;
        _clouds22.SetXY(0, -400);
        AddChild(_clouds22);
        _clouds22.x = _clouds2.x + _clouds2.width;
    }

    private void HandleClouds()
    {
        _clouds2.x += 0.4f;
        _clouds1.x += 0.4f;
        _clouds11.x += 0.4f;
        _clouds22.x += 0.4f;

    }

    private void HandleBackground()
    {
        _background1.x = _player.x - 500;

    }

    private void CreateLevel(string filename)
    {
        SetBackground();
        TmxParser tmxParser = new TmxParser();
        _map = tmxParser.Parse(filename);

        _tileHeight = _map.Tileset.TileWidth;
        _tileWeight = _map.Tileset.TileWidth;
        _tilesName = _map.Tileset.Image.Source;
        Console.WriteLine(_tilesName);

        /**/
        ObjectGroup[] objectGroups = _map.ObjectGroup;
        for (int i = 0; i < objectGroups.Length; i++)
        {
            if (i == 0)
            {
                //add clounrds
                interpretObjectGroup(objectGroups[i]);
            }
            else interpretObjectGroup(objectGroups[i]);
        }
        /**/
        Layer[] layers = _map.Layer;
        foreach (Layer pLayer in layers)
            InterpretLayer(pLayer);
       
    }

    private void InterpretLayer(Layer layer)
    {
        string csvData = layer.Data.InnerXml;
        csvData = csvData.Replace(Environment.NewLine, "\n");
        string[] lines = csvData.Split('\n');
        for (var k = 0; k < lines.Length; k++)
        {
            var colums = lines[k].Split(',');
            for (var m = 0; m < colums.Length; m++)
            {
                int tile;
                if (int.TryParse(colums[m], out tile))
                    if (tile != 0) InterpretCell(m + 2, k, tile,layer.Name);
            }
        }
    }

    private void InterpretCell(int pX, int pY, int pTileFrame,string name)
    {
        switch (name)
        {
            case "tile1":
                _tile1 = new Tile1(pTileFrame - 1, _tilesName);
                _tile1.SetXY(pX * _tileWeight, pY * _tileHeight);
                AddChild(_tile1);
                break;
            case "tile2":
                _tile2 = new Tile2(pTileFrame - 1, _tilesName);
                _tile2.SetXY(pX * _tileWeight, pY * _tileHeight);
                AddChild(_tile2);
                break;
            case "tile3":
                _tile3 = new Tile3(pTileFrame - 1, _tilesName);
                _tile3.SetXY(pX * _tileWeight, pY * _tileHeight);
                AddChild(_tile3);
                break;
            case "grass":
                _grass = new Grass(pTileFrame -1, _tilesName);
                _grass.SetXY(pX * _tileWeight, pY * _tileHeight);
                AddChild(_grass);
                break;
        }
       
    }

    private void interpretObjectGroup(ObjectGroup objectGroup)
    {
        TiledObject[] objects = objectGroup.TiledObject;
        for (int i = 0; i < objects.Length; i++)
        {
            interpretObject(objects[i]);
        }
    }

    //adding objects
    private void interpretObject(TiledObject tiledObject)
    {
        switch (tiledObject.GID)
        {
            case 16:
                _player = new Player.Player();
                _player.SetOrigin(_player.width /2, _player.height / 2);
                _player.x = tiledObject.X + _player.width/2;
                _player.y = tiledObject.Y - _player.height / 2;
                AddChild(_player);
                break;
            

        }
    }
}
