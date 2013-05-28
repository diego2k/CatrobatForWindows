﻿using System.IO.IsolatedStorage;
using Catrobat.Core;
using Catrobat.Core.Storage;
using Catrobat.IDEWindowsPhone.Misc.Storage;

namespace Catrobat.TestsWindowsPhone.Misc
{
  public static class TestHelper
  {
    public static void InitializeAndClearCatrobatContext()
    {
      InitializeTests();

      using (var storage = StorageSystem.GetStorage())
      {
        storage.DeleteDirectory("");
      }

      CatrobatContext.GetContext().CurrentProject = null;
    }

    public static void DeleteFolder(this IsolatedStorageFile iso, string path)
    {
      if (!iso.DirectoryExists(path))
        return;
      var folders = iso.GetDirectoryNames(path + "/" + "*.*");

      foreach (var folder in folders)
      {
        string folderName = path + "/" + folder;
        DeleteFolder(iso, folderName);
      }

      foreach (var file in iso.GetFileNames(path + "/" + "*.*"))
      {
        iso.DeleteFile(path + "/" + file);
      }

      if (path != "")
        iso.DeleteDirectory(path);
    }

    internal static void InitializeTests()
    {
      StorageSystem.SetStorageFactory(new StorageFactoryPhone());
      ResourceLoader.SetResourceLoaderFactory(new ResourceLoaderFactoryPhone());
    }
  }
}
