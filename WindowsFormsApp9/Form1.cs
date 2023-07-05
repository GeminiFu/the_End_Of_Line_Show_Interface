using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        Panel[] showPanels = new Panel[8];
        PictureBox_Monitor[] pictureBoxes = new PictureBox_Monitor[8];
        string[] directoryPaths = new string[8];
        const int A_LEFT = 0;
        const int A_RIGHT = 1;
        const int B_TOP = 2;
        const int B_BOTTOM = 3;
        const int B_LEFT = 4;
        const int B_RIGHT = 5;
        const int C_LEFT = 6;
        const int C_RIGHT = 7;


        public Form1()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel_Title_Bar.Select(); // 消除掉 SplitContainer 的虛線

            // 取消 SplitContainer 的 Resize 功能
            splitContainer1.IsSplitterFixed = true;
            splitContainer2.IsSplitterFixed = true;
            splitContainer3.IsSplitterFixed = true;
            splitContainer_A.IsSplitterFixed = true;
            splitContainer_C.IsSplitterFixed = true;
            splitContainer_B_1.IsSplitterFixed = true;
            splitContainer_B_2.IsSplitterFixed = true;
            splitContainer_B_3.IsSplitterFixed = true;

            // 均分 splitContainer
            splitContainer_A.SplitterDistance = splitContainer_A.Width / 2; // A
            splitContainer_B_1.SplitterDistance = splitContainer_B_1.Height / 4; // B-1
            splitContainer_B_2.SplitterDistance = splitContainer_B_2.Height / 3; // B-2
            splitContainer_B_3.SplitterDistance = splitContainer_B_3.Height / 2; // B-3
            splitContainer_C.SplitterDistance = splitContainer_C.Width / 2; // C

            // 監測資料夾
            directoryPaths[0] = @"C:\Users\A2I\Desktop\州巧\電腦A\左";
            directoryPaths[1] = @"C:\Users\A2I\Desktop\州巧\電腦A\右";
            directoryPaths[2] = @"C:\Users\A2I\Desktop\州巧\電腦B\上";
            directoryPaths[3] = @"C:\Users\A2I\Desktop\州巧\電腦B\下";
            directoryPaths[4] = @"C:\Users\A2I\Desktop\州巧\電腦B\左";
            directoryPaths[5] = @"C:\Users\A2I\Desktop\州巧\電腦B\右";
            directoryPaths[6] = @"C:\Users\A2I\Desktop\州巧\電腦C\左";
            directoryPaths[7] = @"C:\Users\A2I\Desktop\州巧\電腦C\右";

            // 顯示 Panel ，專門容納 PictureBox
            showPanels[0] = panel_A_Left_Show;
            showPanels[1] = panel_A_Right_Show;
            showPanels[2] = panel_B_Up_Show;
            showPanels[3] = panel_B_Down_Show;
            showPanels[4] = panel_B_Left_Show;
            showPanels[5] = panel_B_Right_Show;
            showPanels[6] = panel_C_Left_Show;
            showPanels[7] = panel_C_Right_Show;


            // 新增監視
            for(int i = 0; i < showPanels.Count(); i++)
            {
                PictureBox_Monitor pictureBox_Monitor = new PictureBox_Monitor();
                pictureBox_Monitor.ImagePath = directoryPaths[i]; // 儲存資料夾路徑

                showPanels[i].Controls.Add(pictureBox_Monitor); // 在 panel_Show 加入 pictureBox_Monitor
                pictureBoxes[i] = pictureBox_Monitor;
            }
        }
    }
}
