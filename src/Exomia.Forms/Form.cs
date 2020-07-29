#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Exomia.Forms.Properties;
using FontAwesome.Sharp;

namespace Exomia.Forms
{
    /// <summary>
    ///     A form.
    /// </summary>
    /// <content>
    ///     A form.
    /// </content>
    public partial class Form : System.Windows.Forms.Form
    {
        private readonly Sidebar _sidebar;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Form" /> class.
        /// </summary>
        public Form()
        {
            InitializeComponent();
            panelSidebarContainer.Controls.Add(
                _sidebar = new Sidebar
                {
                    Dock = DockStyle.Fill, BackColor = panelSideLeft.BackColor
                });
            SetIcon(Resources.icon, true);
        }

        /// <summary>
        ///     Sets an icon.
        /// </summary>
        /// <param name="icon">         The icon. </param>
        /// <param name="invertColors"> (Optional) True to invert colors. </param>
        public void SetIcon(Bitmap icon, bool invertColors = false)
        {
            for (int y = 0; y <= icon.Height - 1; y++)
            {
                for (int x = 0; x <= icon.Width - 1; x++)
                {
                    Color inv = icon.GetPixel(x, y);
                    inv = Color.FromArgb(inv.A, 255 - inv.R, 255 - inv.G, 255 - inv.B);
                    icon.SetPixel(x, y, inv);
                }
            }
            pictureBoxIcon.Image = icon;
        }

        /// <summary>
        ///     Adds a sidebar button.
        /// </summary>
        /// <param name="buttonOptions"> Options for controlling the sidebar button. </param>
        public void AddSidebarButton(Sidebar.ButtonOptions buttonOptions)
        {
            Sidebar.Button btn = _sidebar.InternalAdd(buttonOptions);
            if (buttonOptions.Click != null)
            {
                btn.Click += buttonOptions.Click;
            }
        }

        /// <summary>
        ///     Adds sidebar menu.
        /// </summary>
        /// <param name="menuOptions">   Options for controlling the sidebar menu. </param>
        /// <param name="submenuButtonOptions"> Options for controlling the submenu buttons. </param>
        public void AddSidebarMenu(Sidebar.MenuOptions            menuOptions,
                                   params Sidebar.ButtonOptions[] submenuButtonOptions)
        {
            Sidebar.Button menuBtn = _sidebar.InternalAdd(menuOptions);

            Sidebar menu = new Sidebar
            {
                Text      = menuOptions.Text,
                ForeColor = menuOptions.DefaultColor,
                Height    = submenuButtonOptions.Sum(s => s.IconSize + (s.IconSize / 2)) + 10,
                Dock      = DockStyle.Top,
                Padding   = new Padding(5, 5, 0, 0),
                BackColor = Color.FromArgb(21, 27, 37),
                Visible   = false
            };
            
            _sidebar.ItemClicked += (sender, args) =>
            {
                if (menuBtn == sender)
                {
                    menu.Visible = !menu.Visible;
                }
                else
                {
                    menu.Visible = false;
                    menu.Reset();
                }
            };

            _sidebar.Controls.Add(menu);
            _sidebar.Controls.SetChildIndex(menu, 0);
            foreach (Sidebar.ButtonOptions option in submenuButtonOptions)
            {
                Sidebar.Button btn = menu.InternalAdd(option);
                if (option.Click != null)
                {
                    btn.Click += option.Click;
                }
            }
        }

        private void pictureBoxIcon_Click(object sender, EventArgs e)
        {
            _sidebar.Reset();
        }
    }

    /// <summary>
    ///     A sidebar. This class cannot be inherited.
    /// </summary>
    public sealed class Sidebar : Panel
    {
        /// <summary>
        ///     The item clicked event.
        /// </summary>
        public event EventHandler? ItemClicked;

        private readonly Panel   _leftBorderBtn;
        private          Button? _currentBtn;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Sidebar" /> class.
        /// </summary>
        public Sidebar()
        {
            _leftBorderBtn = new Panel { Size = new Size(7, 0) };
            Controls.Add(_leftBorderBtn);
            AutoScroll = true;
        }

        /// <summary>
        ///     Resets this object.
        /// </summary>
        public void Reset()
        {
            DisableButton();
            _leftBorderBtn.Visible = false;

            ItemClicked?.Invoke(this, EventArgs.Empty);
        }

        internal Button InternalAdd(Options options)
        {
            Button btn = new Button
            {
                IconChar                = options.IconChar,
                Text                    = options.Text,
                IconColor               = options.DefaultColor,
                ForeColor               = options.DefaultColor,
                DefaultColor            = options.DefaultColor,
                HighlightColor          = options.HighlightColor,
                Height                  = options.IconSize + (options.IconSize / 2),
                FlatAppearance          = { BorderSize = 0 },
                FlatStyle               = FlatStyle.Flat,
                IconSize                = options.IconSize,
                Dock                    = DockStyle.Top,
                ImageAlign              = ContentAlignment.MiddleLeft,
                TextAlign               = ContentAlignment.MiddleLeft,
                TextImageRelation       = TextImageRelation.ImageBeforeText,
                Padding                 = new Padding(10, 0, 20, 0),
                Font                    = new Font("Century Gothic", 10, FontStyle.Bold),
                UseVisualStyleBackColor = true,
                Cursor                  = Cursors.Hand
            };

            btn.Click += (sender, e) =>
            {
                ItemClicked?.Invoke(btn, EventArgs.Empty);
                ActivateButton(sender);
            };

            Controls.Add(btn);
            Controls.SetChildIndex(btn, 0);

            return btn;
        }

        private void ActivateButton(object? sender)
        {
            if (sender != null && sender is Button btn)
            {
                DisableButton();

                _currentBtn           = btn;
                _currentBtn.BackColor = Color.FromArgb(21, 27, 27);
                _leftBorderBtn.BackColor = _currentBtn.IconColor =
                    _currentBtn.ForeColor = _currentBtn.HighlightColor;

                _leftBorderBtn.Location = new Point(_currentBtn.Location.X, _currentBtn.Location.Y);
                _leftBorderBtn.Size     = new Size(3, _currentBtn.Height);
                _leftBorderBtn.Visible  = true;

                _leftBorderBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (_currentBtn != null)
            {
                _currentBtn.BackColor = BackColor;
                _leftBorderBtn.BackColor = _currentBtn.IconColor =
                    _currentBtn.ForeColor = _currentBtn.DefaultColor;
            }
        }

        /// <summary>
        ///     An options.
        /// </summary>
        public abstract class Options
        {
            /// <summary>
            ///     Gets or sets the icon character.
            /// </summary>
            /// <value>
            ///     The icon character.
            /// </value>
            public IconChar IconChar { get; set; }

            /// <summary>
            ///     Gets or sets the text.
            /// </summary>
            /// <value>
            ///     The text.
            /// </value>
            public string? Text { get; set; }

            /// <summary>
            ///     Gets or sets the icon size.
            /// </summary>
            /// <value>
            ///     The size of the icon.
            /// </value>
            public int IconSize { get; set; }

            /// <summary>
            ///     Gets or sets the color.
            /// </summary>
            /// <value>
            ///     The color.
            /// </value>
            public Color DefaultColor { get; set; } = Color.Gainsboro;

            /// <summary>
            ///     Gets or sets the color of the highlight.
            /// </summary>
            /// <value>
            ///     The color of the highlight.
            /// </value>
            public Color HighlightColor { get; set; } = Color.DarkOrange;

            /// <summary>
            ///     Initializes a new instance of the <see cref="Options" /> class.
            /// </summary>
            private protected Options() { }
        }

        /// <summary>
        ///     A sidebar menu options. This class cannot be inherited.
        /// </summary>
        public sealed class MenuOptions : Options { }

        /// <summary>
        ///     A sidebar button options. This class cannot be inherited.
        /// </summary>
        public sealed class ButtonOptions : Options
        {
            /// <summary>
            ///     Gets or sets the click event.
            /// </summary>
            /// <value>
            ///     The click.
            /// </value>
            public EventHandler? Click { get; set; }
        }

        /// <summary>
        ///     A sidebar button. This class cannot be inherited.
        /// </summary>
        public sealed class Button : IconButton
        {
            /// <summary>
            ///     Gets or sets the color.
            /// </summary>
            /// <value>
            ///     The color.
            /// </value>
            public Color DefaultColor { get; set; }

            /// <summary>
            ///     Gets or sets the color.
            /// </summary>
            /// <value>
            ///     The color.
            /// </value>
            public Color HighlightColor { get; set; }
        }
    }
}