using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using Microsoft.Win32;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Net;
using System.Security.AccessControl;

namespace SZOH_Launcher
{
    public partial class Form1 : Form
    {
        // Свойство: флаг, зажата ли кнопка мыши, чтобы тащить окно
        private bool movingWindow = false;
        // Свойство: объект для хранения положения курсора до начала перемещения
        private Point oldCursorPosition;
        String Version = "v 0.1";

        string[] args;
        public Form1(string[] args)
        {
            this.args = args;
            InitializeComponent();

            //Check();
            //News.Text = asd();
            label1.Text = Version;
            PrepairForm();
            // Событие: рисование формы
            this.Paint += new PaintEventHandler(Main_Paint);
        }
        #region Import dll
        [DllImport("kernel32")]
        public static extern IntPtr CreateRemoteThread(
          IntPtr hProcess,
          IntPtr lpThreadAttributes,
          uint dwStackSize,
          UIntPtr lpStartAddress,
          IntPtr lpParameter,
          uint dwCreationFlags,
          out IntPtr lpThreadId
        );

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(
            UInt32 dwDesiredAccess,
            Int32 bInheritHandle,
            Int32 dwProcessId
            );

        [DllImport("kernel32.dll")]
        public static extern Int32 CloseHandle(
        IntPtr hObject
        );

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool VirtualFreeEx(
            IntPtr hProcess,
            IntPtr lpAddress,
            UIntPtr dwSize,
            uint dwFreeType
            );

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern UIntPtr GetProcAddress(
            IntPtr hModule,
            string procName
            );

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(
            IntPtr hProcess,
            IntPtr lpAddress,
            uint dwSize,
            uint flAllocationType,
            uint flProtect
            );

        [DllImport("kernel32.dll")]
        static extern bool WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            string lpBuffer,
            UIntPtr nSize,
            out IntPtr lpNumberOfBytesWritten
        );

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(
            string lpModuleName
            );

        [DllImport("kernel32", SetLastError = true, ExactSpelling = true)]
        internal static extern Int32 WaitForSingleObject(
            IntPtr handle,
            Int32 milliseconds
            );
        #endregion
        #region Injector
        public Int32 GetProcessId(String proc, String Directory)
        {
            System.Diagnostics.Process proc1 = new System.Diagnostics.Process();
            proc1.StartInfo.FileName = proc;
            proc1.StartInfo.WorkingDirectory = Directory;
            proc1.Start();
            return proc1.Id;
        }

        public void InjectDLL(IntPtr hProcess, String strDLLName)
        {
            IntPtr bytesout;
            Int32 LenWrite = strDLLName.Length + 1;
            IntPtr AllocMem = (IntPtr)VirtualAllocEx(hProcess, (IntPtr)null, (uint)LenWrite, 0x1000, 0x40);
            WriteProcessMemory(hProcess, AllocMem, strDLLName, (UIntPtr)LenWrite, out bytesout);
            UIntPtr Injector = (UIntPtr)GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

            if (Injector == null)
            {
                MessageBox.Show(" Injecto Error! \n ");
                return;
            }
            IntPtr hThread = (IntPtr)CreateRemoteThread(hProcess, (IntPtr)null, 0, Injector, AllocMem, 0, out bytesout);
            if (hThread == null)
            {
                MessageBox.Show("Thread injection Failed");
                return;
            }
            int Result = WaitForSingleObject(hThread, 10 * 1000);
            if (Result == 0x00000080L || Result == 0x00000102L || Result == 0xFFFFFFFF)
            {
                MessageBox.Show("Thread 2 inject failed");
                if (hThread != null)
                {
                    CloseHandle(hThread);
                }
                return;
            }
            Thread.Sleep(1000);
            VirtualFreeEx(hProcess, AllocMem, (UIntPtr)0, 0x8000);
            if (hThread != null)
            {
                CloseHandle(hThread);
            }
            return;
        }
        #endregion
        private string DateInternet(int ymd)
        {
			string url = "http://time.jp-net.ru";
            string html = string.Empty;
            string pattern = string.Empty;
            if (ymd == 1)
            {
                pattern = "<h1 align='center'>Точная дата: (....)-..-..";
            }
            else if (ymd == 2)
            {
                pattern = "<h1 align='center'>Точная дата: ....-..-(..)";
            }
            else if (ymd == 3)
            {
                pattern = "<h1 align='center'>Точная дата: ....-(..)-..";
            }
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                StreamReader sr = new StreamReader(myResponse.GetResponseStream(), Encoding.GetEncoding(1251));
                html = sr.ReadToEnd();
            }
            catch 
            {
                MessageBox.Show("Ошибка подключения к интернету!");
                //Environment.Exit(0);
            }
            Match res;
            res = Regex.Match(html, pattern);
            return res.Groups[1].ToString();
        }
        private string DateComputer(int ymd)
        {
            string html = DateTime.Now.ToString();
            string pattern = string.Empty;
            if (ymd == 1)
            {
                pattern = "......(....)";
            }
            else if (ymd == 2)
            {
                pattern = "...(..).....";
            }
            else if (ymd == 3)
            {
                pattern = "(..)........";
            }

            Match res;
            res = Regex.Match(html, pattern);
            return res.Groups[1].ToString();
        }
        private void Check()
        {
            string command = "date " + DateInternet(3) + "-" + DateInternet(2) + "-" + DateInternet(1);

            int YearComputer = Convert.ToInt32(DateComputer(1));
            int MonthsComputer = Convert.ToInt32(DateComputer(2));
            int DayComputer = Convert.ToInt32(DateComputer(3));


            int YearSite = Convert.ToInt32(DateInternet(1));
            int MonthsSite = Convert.ToInt32(DateInternet(2));
            int DaySite = Convert.ToInt32(DateInternet(3));

            if (YearSite != YearComputer || MonthsSite != MonthsComputer || DaySite != DayComputer)
            {
                Process cmd = new Process();//создаем новый объект класса
                cmd.StartInfo = new ProcessStartInfo(@"cmd.exe", "/C " + command);//задаем имя исполняемого файла
                cmd.StartInfo.CreateNoWindow = true;//не создавать окно
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//спрятать окно
                cmd.Start();
                //System.Diagnostics.Process.Start("cmd.exe", "/C " + command);
                //System.Windows.MessageBox.Show(" Год: " + YearInternet() + "\n Месяц: " + MonthsInternet() + "\n День: " + DayInternet());
                //Close();
            }
        }
        private string ReadNews()
        {
            return "Here was news";
            string url = "http://szohack.ucoz.ru/News.txt";
            string html = string.Empty;

                HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                myRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; Tablet PC 2.0; OfficeLiveConnector.1.4; OfficeLivePatch.1.3)";
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                StreamReader sr = new StreamReader(myResponse.GetResponseStream(), Encoding.Unicode);
                html = sr.ReadToEnd();

            return html;
        }
        private void DrawBorder(Graphics g)
        {
            // Рисуем прямоугольник, он же серая рамка вокруг формы
            g.DrawRectangle(
                Pens.DimGray,
                ClientRectangle.X, ClientRectangle.X,
                ClientRectangle.Width - 1, ClientRectangle.Height - 1);
        }
        private void Main_Paint(object sender, PaintEventArgs e)
        {
            DrawBorder(e.Graphics);
        }
        private void AutoRun(bool Run)
        {
            /* Нам нужно Создать запись в:
             * HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run
             */
            string NameProgram = "SZOH_Launcher";//Название должно совпадать с выходным файлом Проекта. !!БЕЗ *.exe
            try
            {
                // Создать запись в реестре
                RegistryKey regFirst = Registry.CurrentUser;//Получение адреса HKEY_CURRENT_USER
                //Поиск каждого раздела, в итоге должны попасть в \Run, где и запишем нашу программу
                RegistryKey regsw = regFirst.OpenSubKey("Software", true);
                RegistryKey regmc = regsw.OpenSubKey("Microsoft", true);
                RegistryKey regwin = regmc.OpenSubKey("Windows", true);
                RegistryKey regcv = regwin.OpenSubKey("CurrentVersion", true);
                RegistryKey regrun = regcv.OpenSubKey("Run", true);

                if (Run == true)
                {
                    //Создает запись в реестре, в \Run (Запуск программ, по включению Windows)
                    regrun.SetValue(NameProgram, Application.ExecutablePath, RegistryValueKind.String);

                }
                else
                {
                    //В случае "занятости" удаляет предыдущую запись
                    regrun.DeleteValue(NameProgram);
                }

                //Закрываем
                regrun.Close();
                regcv.Close();
                regwin.Close();
                regmc.Close();
                regsw.Close();
                regFirst.Close();
            }
            catch
            {
               //
            }

        }
        private void OFDialog_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Launcher (SZoneOnlineLauncher.exe)|SZoneOnlineLauncher.exe";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                GameDirecotry.Text = openFileDialog1.FileName;
            }
        }
        private void LaunchGame()
        {
            //Check();
            String DirectoryLauncher = GameDirecotry.Text;
            String DirectoryGame = DirectoryLauncher.Substring(0, DirectoryLauncher.Length - 23);
            String Directory = DirectoryGame + @"\game";
            String strProcessName = Directory + @"\SZoneOnline.exe";
            String sysdir = Environment.SystemDirectory.ToString();
            //String strDLLName = sysdir + @"\aapid.dll";
            String strDLLName = "C:\\dxhook.dll";

            //WebClient wc = new WebClient();
            //wc.Headers.Add("user-agent", "Mozilla/5.0");
            //wc.DownloadFile("http://szohack.ucoz.ru/MultiHack.dll", strDLLName);

            Int32 ProcID = GetProcessId(strProcessName, Directory);

            if (ProcID >= 0)
            {
                //Check();
                IntPtr hProcess = (IntPtr)OpenProcess(0x1F0FFF, 1, ProcID);
                if (hProcess == null)
                {
                    //MessageBox.Show("FAIL");
                    return;
                }
                else
                {
                    Thread.Sleep(10000);
                    InjectDLL(hProcess, strDLLName);
                    //MessageBox.Show("TRUE");
                }
                this.ShowInTaskbar = false;
                this.Hide();
                notifyIcon1.Visible = true;
            }
            CountRun++;
        }
        private void Go_Game_Click(object sender, EventArgs e)
        {
            LaunchGame();
        }
        private void PrepairForm()
        {
            // Устанавливаем стили окна
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);

            // Устанавливаем стандартные фоновые изображения для Тайтла
            //closeHide.BackgroundImage = global::SZOH_Launcher.Properties.Resources._new_buttons_hover;
            Top.BackgroundImage = global::SZOH_Launcher.Properties.Resources.top;

        }
        public string GetVersion()
        {
            return "v 0.1";
            string url = "http://szohack.ucoz.ru/index/version/0-6";
            string html = string.Empty;
            string pattern = "IVersionI(.*)I/VersionI";

            HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), Encoding.GetEncoding(1251));
            html = sr.ReadToEnd();

            Match res;
            res = Regex.Match(html, pattern);
            return res.Groups[1].ToString();
        }
        private void Top_MouseDown(object sender, MouseEventArgs e)
        {
            // Перед началом перемещения окно сохраняем текущие координаты курсора мышки
            oldCursorPosition = new Point(e.X, e.Y);
            // Устанавливаем флаг на Да
            movingWindow = true;
        }
        private void Top_MouseUp(object sender, MouseEventArgs e)
        {
            // Когда мы отпускаем кнопку мышки, устанавливаем флаг на Нет
            movingWindow = false;
        }
        private void Top_MouseMove(object sender, MouseEventArgs e)
        {
            //Если флаг имеет значение Да
            if (movingWindow)
            {
                // Получаем текущее положение курсора
                Point newCursorPosition = new Point(e.X, e.Y);
                // Получаем разницу между текущим положением курсора и тем, что было
                // до того как мы начали перемещать курсор
                newCursorPosition.X = newCursorPosition.X - oldCursorPosition.X;
                newCursorPosition.Y = newCursorPosition.Y - oldCursorPosition.Y;
                // К текущему положению окна прибавляем разницу, чтобы получить сдвиг
                // в нужные стороны
                this.Location = new Point(this.Location.X + newCursorPosition.X,
                                          this.Location.Y + newCursorPosition.Y);
            }
        }
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Hide_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.Hide();
            notifyIcon1.Visible = true;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            GoGameButton.Image = global::SZOH_Launcher.Properties.Resources.GoGameDown;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            GoGameButton.Image = global::SZOH_Launcher.Properties.Resources.GoGame;
        }
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            OFDButton.Image = global::SZOH_Launcher.Properties.Resources.DirectoryDown;
        }
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            OFDButton.Image = global::SZOH_Launcher.Properties.Resources.Directory;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            On = (!On);
            if (On == true)
            {
                AutoRunCheckBox.Image = global::SZOH_Launcher.Properties.Resources.CheckBoxOn;
                AutoRun(true);
            }
            else if(On == false)
            {
                AutoRunCheckBox.Image = global::SZOH_Launcher.Properties.Resources.CheckBox;
                AutoRun(false);
            }
        }
        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            CheckUpdateButton.Image = global::SZOH_Launcher.Properties.Resources.CheckUpdateDown;
        }
        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            CheckUpdateButton.Image = global::SZOH_Launcher.Properties.Resources.CheckUpdate;
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            String Ver = GetVersion().ToString();
            if (Version != Ver)
            {
                System.Diagnostics.Process upt = new System.Diagnostics.Process();
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.Headers.Add("user-agent", "Mozilla/5.0");
                wc.DownloadFile("https://dl.dropboxusercontent.com/s/qxzu7oihdznwvvg/Update.exe?token_hash=AAF94lxghpfElZlVrzAg9DlDUDUimxMJugiZKqnUXDHqjA&dl=1", "Update.exe");
                upt.StartInfo.FileName = "Update.exe";
                upt.Start();
                this.Close();
            }
            else
            {
                MessageBox.Show("Обновление не требуется.");
            }
        }
        private void WriteSettings()
        {
            string filename = "Configuration.config";

            try
            {
                FileInfo fi = new FileInfo(filename);
                StreamWriter wr;  //Класс для записи в файл
                wr = fi.CreateText(); //Дописываем инфу в файл, если файла не существует он создастся
                wr.WriteLine("<GameDir>" + GameDirecotry.Text + "</GameDir>"); //Записываем в файл текст из текстового поля
                wr.WriteLine("<CheckBox>" + On + "</CheckBox>"); //Записываем в файл текст из текстового поля
                wr.WriteLine("<CountRun>" + CountRun + "</CountRun>"); //Записываем в файл текст из текстового поля
                wr.Close(); // Закрываем файл
            }
            catch { MessageBox.Show("существует!", "Такие дела", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }
        private void ReadSettings()
        {
            
            bool on;
            string html = string.Empty;
            string patternGD = "<GameDir>(.*)</GameDir>";
            string patternCB = "<CheckBox>(.*)</CheckBox>";
            string patternCR = "<CountRun>(.*)</CountRun>";

            try
            {
            FileInfo fi = new FileInfo("Configuration.config");
            if (fi.Exists == true) //Если файл не существует
                {
                    StreamReader sr = new StreamReader("Configuration.config"); //Открываем файл для чтения
                    //string GD = ""; //Объявляем переменную, в которую будем записывать текст из файла

                    while (!sr.EndOfStream) //Цикл длиться пока не будет достигнут конец файла
                        {
                            html += sr.ReadLine(); //В переменную str по строчно записываем содержимое файла
                        }

                    sr.Close();

                Match resGD;
                resGD = Regex.Match(html, patternGD);
                Match resCB;
                resCB = Regex.Match(html, patternCB);
                Match resCR;
                resCR = Regex.Match(html, patternCR);

                if (resCB.Groups[1].ToString() == "True") { on = true; }
                else { on = false; }

                GameDirecotry.Text = resGD.Groups[1].ToString();
                On = on;
                CountRun = Convert.ToInt32(resCR.Groups[1].ToString());
                }
            }
                catch{MessageBox.Show("Файл НЕ существует!", "Такие дела", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);}
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadSettings();
            //MessageBox.Show(ReadNews());
            //ReadNews();
            News.Text = ReadNews();
            if (args.Length == 0) 
            { 
                //
            }
            else if (args[0] == "-gg")
            {
                LaunchGame();
            }

            String Ver = GetVersion().ToString();
            if (Version != Ver)
            {
                System.Diagnostics.Process upt = new System.Diagnostics.Process();
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.Headers.Add("user-agent", "Mozilla/5.0");
                wc.DownloadFile("https://dl.dropboxusercontent.com/s/qxzu7oihdznwvvg/Update.exe?token_hash=AAF94lxghpfElZlVrzAg9DlDUDUimxMJugiZKqnUXDHqjA&dl=1", "Update.exe");
                upt.StartInfo.FileName = "Update.exe";
                upt.Start();
                this.Close();
            }

            if (CountRun >= 15)
            {
                Opros.Visible = true;
                Opros.Update();
            }

            if (On == true)
            {
                AutoRunCheckBox.Image = global::SZOH_Launcher.Properties.Resources.CheckBoxOn;
                AutoRun(true);
            }
            else if (On == false)
            {
                AutoRunCheckBox.Image = global::SZOH_Launcher.Properties.Resources.CheckBox;
                AutoRun(false);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            String sysdir = Environment.SystemDirectory.ToString();
            String strDLLName = sysdir+@"\aapid.dll";
            foreach (Process currentProcess in Process.GetProcessesByName("SZoneOnline"))
            currentProcess.Kill();
            Thread.Sleep(350);
            if(File.Exists(strDLLName))
            {
            File.Delete(strDLLName);
            }
            WriteSettings();
        }
        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            Opros.Image = global::SZOH_Launcher.Properties.Resources.OprosDown;
        }
        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            Opros.Image = global::SZOH_Launcher.Properties.Resources.Opros;
        }
        private void Opros_Click(object sender, EventArgs e)
        {
            CountRun5 d = new CountRun5();
            d.ShowDialog();
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Включаем отображения приложения на панели задач при запуске
            this.ShowInTaskbar = true;
            //Показываем форму
            this.Show();
            notifyIcon1.Visible = false;
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Включаем отображения приложения на панели задач при запуске
            this.ShowInTaskbar = true;
            //Показываем форму
            this.Show();
            notifyIcon1.Visible = false;
        }














    }
}
