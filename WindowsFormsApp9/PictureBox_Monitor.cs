using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApp9
{
    internal class PictureBox_Monitor : PictureBox
    {
        internal string ImagePath { get; set; }
        List<string> preFilePaths = new List<string>();
        List<string> newFilePaths = new List<string>();
        int nowIndex = 0;
        Timer timer = new Timer();

        internal PictureBox_Monitor()
        {
            this.BackColor = Color.Black; // 背景顏色
            this.Dock = DockStyle.Fill; // 滿版面
            this.SizeMode = PictureBoxSizeMode.Zoom;
            this.BackgroundImageLayout = ImageLayout.Zoom;

            timer.Tick += new EventHandler(Timer_Tick);
            Timer_Start();
        }

        private void DrawPicture()
        {
            Bitmap bitmapImage;

            if (this.Image != null) // 第一張沒有圖片
            {
                this.Image.Dispose();
            }

            bitmapImage = new Bitmap(preFilePaths[nowIndex]);
            this.Image = bitmapImage; // 畫圖片上去

            // 畫檔名
            //Graphics g;
            //g = Graphics.FromImage(bmp);
            //g.DrawString(Path.GetFileName(preFilePaths[nowIndex]), new Font("新細明體", 9), Brushes.Green, new Point(2, 2));
            //bmp.MakeTransparent();
            //this.Image = bmp;
            //g.Dispose();
        }

        internal void Detect()
        {
            if (Directory.Exists(ImagePath))
            {
                newFilePaths = Directory.GetFiles(ImagePath, "*.*", SearchOption.AllDirectories).ToList(); // 抓資料夾內，所以檔案的路徑

                newFilePaths.Sort(); // 照日期排列
            }
            else
            {
                //Console.WriteLine("ImagePath doesn't exist.");
                throw (new Exception("ImagePath doesn't exist."));
            }
        }

        // Timer
        #region timer
        internal void Timer_Start()
        {
            timer.Start();
        }

        internal void Timer_Stop()
        {
            timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                Detect(); // 監視資料夾

                if (preFilePaths.SequenceEqual(newFilePaths)) // 如果沒有新增檔案
                {
                    return;
                }
                else
                {
                    //if(preFilePaths.Count)
                    preFilePaths = newFilePaths; // 更新檔案路徑
                    nowIndex = preFilePaths.Count - 1; // 儲存現在的索引值

                    // 顯示最新的圖片
                    DrawPicture();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion
    }
}
