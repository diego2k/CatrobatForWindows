﻿using Catrobat.Paint.WindowsPhone.Command;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Catrobat.Paint.WindowsPhone.Tool
{
    class RotateTool : ToolBase
    {
        TransformGroup _rotationTransformGroup = null;

        public RotateTool()
        {
            this.ToolType = ToolType.Rotate;
            if (PocketPaintApplication.GetInstance().GridWorkingSpace.RenderTransform.GetType() == typeof(TransformGroup))
            {
                _rotationTransformGroup = PocketPaintApplication.GetInstance().GridWorkingSpace.RenderTransform as TransformGroup;
            }
            if (_rotationTransformGroup == null)
            {
                PocketPaintApplication.GetInstance().GridWorkingSpace.RenderTransform = _rotationTransformGroup = new TransformGroup();
            }
        }

        public override void HandleDown(object arg)
        {
           
        }

        public override void HandleMove(object arg)
        {
            
        }

        public override void HandleUp(object arg)
        {
          

        }

        public override void Draw(object o)
        {
            
        }

        public override void ResetDrawingSpace()
        {
            var rotateTransform = new RotateTransform();
            PocketPaintApplication.GetInstance().angularDegreeOfWorkingSpaceRotation = 0;

            rotateTransform.Angle = PocketPaintApplication.GetInstance().angularDegreeOfWorkingSpaceRotation;
            rotateTransform.CenterX = (PocketPaintApplication.GetInstance().GridWorkingSpace.Width) / 2;
            rotateTransform.CenterY = ((PocketPaintApplication.GetInstance().GridWorkingSpace.Height) / 2);
            addTransformsToRotationTransformGroup(rotateTransform, 0, PocketPaintApplication.GetInstance().PaintingAreaView.getRotationCounter()*(-1));
            PocketPaintApplication.GetInstance().PaintingAreaView.enableResetButtonRotate(PocketPaintApplication.GetInstance().PaintingAreaView.getRotationCounter() * (-1));
        }

        public void proofBoundariesOfAngle(int angleValue)
        {
            PocketPaintApplication.GetInstance().angularDegreeOfWorkingSpaceRotation += angleValue;

            if (PocketPaintApplication.GetInstance().angularDegreeOfWorkingSpaceRotation == 360)
            {
                PocketPaintApplication.GetInstance().angularDegreeOfWorkingSpaceRotation = 0;
            }
            else if (PocketPaintApplication.GetInstance().angularDegreeOfWorkingSpaceRotation == -90)
            {
                PocketPaintApplication.GetInstance().angularDegreeOfWorkingSpaceRotation = 270;
            }
        }

        public void createRotationTransformAndAddedItToTransformGroup(int angleRotation, int rotationDirection)
        {
            var rotateTransform = new RotateTransform();
            rotateTransform.Angle = PocketPaintApplication.GetInstance().angularDegreeOfWorkingSpaceRotation;
            rotateTransform.CenterX = (PocketPaintApplication.GetInstance().GridWorkingSpace.ActualWidth) / 2;
            rotateTransform.CenterY = ((PocketPaintApplication.GetInstance().GridWorkingSpace.ActualHeight) / 2);

            addTransformsToRotationTransformGroup(rotateTransform, angleRotation, rotationDirection);
            PocketPaintApplication.GetInstance().GridWorkingSpace.UpdateLayout();
            PocketPaintApplication.GetInstance().GridWorkingSpace.InvalidateArrange();
            PocketPaintApplication.GetInstance().GridWorkingSpace.InvalidateMeasure();
        }

        public void RotateLeft()
        {
            int angleToRotate = -90;
            proofBoundariesOfAngle(angleToRotate);
            createRotationTransformAndAddedItToTransformGroup(angleToRotate, -1);
        }

        public void RotateRight()
        {
            int angleToRotate = 90;
            proofBoundariesOfAngle(angleToRotate);
            createRotationTransformAndAddedItToTransformGroup(angleToRotate, 1);
        }
        public void RotateRight(int angleToRotate)
        {
            proofBoundariesOfAngle(angleToRotate);
            createRotationTransformAndAddedItToTransformGroup(angleToRotate, 1);
        }

        private void addTransformsToRotationTransformGroup(RotateTransform rotateTransform, int angle, int rotationDirection)
        {
            double DISPLAY_WIDTH_HALF = Window.Current.Bounds.Width / 2.0;
            double DISPLAY_HEIGHT_HALF = Window.Current.Bounds.Height / 2.0;

            TransformGroup rotationTransformGroupForCommand = new TransformGroup();
            _rotationTransformGroup.Children.Clear();
            _rotationTransformGroup.Children.Add(rotateTransform);
            rotationTransformGroupForCommand.Children.Add(rotateTransform);

            ScaleTransform scaleTransform = new ScaleTransform();
            scaleTransform.ScaleX = 0.75;
            scaleTransform.ScaleY = 0.75;
            scaleTransform.CenterX = DISPLAY_WIDTH_HALF;
            scaleTransform.CenterY = DISPLAY_HEIGHT_HALF;
            _rotationTransformGroup.Children.Add(scaleTransform);
            rotationTransformGroupForCommand.Children.Add(scaleTransform);

            if (PocketPaintApplication.GetInstance().angularDegreeOfWorkingSpaceRotation == 90 || PocketPaintApplication.GetInstance().angularDegreeOfWorkingSpaceRotation == 270)
            {
                scaleTransform = new ScaleTransform();
                scaleTransform.ScaleX = 0.75;
                scaleTransform.ScaleY = 0.75;
                scaleTransform.CenterX = DISPLAY_WIDTH_HALF;
                scaleTransform.CenterY = DISPLAY_HEIGHT_HALF;
                _rotationTransformGroup.Children.Add(scaleTransform);
                rotationTransformGroupForCommand.Children.Add(scaleTransform);
            }
            else
            {
                var toTranslateValue = new TranslateTransform();
                toTranslateValue.X = 0;
                toTranslateValue.Y -= 11.0;
                _rotationTransformGroup.Children.Add(toTranslateValue);
                rotationTransformGroupForCommand.Children.Add(toTranslateValue);
            }
            CommandManager.GetInstance().CommitCommand(new RotateCommand(rotationTransformGroupForCommand, PocketPaintApplication.GetInstance().angularDegreeOfWorkingSpaceRotation, rotationDirection));
        }
    }
}
