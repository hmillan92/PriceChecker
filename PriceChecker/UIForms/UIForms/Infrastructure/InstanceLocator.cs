﻿using System;
using System.Collections.Generic;
using System.Text;
using UIForms.ViewModels;

namespace UIForms.Infrastructure
{
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}
