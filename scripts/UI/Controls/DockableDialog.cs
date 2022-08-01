/*
 * Dockable Dialog
 *
 * Only supports a vertical layout right now
 *
 * TODO: Add ability to spawn a dialog docked
 *
 * (C) 2022 by K. "ashifolfi" J.
 */
using System;
using Godot;
using Chisel;

namespace Chisel.UI
{
    public class DockableDialog : WindowDialog
    {
        private DockableDialog Self;

        public WindowDockContainer DockContainer;
        
        private Boolean Docked;
        private Boolean Moving;
        private Vector2 PrevPosition;

        public override void _Ready()
        {
            Self = GetNode<DockableDialog>(".");

            Visible = true;
        }

        public void ToWindow()
        {
            GetCloseButton().Visible = true;
            Resizable = true;
            Docked = false;
            DockContainer = null;
        }

        public void ToDock(WindowDockContainer Container)
        {
            Resizable = false;
            DockContainer = Container;
            GetCloseButton().Visible = false;
            
            // Constrain ourselves into the X of the dock
            RectPosition = new Vector2(Container.RectPosition.x, RectPosition.y);
        }

        public override void _Process(float delta)
        {
            // Process moving over a dock container and dock accordingly
          
            // Iterate through every dock container and compare positions
            foreach (WindowDockContainer Dock in Globals.RootPanel.DockContainers.ToArray())
            {
                // Position checking
                Vector2 FScale = Dock.RectSize + Dock.RectPosition;
                if (RectPosition > Dock.RectPosition && RectPosition < FScale)
                {
                    if (!Moving)
                    {
                        ToDock(Dock);
                    }
                }
                else
                {
                    if (!Moving)
                    {
                        ToWindow();
                    }
                }
            }
        }

        public override void _GuiInput(InputEvent @event)
        {
            // If any mouse event occurs and our rect position starts to change then set to moving
            if (@event is InputEventMouse && PrevPosition != RectPosition)
            {
                PrevPosition = RectPosition;
                Moving = true;
            }
            else
            {
                Moving = false;
            }
        }

        public override void _Draw()
        {
        }
    }
}