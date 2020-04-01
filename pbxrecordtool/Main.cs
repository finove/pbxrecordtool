using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace pbxrecordtool
{
    public delegate void LogDebug(string format, params object[] args);

    public partial class Main : Form
    {
        static string pbxMgrURL = "http://127.0.0.1:1311";
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtpUpdateDate.Value = DateTime.Now;
        }

        private void btnStartUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDeviceName.Text))
            {
                MessageBox.Show("请填写设备名");
                return;
            }
            // test http://127.0.0.1:1311/pbxmgr/device?action=download_records&date=20190211&device_mac=000EA93D209C&device_name=设备名&device_type=2
            var update = dtpUpdateDate.Value.ToString("yyyyMMdd");
            string upmac = txtDeviceMAC.Text.ToUpper().Replace(":", "");
            string url = string.Format("{0}/pbxmgr/device?action=download_records&date={1}&device_mac={2}&device_name={3}&device_type=2", pbxMgrURL, update, upmac, txtDeviceName.Text);
            string resp = HttpRequest.Post(url, null);
            MessageBox.Show("请求服务器开始同步录音" + url + " resp " + resp);
        }
    }

    public class HttpRequest
    {
        public static LogDebug warn = new LogDebug(DefaultLog);
        private CookieContainer cookie;
        public HttpRequest()
        {
            cookie = new CookieContainer();
        }

        public static void SetWarn(LogDebug log)
        {
            warn = log;
        }

        public static string Get(string url)
        {
            return SendHttpRequest(url, "GET", "");
        }

        public static string Post(string url, string body)
        {
            return SendHttpRequest(url, "POST", body);
        }

        public static string Put(string url, string body)
        {
            return SendHttpRequest(url, "PUT", body);
        }

        public static string SendHttpRequest(string url, string method, string body)
        {
            string msg = "";
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            try
            {
                HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
                req.Method = method;
                req.Accept = "application/xml, text/xml, */*";
                req.KeepAlive = false;
                req.Timeout = 10 * 1000;
                req.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                if (method.Equals("POST") == true || method.Equals("PUT") == true)
                {
                    if (string.IsNullOrEmpty(body) == false)
                    {
                        req.ContentLength = Encoding.UTF8.GetByteCount(body);
                        using (StreamWriter sw = new StreamWriter(req.GetRequestStream()))
                        {
                            sw.Write(body);
                        }
                    }
                }
                using (var res = req.GetResponse())
                {
                    Stream respStream = res.GetResponseStream();
                    using (StreamReader reader = new StreamReader(respStream, Encoding.UTF8))
                    {
                        msg = reader.ReadToEnd();
                    }
                }
                warn("{0} {1} success, resp length {2}", method, url, msg.Length);
            }
            catch (Exception ex)
            {
                warn("{0} {1} fail, {2}", method, url, ex.Message);
            }
            return msg;
        }

        public static void DefaultLog(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }
    }

    public class SimpleLog
    {
        public static LogDebug LDebug = new LogDebug(DefaultLog);
        public static LogDebug LWarn = new LogDebug(DefaultLog);
        public string FileNamePrefix;
        public string FileName;
        public int LogLevel;
        private int rollingSize = 2 * 1024 * 1024;
        private bool initFail;
        private FileStream logFs;
        private StreamWriter logWriter;

        public SimpleLog()
        {
            initFail = true;
        }

        public SimpleLog(string fileNamePrefix)
        {
            FileNamePrefix = fileNamePrefix;
            initLogFile();
        }

        ~SimpleLog()
        {
            try
            {
                logWriter.Close();
                logFs.Close();
            }
            catch
            {
                return;
            }
        }

        public void RollingSize(int size)
        {
            if (size > 0)
            {
                rollingSize = size;
            }
        }

        private void rollingFile()
        {
            if (logFs != null && logWriter != null && logFs.Length > rollingSize)
            {
                logWriter.Close();
                logFs.Close();
                initLogFile();
            }
        }

        private void initLogFile()
        {
            initFail = false;
            logWriter = null;
            try
            {
                FileName = string.Format("{0}_{1}.log", FileNamePrefix, DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                logFs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                logWriter = new StreamWriter(logFs);
                logWriter.BaseStream.Seek(0, SeekOrigin.End);
            }
            catch
            {
                initFail = true;
            }
        }

        private void prefixLog()
        {
            logWriter.Write(string.Format("{0} [{1}] ", DateTime.Now.ToString(), Thread.CurrentThread.ManagedThreadId));
            //logWriter.Write(logFs.Length);
        }

        public void Debug(string format)
        {
            rollingFile();
            if (initFail == true || logWriter == null)
            {
                return;
            }
            prefixLog();
            logWriter.WriteLine(format);
            logWriter.Flush();
        }

        public void Debug(string format, object arg0)
        {
            Debug(string.Format(format, arg0));
        }

        public void Debug(string format, object arg0, object arg1)
        {
            Debug(string.Format(format, arg0, arg1));
        }

        public void Debug(string format, object arg0, object arg1, object arg2)
        {
            Debug(string.Format(format, arg0, arg1, arg2));
        }

        public void Debug(string format, object arg0, object arg1, object arg2, object arg3)
        {
            Debug(string.Format(format, arg0, arg1, arg2, arg3));
        }

        public void Debug(string format, object arg0, object arg1, object arg2, object arg3, object arg4)
        {
            Debug(string.Format(format, arg0, arg1, arg2, arg3, arg4));
        }

        public void Debug(string format, params object[] args)
        {
            Debug(string.Format(format, args));
        }

        public void Info(string format)
        {
            Debug(format);
        }

        public void Info(string format, object arg0)
        {
            Debug(string.Format(format, arg0));
        }

        public void Info(string format, object arg0, object arg1)
        {
            Debug(string.Format(format, arg0, arg1));
        }

        public void Info(string format, object arg0, object arg1, object arg2)
        {
            Debug(string.Format(format, arg0, arg1, arg2));
        }

        public void Warn(string format)
        {
            Debug(format);
        }

        public void Warn(string format, object arg0)
        {
            Debug(string.Format(format, arg0));
        }

        public void Warn(string format, object arg0, object arg1)
        {
            Debug(string.Format(format, arg0, arg1));
        }

        public void Warn(string format, object arg0, object arg1, object arg2)
        {
            Debug(string.Format(format, arg0, arg1, arg2));
        }

        public void Warn(string format, params object[] args)
        {
            Debug(string.Format(format, args));
        }

        /* -- for lib common used -- */
        public static void DefaultLog(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }
    }
}
