using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Basics
{
    public partial class frmCoolForm : XCoolForm.XCoolForm
    {
        private XmlThemeLoader xtl = new XmlThemeLoader();
        public frmCoolForm() : base()
        {
            InitializeComponent();

            //this.TitleBar.TitleBarBackImage = TaskDesigner.Properties.Resources.predator_256x256;
            //this.MenuIcon = TaskDesigner.Properties.Resources.alien_vs_predator_3_48x48.GetThumbnailImage(24, 24, null, IntPtr.Zero);

            //this.IconHolder.HolderButtons.Add(new XCoolForm.XTitleBarIconHolder.XHolderButton(TaskDesigner.Properties.Resources.disc_predator_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero), "Blue Winter"));
            //this.IconHolder.HolderButtons.Add(new XCoolForm.XTitleBarIconHolder.XHolderButton(TaskDesigner.Properties.Resources.alien_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero), "Dark System"));
            //this.IconHolder.HolderButtons.Add(new XCoolForm.XTitleBarIconHolder.XHolderButton(TaskDesigner.Properties.Resources.alien_egg_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero), "Animal Kingdom"));
            //this.IconHolder.HolderButtons.Add(new XCoolForm.XTitleBarIconHolder.XHolderButton(TaskDesigner.Properties.Resources.predator_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero), "Valentine"));


            //this.IconHolder.HolderButtons[0].FrameBackImage = TaskDesigner.Properties.Resources.disc_predator_48x48;
            //this.IconHolder.HolderButtons[1].FrameBackImage = TaskDesigner.Properties.Resources.alien_48x48;
            //this.IconHolder.HolderButtons[2].FrameBackImage = TaskDesigner.Properties.Resources.alien_egg_48x48;
            //this.IconHolder.HolderButtons[3].FrameBackImage = TaskDesigner.Properties.Resources.predator_48x48;

            //this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(60));
            //this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(200, "INS"));
            //this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(80, "Done"));
            //this.StatusBar.EllipticalGlow = false;

            //this.Border.BorderStyle = XCoolForm.X3DBorderPrimitive.XBorderStyle.Flat;
            //this.TitleBar.TitleBarBackImage = TaskDesigner.Properties.Resources.Mammooth_1;
            //this.TitleBar.TitleBarCaption = "Animal Kingdom Theme";

            //this.TitleBar.TitleBarButtons[2].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.None;
            //this.TitleBar.TitleBarButtons[1].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.None;
            //this.TitleBar.TitleBarButtons[0].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.None;

            //this.TitleBar.TitleBarType = XCoolForm.XTitleBar.XTitleBarType.Angular;
            //this.MenuIcon = TaskDesigner.Properties.Resources.Mammooth_128x128.GetThumbnailImage(30, 30, null, IntPtr.Zero);
            //this.StatusBar.EllipticalGlow = false;

            //this.TitleBar.TitleBarFill = XCoolForm.XTitleBar.XTitleBarFill.UpperGlow;

            //this.StatusBar.BarBackImage = TaskDesigner.Properties.Resources.Funshine_Bear_1;
            //this.StatusBar.BarImageAlign = XCoolForm.XStatusBar.XStatusBarBackImageAlign.Left;

            //this.StatusBar.BarItems[1].BarItemText = "Place: Madagascar";
            //this.StatusBar.BarItems[1].ItemTextAlign = StringAlignment.Center;

            //this.IconHolder.HolderButtons[0].ButtonImage = TaskDesigner.Properties.Resources.cow_32.GetThumbnailImage(20, 20, null, IntPtr.Zero);
            //this.IconHolder.HolderButtons[1].ButtonImage = TaskDesigner.Properties.Resources.bird_32.GetThumbnailImage(20, 20, null, IntPtr.Zero);
            //this.IconHolder.HolderButtons[2].ButtonImage = TaskDesigner.Properties.Resources.panda_32.GetThumbnailImage(20, 20, null, IntPtr.Zero);
            //this.IconHolder.HolderButtons[3].ButtonImage = TaskDesigner.Properties.Resources.penguine_32.GetThumbnailImage(20, 20, null, IntPtr.Zero);

            //this.IconHolder.HolderButtons[0].FrameBackImage = TaskDesigner.Properties.Resources.cow_32;
            //this.IconHolder.HolderButtons[1].FrameBackImage = TaskDesigner.Properties.Resources.bird_32;
            //this.IconHolder.HolderButtons[2].FrameBackImage = TaskDesigner.Properties.Resources.panda_32;
            //this.IconHolder.HolderButtons[3].FrameBackImage = TaskDesigner.Properties.Resources.penguine_32;
            //xtl.ApplyTheme(Path.Combine(Environment.CurrentDirectory, @"..\..\Themes\AnimalKingdomTheme.xml"));
            //xtl.ThemeForm = this;
        }

        private void frmCoolForm_Load(object sender, EventArgs e)
        {

            this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(60));
            this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(200, "INS"));
            this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(80, "Done"));
            this.StatusBar.EllipticalGlow = false;

            this.XCoolFormHolderButtonClick += new XCoolFormHolderButtonClickHandler(frmCoolForm_XCoolFormHolderButtonClick);
            xtl.ThemeForm = this;

        }


        private void frmCoolForm_XCoolFormHolderButtonClick(XCoolForm.XCoolForm.XCoolFormHolderButtonClickArgs e)
        {
            switch (e.ButtonIndex)
            {
                case 0:

                    break;
                case 1:

                    break;
                case 2:

                    break;
                case 3:
                    break;
            }

        }
    }
}