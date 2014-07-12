﻿using Windows.UI.Xaml;
using Catrobat.IDE.Core;
using Catrobat.IDE.Core.Models;
using Catrobat.IDE.Core.Resources.Localization;
using Catrobat.IDE.Core.Services;
using Catrobat.IDE.Core.Services.Common;
using Catrobat.IDE.Core.UI;
using Catrobat.IDE.Core.ViewModels;
using Catrobat.IDE.WindowsShared.Services;
using Catrobat.IDE.WindowsShared.Services.Storage;
using GalaSoft.MvvmLight.Messaging;
using ViewModelBase = GalaSoft.MvvmLight.ViewModelBase;

namespace Catrobat.IDE.WindowsShared
{
    public class AppWindowsShared : INativeApp
    {
        public AppWindowsShared()
        {
            InitializeInterfaces();
        }

        public void InitializeInterfaces()
        {
            if(ViewModelBase.IsInDesignModeStatic)
                ServiceLocator.Register(new DispatcherServiceStore(null));

            ServiceLocator.Register<NavigationServiceStore>(TypeCreationMode.Lazy);
            ServiceLocator.Register<SystemInformationServiceStore>(TypeCreationMode.Lazy);
            ServiceLocator.Register<CultureServiceStore>(TypeCreationMode.Lazy);
            ServiceLocator.Register<ImageResizeServiceStore>(TypeCreationMode.Lazy);
            ServiceLocator.Register<PlayerLauncherServiceStore>(TypeCreationMode.Lazy);
            ServiceLocator.Register<ResourceLoaderFactoryStore>(TypeCreationMode.Lazy);
            ServiceLocator.Register<StorageFactoryStore>(TypeCreationMode.Lazy);
            ServiceLocator.Register<ImageSourceConversionServiceStore>(TypeCreationMode.Lazy);
            ServiceLocator.Register<ProjectImporterServiceStore>(TypeCreationMode.Lazy);
            ServiceLocator.Register<SoundPlayerServiceStore>(TypeCreationMode.Lazy);
            ServiceLocator.Register<SoundRecorderServiceStore>(TypeCreationMode.Lazy);
            ServiceLocator.Register<PictureServiceStore>(TypeCreationMode.Lazy);
            ServiceLocator.Register<NotificationServiceStore>(TypeCreationMode.Lazy);
            ServiceLocator.Register<ColorConversionServiceStore>(TypeCreationMode.Lazy);
            ServiceLocator.Register<ShareServiceStore>(TypeCreationMode.Lazy);
            ServiceLocator.Register<PortableUIElementsConvertionServiceStore>(TypeCreationMode.Lazy);
            ServiceLocator.Register<SoundServiceStore>(TypeCreationMode.Lazy);

            ServiceLocator.ViewModelLocator = new ViewModelLocator();
            ServiceLocator.ViewModelLocator.RegisterViewModels();

            ServiceLocator.ThemeChooser = new ThemeChooser();
            ServiceLocator.LocalizedStrings = new LocalizedStrings();

            Application.Current.Resources["Locator"] = ServiceLocator.ViewModelLocator;
            Application.Current.Resources["ThemeChooser"] = ServiceLocator.ThemeChooser;
            Application.Current.Resources["LocalizedStrings"] = ServiceLocator.LocalizedStrings;
 

            if (!ViewModelBase.IsInDesignModeStatic)
                InitPresenters();

            if (ViewModelBase.IsInDesignModeStatic)
            {
                var task = new ProjectGeneratorWhackAMole().GenerateProject("de", false);
                task.Wait();

                var defaultProject = task.Result;
                var projectChangedMessage = new GenericMessage<Project>(defaultProject);
                Messenger.Default.Send(projectChangedMessage, ViewModelMessagingToken.CurrentProjectChangedListener);
            }
        }

        private void InitPresenters()
        {
            //var spritesViewModel = ServiceLocator.GetInstance<SpritesViewModel>();
            //spritesViewModel.PresenterType = typeof(SpritesPresenter);

            //var spriteEditorViewModel = ServiceLocator.GetInstance<SpriteEditorViewModel>();
            //spriteEditorViewModel.PresenterType = typeof(SpritesPresenter);

            //var costumeSavingViewModel = ServiceLocator.GetInstance<CostumeSavingViewModel>();
            //costumeSavingViewModel.PresenterType = typeof(SpritesPresenter);
        }
    }
}