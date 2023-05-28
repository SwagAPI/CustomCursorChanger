using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CustomCursor
{
    public static class CursorChanger
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr LoadCursorFromFile(string lpFileName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetSystemCursor(IntPtr hcur, uint id);

        public const uint OCR_NORMAL = 32512;
        public const uint OCR_IBEAM = 32513;
        public const uint OCR_WAIT = 32514;
        public const uint OCR_LINK = 32649;

        public static bool ChangeSystemCursor(string cursorFilePath, uint cursorID)
        {
            IntPtr cursorHandle = LoadCursorFromFile(cursorFilePath);
            if (cursorHandle != IntPtr.Zero)
            {
                return SetSystemCursor(cursorHandle, cursorID);
            }

            return false;
        }
    }
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
            string cursorFilePath = "assets/Normal Select.ani";

            CursorChanger.ChangeSystemCursor(cursorFilePath,CursorChanger.OCR_NORMAL);
            CursorChanger.ChangeSystemCursor("assets/Text Select.cur", CursorChanger.OCR_IBEAM);
            CursorChanger.ChangeSystemCursor("assets/Busy.ani", CursorChanger.OCR_WAIT);
            CursorChanger.ChangeSystemCursor("assets/Link Select.ani", CursorChanger.OCR_LINK);
            this.Close();
        }
      
    }
}
