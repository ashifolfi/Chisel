/*
    TextureRadio

    Custom button that contains a dictionary used to change active texture

    (C) 2022 by K. "Ashifolfi" J.
*/

using Godot;
using Godot.Collections;
using System;

public class TextureRadio : CheckButton
{
    [Export] public Dictionary<String, ImageTexture> HasTexture;
    [Export] public String TextureName;
}