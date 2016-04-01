﻿using System;
using System.Diagnostics;
using System.Linq;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Catrobat.Paint.WindowsPhone.Tool;

// Die Elementvorlage "Benutzersteuerelement" ist unter http://go.microsoft.com/fwlink/?LinkId=234236 dokumentiert.

namespace Catrobat.Paint.WindowsPhone.Controls.UserControls
{
    public sealed partial class RectangleSelectionControl : UserControl
    {
        public RectangleShapeBaseControl RectangleShapeBase { get; private set; }
        public Rectangle RectangleToDraw { get; private set; }

        public PenLineJoin StrokeLineJoinOfRectangleToDraw
        {
            get { return RectangleToDraw.StrokeLineJoin; }
            set { RectangleToDraw.StrokeLineJoin = value; }
        }

        public double StrokeThicknessOfRectangleToDraw
        {
            get { return RectangleToDraw.StrokeThickness; }
            set { RectangleToDraw.StrokeThickness = value; }
        }

        public Brush FillOfRectangleToDraw
        {
            get { return RectangleToDraw.Fill; }
            set { RectangleToDraw.Fill = value; }
        }

        public Brush StrokeOfRectangleToDraw
        {
            get { return RectangleToDraw.Stroke; }
            set { RectangleToDraw.Stroke = value; }
        }

        public RectangleSelectionControl()
        {
            this.InitializeComponent();

            RectangleShapeBase = RectangleShapeBaseControl;

            for (int i = 0; i < RectangleShapeBaseControl.AreaToDraw.Children.Count; i++)
            {
                if (! (RectangleShapeBaseControl.AreaToDraw.Children[i] is Rectangle))
                {
                    RectangleShapeBaseControl.AreaToDraw.Children.RemoveAt(i);
                    i--;
                }
                else
                {
                    RectangleToDraw = (Rectangle) RectangleShapeBaseControl.AreaToDraw.Children[i];
                    RectangleToDraw.Visibility = Visibility.Visible;
                }
            }
            
            Debug.Assert(RectangleToDraw != null);
        }

        public void ResetRectangleSelectionControl()
        {
            // TODO: evaluate if the outcommented code is maybe needed?
            //FillOfRectangleToDraw = PocketPaintApplication.GetInstance().PaintData.colorSelected;
            //StrokeOfRectangleToDraw = PocketPaintApplication.GetInstance().PaintData.strokeColorSelected;
            //StrokeThicknessOfRectangleToDraw = PocketPaintApplication.GetInstance().PaintData.strokeThickness;
            //StrokeLineJoinOfRectangleToDraw = PocketPaintApplication.GetInstance().PaintData.penLineJoinSelected;

            RectangleShapeBaseControl.ResetRectangleShapeBaseControl();
        }
    }
}
