﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catrobat.Core.Storage
{
  public interface IResourceLoaderFactory
  {
    IResources CreateResoucreLoader();
  }
}