using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;  //Path类用到
using System.Media;  //SoundPlayer类所在的命名空间
using NAudio;
using NAudio.Wave;

namespace MyMusicPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> listSongs = new List<string>();//用来存储文件的全路径

        private void b_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择音乐文件"; //打开的对话框所显示的标题
            ofd.Multiselect = true;//设置多选
            ofd.InitialDirectory = "F:\\cheapw\\Music"; //设置打开对话框的初始目录
            ofd.Filter = "MP3音频文件|*.MP3|WAV音频文件|*.WAV|所有文件|*.*"; //设置文件格式帅选
            ofd.ShowDialog();//显示打开文件的对话框
            string[] pa_th = ofd.FileNames;//获得在文件夹中选择的所有文件的全路径
            FileInfo file01 = new FileInfo("D:\\Music01.wav");
            FileInfo file02 = new FileInfo("D:\\Music02.wav");
            FileInfo file03 = new FileInfo("D:\\Music03.wav");
            //for (int i = 0; i < pa_th.Length; i++)
            //{
            //    listBox1.Items.Add(Path.GetFileName(pa_th[i]));//将音乐文件夹的文件名加载到listBox中

            //    listSongs.Add(pa_th[i]); //将音乐文件的全路径存储到泛型集合中
            //}
            string[] wavfile = new string[3];
            wavfile[0] = file01.FullName;
            wavfile[1] = file02.FullName;
            wavfile[2] = file03.FullName;
            for (int i = 0; i < pa_th.Length; i++)
            {
                
                using (Mp3FileReader reader = new Mp3FileReader(pa_th[i]))
                {
                    using (WaveStream pcmStream = WaveFormatConversionStream.CreatePcmStream(reader))
                    {
                        WaveFileWriter.CreateWaveFile(wavfile[i], pcmStream);
                    }
                }
            }
            for (int i = 0; i < wavfile.Length; i++)
            {
                listBox1.Items.Add(Path.GetFileName(wavfile[i]));//将音乐文件夹的文件名加载到listBox中

                listSongs.Add(wavfile[i]); //将音乐文件的全路径存储到泛型集合中
            }
        }

        //实现双击播放
        SoundPlayer sp = new SoundPlayer();
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = listSongs[listBox1.SelectedIndex];
            sp.Play();
        }
        private void b_up_Click(object sender, EventArgs e)
        {

        }

        private void b_next_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
