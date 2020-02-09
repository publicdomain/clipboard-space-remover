// <copyright file="MainForm.cs" company="PublicDomain.com">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

namespace ClipboardSpaceRemover
{
    // Directives
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The clipboard update windows message.
        /// </summary>
        private const int WmClipboardUpdate = 0x031D;

        /// <summary>
        /// The assembly version.
        /// </summary>
        private Version assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;

        /// <summary>
        /// The semantic version.
        /// </summary>
        private string semanticVersion = string.Empty;

        /// <summary>
        /// The associated icon.
        /// </summary>
        private Icon associatedIcon = null;

        /// <summary>
        /// The friendly name of the program.
        /// </summary>
        private string friendlyName = "Clipboard Space Remover";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ClipboardSpaceRemover.MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();

            // Add clipboard listener
            AddClipboardFormatListener(this.Handle);
        }

        /// <summary>
        /// The Window procedure.
        /// </summary>
        /// <param name="m">The message.</param>
        protected override void WndProc(ref Message m)
        {
            // Test incoming message
            switch (m.Msg)
            {
                // Check for clipboard update
                case WmClipboardUpdate:

                    // Check for copied text which contains spaces
                    if (Clipboard.ContainsText() && Clipboard.GetText().Contains(" "))
                    {
                        // Remove all blank spaces
                        Clipboard.SetText(Clipboard.GetText().Replace(" ", string.Empty));
                    }

                    // Halt flow
                    break;

                // Continue processing
                default:

                    // Pass message for 
                    base.WndProc(ref m);

                    // Halt flow
                    break;
            }
        }

        /// <summary>
        /// Adds the clipboard format listener.
        /// </summary>
        /// <returns><c>true</c>, if clipboard format listener was added, <c>false</c> otherwise.</returns>
        /// <param name="hwnd">The handle.</param>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AddClipboardFormatListener(IntPtr hwnd);

        /// <summary>
        /// Handles the always on top tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAlwaysOnTopToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Toggle checked
            this.alwaysOnTopToolStripMenuItem.Checked = !this.alwaysOnTopToolStripMenuItem.Checked;

            // Toggle topmost
            this.TopMost = this.alwaysOnTopToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the pause resume button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnPauseResumeButtonClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the headquarters patreoncom tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnHeadquartersPatreoncomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open Patreon headquarters
            Process.Start("https://www.patreon.com/publicdomain");
        }

        /// <summary>
        /// Handles the source code githubcom tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSourceCodeGithubcomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open GitHub
            Process.Start("https://github.com/publicdomain");
        }

        /// <summary>
        /// Handles the original thread redditcom tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOriginalThreadRedditcomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open original thread @ Reddit
            Process.Start("https://www.reddit.com/r/software/comments/ewlypv/copypaste_on_windows_that_leaves_out_spaces/");
        }

        /// <summary>
        /// Handles the new tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnNewToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the exit tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Close program
            this.Close();
        }

        /// <summary>
        /// Handles the main form form closing event event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnMainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            // TODO Add code
        }
    }
}
