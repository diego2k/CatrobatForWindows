﻿using Catrobat.Paint.WindowsPhone.Tool;
using System;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;


// Die Elementvorlage "Benutzersteuerelement" ist unter http://go.microsoft.com/fwlink/?LinkId=234236 dokumentiert.

namespace Catrobat.Paint.WindowsPhone.Controls.UserControls
{
    public sealed partial class InfoBoxControl : UserControl
    {
        public InfoBoxControl()
        {
            this.InitializeComponent();
        }

        private void setCursorControlLayout()
        {            
            double heightMultiplicator = PocketPaintApplication.GetInstance().size_width_multiplication;
            double widthMultiplicator = PocketPaintApplication.GetInstance().size_width_multiplication;

            GridMain.Width *= widthMultiplicator;
            GridMain.Height *= heightMultiplicator;

            foreach (Object obj in GridMain.Children)
            {
                if (obj.GetType() == typeof(Button))
                {
                    Button currentButton = (Button)obj;
                    currentButton.Height *= heightMultiplicator;
                    currentButton.Width *= widthMultiplicator;
                    Thickness currentButtonThickness = currentButton.BorderThickness;
                    currentButtonThickness.Bottom *= heightMultiplicator;
                    currentButtonThickness.Left *= heightMultiplicator;
                    currentButtonThickness.Right *= heightMultiplicator;
                    currentButtonThickness.Top *= heightMultiplicator;
                    currentButton.BorderThickness = currentButtonThickness;

                    //currentEllipse.Margin = new Thickness(
                    //                        currentEllipse.Margin.Left * widthMultiplicator,
                    //                        currentEllipse.Margin.Top * heightMultiplicator,
                    //                        currentEllipse.Margin.Right * widthMultiplicator,
                    //                        currentEllipse.Margin.Bottom * heightMultiplicator);
                }
                else if (obj.GetType() == typeof(TextBox))
                {
                    TextBox currentTextbox = (TextBox)obj;
                    currentTextbox.Height *= heightMultiplicator;
                    currentTextbox.Width *= widthMultiplicator;

                    //currentRectangle.Margin = new Thickness(
                    //                        currentRectangle.Margin.Left * widthMultiplicator,
                    //                        currentRectangle.Margin.Top * heightMultiplicator,
                    //                        currentRectangle.Margin.Right * widthMultiplicator,
                    //                        currentRectangle.Margin.Bottom * heightMultiplicator);
                }
            }
        }

        private void btnNewDrawingSpace_Click(object sender, RoutedEventArgs e)
        {
            if (PocketPaintApplication.GetInstance().PaintingAreaCanvas.Children.Count > 0)
            {
                PocketPaintApplication.GetInstance().PaintingAreaView.messageBoxNewDrawingSpace_Click("Neues Bild", false);
            }
            else
            {
                PocketPaintApplication.GetInstance().PaintingAreaView.resetTools();
            }

            //PocketPaintApplication.GetInstance().SwitchTool(ToolType.Brush);
            //PocketPaintApplication.GetInstance().PaintingAreaView.changeBackgroundColorAndOpacityOfPaintingAreaCanvas(Colors.Transparent, 1.0);
            //PocketPaintApplication.GetInstance().PaintingAreaView.resetControls(Visibility.Collapsed);
        }

        private void btnNewPictureFromCamera_Click(object sender, RoutedEventArgs e)
        {
            if (PocketPaintApplication.GetInstance().PaintingAreaCanvas.Children.Count > 0)
            {
                PocketPaintApplication.GetInstance().PaintingAreaView.messageBoxNewDrawingSpace_Click("Neues Bild von Kamera",false);
            } 
        }
    }
}