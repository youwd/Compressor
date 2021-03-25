using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Compressor
{
    public partial class Form1 : Form
    {
        string appPath = AppDomain.CurrentDomain.BaseDirectory;
        string resultCatalog;
        string logCatalog;
        Process p = new Process();
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 文件夹路径点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpenCatalog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                buttonOpenCatalog.Text = folder.SelectedPath;
                listBoxImage.Items.Clear();
                listBoxVideo.Items.Clear();
                fileAddress(folder.SelectedPath);
            }
        }

        /// <summary>
        /// 获取所有文件路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public void fileAddress(string path)
        {
            var files = Directory.GetFiles(path, ("*.*"), SearchOption.AllDirectories);

            resultCatalog = path + "--压缩结果";
            if (!Directory.Exists(resultCatalog))
            {
                Directory.CreateDirectory(resultCatalog);
            }
            var resultFiles = Directory.GetFiles(resultCatalog, ("*.*"), SearchOption.AllDirectories);
            for (int i = 0; i < resultFiles.Length; i++)
            {
                resultFiles[i] = resultFiles[i].Replace("--压缩结果", "");
            }

            logCatalog = buttonOpenCatalog.Text + "--压缩结果\\log\\";
            if (!Directory.Exists(logCatalog))
            {
                Directory.CreateDirectory(logCatalog);
            }

            foreach (var file in files)
            {
                if (((IList)resultFiles).Contains(file)) {
                    continue;
                }

                if (IsVideo(file))
                {
                    listBoxVideo.Items.Add(file);
                }
                else if (IsImage(file))
                {
                    listBoxImage.Items.Add(file);
                }
            }
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

        StreamWriter sw;
        private void start_Click(object sender, EventArgs e)
        {
            int count = listBoxVideo.Items.Count + listBoxImage.Items.Count;

            if (count == 0)
            {
                MessageBox.Show("请选择要压缩的文件夹！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            FileStream log = new FileStream(logCatalog + GetTimeStamp() + ".txt", FileMode.Create, FileAccess.Write);//创建写入文件 
            sw = new StreamWriter(log);

            sw.WriteLine(DateTime.Now + "开始压缩视频：");//开始写入值
            sw.Flush();
            progressBar1.Value = 0;
            progressBar1.Step = 100 / count;
            progressBar1.PerformStep();
            int videoSuccessCount = 0;
            int videoErrorCount = 0;

            foreach (var item in listBoxVideo.Items)
            {
                labelMessage.Text = "正在处理：" + item.ToString() + " ...";
                sw.WriteLine(DateTime.Now + "正在压缩视频：" + item.ToString());
                sw.Flush();
                try
                {
                    CompressorProcess(resultCatalog, item.ToString(), 0);
                    videoSuccessCount++;
                }
                catch (Exception error)
                {
                    sw.WriteLine(DateTime.Now + "错误信息：" + item.ToString() + error);
                    sw.Flush();
                    videoErrorCount++;
                }
                progressBar1.PerformStep();
                sw.WriteLine(DateTime.Now + "完成压缩视频：" + item.ToString());
                sw.Flush();
            }

            sw.WriteLine(DateTime.Now + "压缩视频成功个数：" + videoSuccessCount);
            sw.WriteLine(DateTime.Now + "压缩视频失败个数：" + videoErrorCount);
            sw.Flush();


            sw.WriteLine(DateTime.Now + "开始压缩图片：");//开始写入值
            sw.Flush();
            int imageSuccessCount = 0;
            int imageErrorCount = 0;
            progressBar1.PerformStep();
            foreach (var item in listBoxImage.Items)
            {
                labelMessage.Text = "正在处理：" + item.ToString() + " ...";
                sw.WriteLine(DateTime.Now + "正在压缩图片：" + item.ToString());
                sw.Flush();
                try
                {
                    CompressorProcess(resultCatalog, item.ToString(), 1);
                    imageSuccessCount++;
                }
                catch (Exception error)
                {
                    sw.WriteLine(DateTime.Now + "错误信息：" + item.ToString() + error);
                    sw.Flush();
                    imageErrorCount++;
                }
                progressBar1.PerformStep();
                sw.WriteLine(DateTime.Now + "完成压缩图片：" + item.ToString());
                sw.Flush();
            }

            sw.WriteLine(DateTime.Now + "压缩图片成功个数：" + imageSuccessCount);
            sw.WriteLine(DateTime.Now + "压缩图片失败个数：" + imageErrorCount);
            sw.Flush();

            string message = "全部处理完成！";
            MessageBox.Show(message);
            labelMessage.Text = message;
            sw.Close();
            log.Close();
        }

        private void CompressorProcess(string resultCatalog, string srcFileName, int type)
        {
            p = new Process();
            p.StartInfo.FileName = appPath + @"\ffmpeg\ffmpeg.exe";
            p.StartInfo.UseShellExecute = false;

            string resultFileName = resultCatalog  + srcFileName.Substring(buttonOpenCatalog.Text.Length);

            string resultFileNameCatalog = Path.GetDirectoryName(resultFileName);

            if (!Directory.Exists(resultFileNameCatalog))
            {
                Directory.CreateDirectory(resultFileNameCatalog);
            }

            if (type == 0) {
                resultFileName = resultFileName.Substring(0, resultFileName.LastIndexOf(".")) + ".mp4";
                string processor = "";
                if (comboBoxProcessor.SelectedItem != null) {
                    processor = "-threads " + comboBoxProcessor.SelectedItem +" ";
                }
                p.StartInfo.Arguments = "-hide_banner -i " + srcFileName + " -y  -vcodec libx264 -profile:v baseline -crf 23 " + processor +  resultFileName;    //压缩视频
            } else if (type==1) {
                p.StartInfo.Arguments = "-hide_banner -i " + srcFileName + " -pix_fmt pal8  -vf dctdnoiz=4.5 -y " + resultFileName;
            }

            p.StartInfo.UseShellExecute = false;  ////不使用系统外壳程序启动进程
            p.StartInfo.CreateNoWindow = true;  //不显示dos程序窗口
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;//把外部程序错误输出写到StandardError流中
            p.StartInfo.UseShellExecute = false;
            string eout = null;
            p.ErrorDataReceived += new DataReceivedEventHandler((sender,e)=> { eout += e.Data; });
            p.Start();
            //p.StandardInput.Close();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.BeginErrorReadLine();//开始异步读取
            string outlog = p.StandardOutput.ReadToEnd();
            p.WaitForExit();//阻塞等待进程结束

            p.Close();//关闭进程
            p.Dispose();//释放资源
        }

        public static bool IsVideo(string path)
        {
            path = path.ToUpper();
            if (
                    path.EndsWith(".WMV") || path.EndsWith(".ASF") ||
                    path.EndsWith(".ASX") || path.EndsWith(".RM") ||
                    path.EndsWith(".RMVB") || path.EndsWith(".MP4") ||
                    path.EndsWith(".3GP") || path.EndsWith(".MOV") ||
                    path.EndsWith(".M4V") || path.EndsWith(".AVI") ||
                    path.EndsWith(".DAT") || path.EndsWith(".MKV") ||
                    path.EndsWith(".FIV") || path.EndsWith(".VOB")
               )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        
        public static bool IsImage(string path)
        {
            path = path.ToUpper();
            if (
                     path.EndsWith(".BMP") || path.EndsWith(".GIF") ||
                     path.EndsWith(".JPEG") || path.EndsWith(".JPG") ||
                     path.EndsWith(".PNG") || path.EndsWith(".SVG") ||
                     path.EndsWith(".PCX") || path.EndsWith(".WMF") ||
                     path.EndsWith(".EMF") || path.EndsWith(".LIC") ||
                     path.EndsWith(".EPS") || path.EndsWith(".TGA") ||
                     path.EndsWith(".TIFF")
               )
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int processorCount = Environment.ProcessorCount;
            for (int i = processorCount; i>0 ; i--)
            {
                comboBoxProcessor.Items.Add(i);
            }
        }
    }
}
