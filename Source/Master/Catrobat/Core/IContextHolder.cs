﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catrobat.Core
{
  public interface IContextHolder
  {
    CatrobatContext GetContext();
  }
}
