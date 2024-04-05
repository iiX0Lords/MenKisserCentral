﻿using BepInEx.Logging;
using PixelGunCheat;
using PixelGunCheat.util;
using UnityEngine;
using UnityEngine.InputSystem;
using Renderer = PixelGunCheat.util.Renderer;
using Logger = BepInEx.Logging.Logger;
using BepInEx.Configuration;

namespace PixelGunCheat.modules.impl.arbitrary
{
    public class CheatModuleHud : CheatModuleArbitrary
    {
        private ManualLogSource logger = Logger.CreateLogSource("Cheat");

        private bool _downDown = false;
        private bool _upDown = false;
        private bool _rightDown = false;
        private bool _hudOpen = true;
        private bool _hudDown = false;

        private ICheatModule[] modules;
        private int selected = 0;
        private float maxY;


        private HSVColor _gay = HSVColor.FromRGB(1, 0, 1);
        public CheatModuleHud(Key k) : base(k)
        {
        }

        public void registerModules(params ICheatModule[] cheatModules)
        {
            modules = cheatModules;
        }

        public override string GetName()
        {
            return "HUD";
        }

        public override void HandleCheat(GameObject g = null)
        {
            _gay.Hue+=0.1f;
            if (_gay.Hue > 360) _gay.Hue = 0;

            if (Input.GetKeyDown(KeyCode.Insert))
            {
                if (!_hudDown)
                {
                    _hudDown = true;
                    _hudOpen = !_hudOpen;
                }
            }
            else
            {
                _hudDown = false;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (!_downDown)
                {
                    _downDown = true;
                    selected++;
                    if (selected > modules.Length - 1) selected = 0;
                }
            }
            else
            {
                _downDown = false;
            }
            
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (!_upDown)
                {
                    _upDown = true;
                    selected--;
                    if (selected < 0) selected = modules.Length - 1;
                }
            }
            else
            {
                _upDown = false;
            }
            
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (!_rightDown)
                {
                    _rightDown = true;
                    modules[selected].ToggleModule();
                }
            }
            else
            {
                _rightDown = false;
            }
            if (_hudOpen)
            {
                Renderer.SetFontSize(Renderer.ScaleValInt(32));
            Renderer.DrawSquare(new Vector2(20, 100), new Vector2(Renderer.ScaleValInt(300), Renderer.ScaleValInt(70)), new Color(0, 0,0, 0.75f));
            Renderer.DrawStringShadow(new Vector2(25, 120), " BoyKisserCentral", _gay.AsARGB(1), false);
            //Renderer.SetFontSize(Renderer.ScaleValInt(24));
           // Renderer.DrawStringShadow(new Vector2(25, 25 + Renderer.ScaleValInt(34)), "github.com/stanuwu & github.com/hiderikzki", _gay.AsARGB(1), false);
            Renderer.SetFontSize(Renderer.ScaleValInt(20));
            
            float height = maxY + Renderer.ScaleValInt(15);
            Renderer.DrawSquare(new Vector2(20, 150 + Renderer.ScaleValInt(20)), new Vector2(Renderer.ScaleValFloat(300), height), new Color(0, 0,0, 0.75f));
            
            float offset = 150 + Renderer.ScaleValInt(35);
            int index = 0;

            
                foreach (var module in modules)
                {
                    var content = new GUIContent(module.GetName());
                    var size = Renderer.StringStyle.CalcSize(content);
                    Renderer.DrawStringShadow(new Vector2(28 + Renderer.ScaleValInt(19), offset), module.GetName(), module.IsEnabled() ? _gay.AsARGB(1) : Color.gray, false);

                    if (index == selected)
                    {
                        Renderer.DrawStringShadow(new Vector2(28, offset), ">", Color.magenta, false);
                        Renderer.DrawStringShadow(new Vector2(28 + size.x + Renderer.ScaleValInt(27), offset), "<", Color.magenta, false);
                    }

                    offset += size.y;
                    index++;
                }
            maxY = offset - 180;
            }
        }
    }
}