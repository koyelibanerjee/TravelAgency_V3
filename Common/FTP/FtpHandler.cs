using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using DevComponents.DotNetBar;

namespace TravelAgency.Common.FTP
{
    public class FtpHandler
    {
        static string _ftpServerIp;
        static string _ftpRemotePath;
        static string _ftpUserId;
        static string _ftpPassword;
        static string _ftpUri;

        #region 我会用到的方法
        /// <summary>
        /// 设置ftp连接参数，带前带后
        /// </summary>
        /// <param name="FtpServerIP">FTP连接地址</param>
        /// <param name="FtpRemotePath">指定FTP连接成功后的当前目录, 如果不指定即默认为根目录</param>
        /// <param name="FtpUserID">用户名</param>
        /// <param name="FtpPassword">密码</param>
        public static void SetParams(string FtpServerIP, string FtpRemotePath, string FtpUserID, string FtpPassword)
        {
            _ftpServerIp = FtpServerIP;
            _ftpRemotePath = FtpRemotePath;
            _ftpUserId = FtpUserID;
            _ftpPassword = FtpPassword;
            _ftpUri = "ftp://" + _ftpServerIp + "/" + _ftpRemotePath + "/";
        }

        /// <summary>
        /// 更改ftp下载的目录
        /// </summary>
        /// <param name="FtpRemotePath"></param>
        public static void ChangeFtpUri(string FtpRemotePath)
        {
            _ftpRemotePath = FtpRemotePath;
            _ftpUri = "ftp://" + _ftpServerIp + "/" + _ftpRemotePath + "/";
        }

        public static string GetFtpUri()
        {
            return _ftpUri;
        }

        /// <summary>
        /// 下载，支持子目录级别的下载,调用示例:Download("I:Downloads","aaa/bbb/ccc/ddd.txt")
        /// 则会下载 远程目录根目录/aaa/bbb/ccc/ddd.txt 到 I:Downloads/aaa/bbb/ccc/ddd.txt
        /// </summary>
        /// <param name="dstPath"></param>
        /// <param name="remoteName"></param>
        public static bool Download(string dstPath, string remoteName)
        {
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(_ftpUri + remoteName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(_ftpUserId, _ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;

                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);

                string path = Path.GetDirectoryName(dstPath + '\\' + remoteName);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                FileStream outputStream = new FileStream(dstPath + "\\" + remoteName, FileMode.Create); //会直接覆盖源文件
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
                return false;
            }
        }


        /// <summary>
        /// 判断当前目录下指定的文件是否存在
        /// </summary>
        /// <param name="remoteFileName">远程文件名</param>
        public static bool FileExist(string remoteFileName)
        {
            FtpWebRequest reqFTP;
            long fileSize = 0;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(_ftpUri + remoteFileName));
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;

                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(_ftpUserId, _ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                fileSize = response.ContentLength;

                ftpStream.Close();
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                //Insert_Standard_ErrorLog.Insert("FtpWeb", "GetFileSize Error --> " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取当前目录下文件列表(目录也算)，拿到的列表是按照时间顺序排好的，只有文件名，没有路径,有空格的文件名会出错
        /// </summary>
        /// <returns></returns>
        public static List<string> GetFileList()
        {
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(_ftpUri));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(_ftpUserId, _ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails; //ListDirectory用不了不知道为什么


                // 读取网络流数据
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string ftpResponse = reader.ReadToEnd();
                reader.Close();
                response.Close();

                //解析字符串获取  
                //示例:-r--r--r-- 1 ftp ftp        300290 Nov 08  2017 E18158985.jpg
                List<string> res = new List<string>();
                var lines = ftpResponse.TrimEnd().Split('\r');
                for (int i = 0; i < lines.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(lines[i])) //,有空格的文件名会出错
                        continue;
                    int lastSpaceIdx = lines[i].LastIndexOf(' ');
                    string tmp = lines[i].Substring(lastSpaceIdx + 1, lines[i].Length - lastSpaceIdx - 1);
                    if (tmp == "." || tmp == "..")
                        continue;
                    res.Add(tmp);
                }

                return res;
            }
            catch (Exception ex)
            {
                if (ex.Message.Trim() != "远程服务器返回错误: (550) 文件不可用(例如，未找到文件，无法访问文件)。")
                {
                    Insert_Standard_ErrorLog.Insert("FtpWeb", "GetFileList Error --> " + ex.Message.ToString());
                }
                return null;
            }
        }


        public static List<string> GetFileNoDirList(string mask)
        {
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(_ftpUri));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(_ftpUserId, _ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails; //ListDirectory用不了不知道为什么

                // 读取网络流数据
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string ftpResponse = reader.ReadToEnd();
                reader.Close();
                response.Close();

                //解析字符串获取  
                //示例:-r--r--r-- 1 ftp ftp        300290 Nov 08  2017 E18158985.jpg
                List<string> res = new List<string>();
                var lines = ftpResponse.TrimEnd().Split('\r');
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].TrimStart('\n').StartsWith("d"))
                    {
                        continue;
                    }
                    if (string.IsNullOrWhiteSpace(lines[i])) //所以文件名如果包含空格是会出错的
                        continue;
                    int lastSpaceIdx = lines[i].LastIndexOf(' ');
                    string tmp = lines[i].Substring(lastSpaceIdx + 1, lines[i].Length - lastSpaceIdx - 1);
                    if (tmp == "." || tmp == "..")
                        continue;
                    res.Add(tmp);
                }

                return res;
            }
            catch (Exception ex)
            {
                if (ex.Message.Trim() != "远程服务器返回错误: (550) 文件不可用(例如，未找到文件，无法访问文件)。")
                {
                    Insert_Standard_ErrorLog.Insert("FtpWeb", "GetFileList Error --> " + ex.Message.ToString());
                }
                return null;
            }
        }



        /// <summary>
        /// 获取当前目录下明细(包含文件和文件夹)
        /// </summary>
        /// <returns></returns>
        public static List<string> GetFilesDetailList()
        {
            try
            {
                StringBuilder result = new StringBuilder();
                FtpWebRequest ftp;
                ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri(_ftpUri));
                ftp.Credentials = new NetworkCredential(_ftpUserId, _ftpPassword);

                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = ftp.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                //line = reader.ReadLine(); //yxp_2018_01_06 修正文件夹始终少两个的错误。。原来的人不知道为什么在这里写两行这个，可能是他的版本的ftp的前2行是其他数据？
                //line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");

                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf("\n"), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n').ToList();
            }
            catch (Exception ex)
            {
                Insert_Standard_ErrorLog.Insert("FtpWeb", "GetFilesDetailList Error --> " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 获取当前目录下所有的文件夹列表(仅文件夹)
        /// </summary> 
        /// <returns></returns>
        public static List<string> GetDirectoryList()
        {
            List<string> drectory = GetFilesDetailList();
            if (drectory == null || drectory.Count == 0)
                return null;
            string m = string.Empty;
            foreach (string str in drectory)
            {

                if (str.Trim().Substring(0, 1).ToUpper() == "D")
                {

                    string tmp = str.Substring(54).Trim();
                    if (tmp == "." || tmp == "..")
                        continue;
                    //m += tmp + "\n"; //everything搭建的服务器是48,serv-u是54，应该serv-u是标准的
                    m += tmp + "\n"; //原来这里是54 我改成的48,因为服务器版本不同的原因?
                }
            }
            char[] n = new char[] { '\n' };
            var arr = m.Split(n).ToList();
            arr.RemoveAt(arr.Count - 1); //去掉最后一个总是string.empty
            return arr;
        }

        /// <summary>
        /// 判断当前目录下指定的子目录是否存在
        /// </summary>
        /// <param name="RemoteDirectoryName">指定的目录名</param>
        public static bool DirectoryExist(string RemoteDirectoryName)
        {
            List<string> dirList = GetDirectoryList();
            if (dirList == null)
                return false;
            foreach (string str in dirList)
            {
                if (str.Trim() == RemoteDirectoryName.Trim())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断当前目录下abc/123/456这种目录是否存在
        /// </summary>
        /// <param name="RemoteDirectoryName">指定的目录名</param>
        public static bool DeepDirectoryExist(string RemoteDirectoryName)
        {
            if (RemoteDirectoryName.StartsWith("/"))
                RemoteDirectoryName.TrimStart('/');
            if (RemoteDirectoryName.EndsWith("/"))
                RemoteDirectoryName.TrimEnd('/');

            if (!RemoteDirectoryName.Contains('/'))
                return DirectoryExist(RemoteDirectoryName);

            string[] dirs = RemoteDirectoryName.Split('/');

            for (int i = 0; i < dirs.Length; ++i)
            {
                List<string> dirList = GetDirectoryList();
                if (dirList == null)
                    return false;
                bool has = false;
                foreach (string str in dirList)
                {
                    if (str.Trim() == dirs[i].Trim()) //找有没有下一级目录
                    {
                        _ftpUri += dirs[i] + '/'; //去到下一级
                        has = true;
                        break;
                    }
                }
                if (!has)
                    return false;
            }

            //List<string> dirList = GetDirectoryList();
            //if (dirList == null)
            //    return false;
            //foreach (string str in dirList)
            //{
            //    if (str.Trim() == RemoteDirectoryName.Trim())
            //    {
            //        return true;
            //    }
            //}
            return true;
        }


        /// <summary>
        /// 上传,把filename上传上去，比如e:/aaa.jpg上传到当前ftp目录为aaa.jpg,已有同名文件会直接替换，因此最好先调用FileExist检查
        /// </summary>
        public static void Upload(string filename)
        {
            FileInfo fileInf = new FileInfo(filename);
            string uri = _ftpUri + fileInf.Name;
            FtpWebRequest reqFTP;
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            reqFTP.Credentials = new NetworkCredential(_ftpUserId, _ftpPassword);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = fileInf.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            FileStream fs = fileInf.OpenRead();
            try
            {
                Stream strm = reqFTP.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Insert_Standard_ErrorLog.Insert("FtpWeb", "Upload Error --> " + ex.Message);
            }
        }


        /// <summary>
        /// 上传,把srcfilename上传到当前ftp目录,相比于上一个方法就是这里可以指定上传后的名字
        /// </summary>
        /// <param name="srcFileName">如e:/我的文档/xxx.jpg</param>
        /// <param name="dstFileName">如xxx.jpg</param>
        public static void Upload(string srcFileName, string dstFileName)
        {
            FileInfo fileInf = new FileInfo(srcFileName);
            string uri = _ftpUri + dstFileName;
            FtpWebRequest reqFTP;

            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            reqFTP.Credentials = new NetworkCredential(_ftpUserId, _ftpPassword);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = fileInf.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            FileStream fs = fileInf.OpenRead();
            try
            {
                Stream strm = reqFTP.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Insert_Standard_ErrorLog.Insert("FtpWeb", "Upload Error --> " + ex.Message);
            }
        }


        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileName"></param>
        public static bool Delete(string fileName)
        {
            try
            {
                string uri = _ftpUri + fileName;
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

                reqFTP.Credentials = new NetworkCredential(_ftpUserId, _ftpPassword);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;

                string result = String.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                Stream datastream = response.GetResponseStream();
                StreamReader sr = new StreamReader(datastream);
                result = sr.ReadToEnd();
                sr.Close();
                datastream.Close();
                response.Close();
                return true;
            }
            catch (Exception)
            {
                //Insert_Standard_ErrorLog.Insert("FtpWeb", "Delete Error --> " + ex.Message + "  文件名:" + fileName);
                return false; //远程没有文件或者其他
            }
        }


        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="dirName"></param>
        public static void MakeDir(string dirName)
        {
            FtpWebRequest reqFTP;
            try
            {
                // dirName = name of the directory to create.
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(_ftpUri + dirName));
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(_ftpUserId, _ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                Insert_Standard_ErrorLog.Insert("FtpWeb", "MakeDir Error --> " + ex.Message);
            }
        }

        /// <summary>
        /// 在当前目录下创建多级目录，如abc/123/456，也兼容单层目录创建,目录存在会跳过(内部把异常捕捉了)
        /// </summary>
        /// <param name="dirName"></param>
        public static void DeepMakeDir(string dirName)
        {
            if (dirName.StartsWith("/"))
                dirName.TrimStart('/');
            if (dirName.EndsWith("/"))
                dirName.TrimEnd('/');

            if (!dirName.Contains('/'))
            {
                MakeDir(dirName);
                return;
            }

            string[] dirs = dirName.Split('/');

            if (dirs.Length < 1)
                return;
            for (int i = 0; i < dirs.Length; ++i)
            {
                MakeDir(dirs[i]);
                _ftpUri += dirs[i] + "/";
            }

        }


        #endregion

        //底下的方法没用就懒得改成static了














        /// <summary>
        /// 获取指定文件大小
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public long GetFileSize(string filename)
        {
            FtpWebRequest reqFTP;
            long fileSize = 0;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(_ftpUri + filename));
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;

                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(_ftpUserId, _ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                fileSize = response.ContentLength;

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                Insert_Standard_ErrorLog.Insert("FtpWeb", "GetFileSize Error --> " + ex.Message);
            }
            return fileSize;
        }

        /// <summary>
        /// 改名
        /// </summary>
        /// <param name="currentFilename"></param>
        /// <param name="newFilename"></param>
        public void ReName(string currentFilename, string newFilename)
        {
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(_ftpUri + currentFilename));
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.RenameTo = newFilename;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(_ftpUserId, _ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                Insert_Standard_ErrorLog.Insert("FtpWeb", "ReName Error --> " + ex.Message);
            }
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="currentFilename"></param>
        /// <param name="newFilename"></param>
        public void MovieFile(string currentFilename, string newDirectory)
        {
            ReName(currentFilename, newDirectory);
        }

        /// <summary>
        /// 切换当前目录
        /// </summary>
        /// <param name="DirectoryName"></param>
        /// <param name="IsRoot">true 绝对路径   false 相对路径</param> 
        public void GotoDirectory(string DirectoryName, bool IsRoot)
        {
            if (IsRoot)
            {
                _ftpRemotePath = DirectoryName;
            }
            else
            {
                _ftpRemotePath += DirectoryName + "/";
            }
            _ftpUri = "ftp://" + _ftpServerIp + "/" + _ftpRemotePath + "/";
        }

    }

    public class Insert_Standard_ErrorLog
    {
        public static void Insert(string x, string y)
        {

        }
    }

}
