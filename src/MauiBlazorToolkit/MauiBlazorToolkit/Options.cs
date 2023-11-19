﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorToolkit
{
    public class Options
    {
        internal static bool InternalWebViewSoftInput { get; private set; }

        internal static bool InternalTitleBar { get; private set; }

        public bool WebViewSoftInputPatch
        {
            get => InternalWebViewSoftInput; 
            set => InternalWebViewSoftInput = value;
        }

        public bool TitleBar
        {
            get => InternalTitleBar;
            set => InternalTitleBar = value;
        }
    }
}
