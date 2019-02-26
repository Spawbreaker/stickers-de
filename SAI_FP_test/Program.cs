using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StickerDE
{
    static class Program
    {
        /// <summary>
        /// Entry point for the application
        /// 
        /// This program is a C# Desktop application that applies an Evolutionary Algorithm (Differential Evolution)
        /// to a problem where we want to put as many stickers as possible in a single sheet with as little blank space
        /// in between eachother. 
        /// 
        /// The program was done in the time period of two months for an Evolutionary Algorithms class in the 
        /// University of Guadalajara during the first semester of 2018, and went through three main iterations
        /// where the memory usage, fitness function and overall scope of the application where modified to this product. 
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Global.StyleManager = new MetroFramework.Components.MetroStyleManager();
            Global.StyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            Global.StyleManager.Style = MetroFramework.MetroColorStyle.Magenta; 
            Application.Run(new MainForm());
        }
    }
}
