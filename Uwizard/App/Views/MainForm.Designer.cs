using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Uwizard.App.Models;

namespace Uwizard.App.Views
{
    partial class MainForm
    {
        #region Components
        private TabControl MainTabStrip;

        #endregion
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            var viewModel = (MainFormViewModel) ViewModel;

            //Definining
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
            MainTabStrip = new TabControl();
            MainTabStrip.SuspendLayout();
            SuspendLayout();

            viewModel.Views.Add(new WUDManagerViewModel());
            
            // 
            // MainTabStrip
            // 
            MainTabStrip.Dock = DockStyle.Fill;
            MainTabStrip.Location = new Point(0, 0);
            MainTabStrip.SelectedIndex = 0;
            MainTabStrip.Size = new Size(515, 521);
            MainTabStrip.TabIndex = 0;
            MainTabStrip.Controls.AddRange(viewModel.Views.Select(x=>x.View()).ToArray());

            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(515, 521);
            MinimumSize = new Size(523, 364);
            Controls.Add(MainTabStrip);
            Icon = (Icon) resources.GetObject("$this.Icon");
            Load += new System.EventHandler(MainFormLoading);
            FormClosing += new FormClosingEventHandler(MainFormClosing);
            Name = "MainForm";
            Text = "Uwizard";
            MainTabStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}