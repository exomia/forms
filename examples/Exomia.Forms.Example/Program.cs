#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Exomia.Forms.Example
{
    static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form f = new Form();
            f.AddSidebarButton(
                new Sidebar.ButtonOptions
                {
                    IconChar = IconChar.Amazon, Text = "Test1", IconSize = 32, HighlightColor = Color.DarkMagenta
                });
            f.AddSidebarButton(
                new Sidebar.ButtonOptions
                {
                    IconChar = IconChar.Safari, Text = "Test2", IconSize = 32, HighlightColor = Color.DeepPink
                });
            f.AddSidebarButton(
                new Sidebar.ButtonOptions
                {
                    IconChar = IconChar.Bitcoin, Text = "Test3", IconSize = 32, HighlightColor = Color.Yellow
                });

            f.AddSidebarMenu(
                new Sidebar.MenuOptions
                {
                    IconChar = IconChar.Bitcoin, Text = "submenu", IconSize = 32, HighlightColor = Color.Blue
                },
                new Sidebar.ButtonOptions
                {
                    IconChar = IconChar.Amazon, Text = "Test1", IconSize = 24, HighlightColor = Color.Blue
                },
                new Sidebar.ButtonOptions
                {
                    IconChar = IconChar.Amazon, Text = "Test2", IconSize = 24, HighlightColor = Color.Blue
                },
                new Sidebar.ButtonOptions
                {
                    IconChar = IconChar.Amazon, Text = "Test3", IconSize = 24, HighlightColor = Color.Blue
                });
            f.AddSidebarMenu(
                new Sidebar.MenuOptions { IconChar   = IconChar.Bitcoin, Text = "submenu", IconSize = 32 },
                new Sidebar.ButtonOptions { IconChar = IconChar.Amazon, Text  = "Test1", IconSize   = 24 },
                new Sidebar.ButtonOptions { IconChar = IconChar.Amazon, Text  = "Test2", IconSize   = 24 },
                new Sidebar.ButtonOptions { IconChar = IconChar.Amazon, Text  = "Test3", IconSize   = 24 });

            Application.Run(f);
        }
    }
}