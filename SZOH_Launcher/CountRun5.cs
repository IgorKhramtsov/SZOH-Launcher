using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Diagnostics;
using Microsoft.Win32;
using System.Management;



namespace SZOH_Launcher
{
    public partial class CountRun5 : Form
    {
        public CountRun5()
        {
            InitializeComponent();
            //label2.Visible = false;
        }

        public string Video()
        {
            ManagementObjectSearcher searcher11 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController"); 
            string ret=string.Empty;
            foreach (ManagementObject queryObj in searcher11.Get())
            {
                ret = queryObj["VideoProcessor"].ToString(); 
            }
            return ret;
        }
        public string Processor(bool proc)
        {
            ManagementObjectSearcher searcher8 =new ManagementObjectSearcher("root\\CIMV2","SELECT * FROM Win32_Processor");
            string procname = string.Empty;
            string procid = string.Empty;
            string Proc=string.Empty;
            foreach (ManagementObject queryObj in searcher8.Get())
            {
                procname=queryObj["Name"].ToString();
                procid  =queryObj["ProcessorId"].ToString();
            }

            if (proc == false) { Proc = procname; }
            else if (proc==true){Proc=procid;}

            return Proc;
        }
        public string motherbroad(bool mother)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2","SELECT * FROM Win32_BaseBoard");
            string manu = string.Empty;
            string prod = string.Empty;
            string Mother = string.Empty;
            foreach (ManagementObject queryObj in searcher.Get())
            {
                manu=queryObj["Manufacturer"].ToString();
                prod=queryObj["Product"].ToString();
            }
            if (mother == false) { Mother = manu; }
            else if (mother == true) { Mother = prod; }
            return Mother;
        }
        public string diskdrive(bool disk)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive");
            string model = string.Empty;
            string serial = string.Empty;
            string Disk = string.Empty;
            foreach (ManagementObject queryObj in searcher.Get())
            {
                model = queryObj["Model"].ToString();
                serial = queryObj["SerialNumber"].ToString();
            }
            if (disk == false) { Disk = model; }
            else if (disk == true) { Disk = serial; }
            return Disk;
        }
        public string GetOsVersion()
        {
            // Создать запись в реестре
            RegistryKey regFirst = Registry.LocalMachine;//Получение адреса HKEY_CURRENT_USER
            //Поиск каждого раздела, в итоге должны попасть в \Run, где и запишем нашу программу
            RegistryKey regsw = regFirst.OpenSubKey("Software", true);
            RegistryKey regmc = regsw.OpenSubKey("Microsoft", true);
            RegistryKey regwin = regmc.OpenSubKey("Windows NT", true);
            RegistryKey regcv = regwin.OpenSubKey("CurrentVersion", true);
            //RegistryKey regpn = regcv.OpenSubKey("ProductName", true);
            string OS=(string)regcv.GetValue("ProductName");
            return OS;
        }

        void SendInfo()
        {
                String host = System.Net.Dns.GetHostName();
                System.Net.IPAddress ip = System.Net.Dns.GetHostByName(host).AddressList[0];
                string YN;
                if (Properties.Settings.Default.NormalWork == true) { YN = "\nКорректно ли работает вх: Да"; }
                else { YN = "\nКорректно ли работает вх: Нет"; }
                string IP = "\nIP: "+ip.ToString();
                string OS = "\nОперационная система: "+GetOsVersion();
                string NameComp = "Имя компьютера: "+Environment.MachineName.ToString();
                string UserName = "\nИмя пользователя: "+Environment.UserName.ToString();
                string SysDir = "\nСитсемная дирректория: "+Environment.SystemDirectory.ToString();
                string wife = "\nПредложения и замечания: " + textBox1.Text;
                //----------------Железо---------------//
                string VideContr = "\nВидеокарта: " + Video();
                string NameProc = "\nПроцессор: " + Processor(false);
                string IdProc = "\nID Процессора: " + Processor(true);
                string MotherManu = "\nМатеринская плата мануфактура: " + motherbroad(false);
                string MotherProd = "\nМатеринская плата продукт: " + motherbroad(true);
                string DriveModel = "\nЖёсткий диск модель: " + diskdrive(false);
                string DriveSerial = "\nЖёсткий диск серийный номер: " + diskdrive(true);
                

                SmtpClient client = new SmtpClient("smtp.yandex.ru", 587);
                client.Credentials = new System.Net.NetworkCredential("InfoSZOH@yandex.ru", "jF2N9Si2rN5g"); 
                string msgSubject = "Info";

                string msgBody = String.Format(NameComp + UserName + OS + IP + VideContr + NameProc + IdProc + MotherManu + MotherProd + DriveModel + DriveSerial +  SysDir + YN + wife);
               
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("InfoSZOH@yandex.ru");
                msg.To.Add(new MailAddress("igorxramcov@yandex.ru"));
                msg.Subject = msgSubject;
                msg.Body = msgBody;
                try
                {
                    client.Send(msg); // Отправляем письмо
                }
                catch
                {
                    MessageBox.Show("Ошибка подключения к интернету!");
                    this.Close();
                }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.NormalWork = true;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.NormalWork = false;
        }
        private void Apply_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            Back.Enabled = false;
            Apply.Enabled = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            label1.Visible = false;
            textBox1.Visible = false;
            label2.Update();
            SendInfo();
            this.Close();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
