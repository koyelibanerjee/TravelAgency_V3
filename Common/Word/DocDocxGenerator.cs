using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.Model;
using Xceed.Words.NET;

namespace TravelAgency.Common.Word
{
    public class DocDocxGenerator
    {
        public enum DocType
        {
            Type01JinQiaoList,
            Type02WaiLingDanBaohan,
            Type02JinQiaoDanBaoHan,
            Type03JiPiao,
            Type03JiPiaoBBCH,//阪阪川航
            Type03JiPiaoDBCH,//
            Type03JiPiaoDDCH,//
            Type03JiPiaoDDGH,
            Type03JiPiaoDDQRK,
            Type03JiPiaoXBDH,
            Type04TaiQianDanBao,
            Type05TaiQianJiPiao_DH,
            Type05TaiQianJiPiao_CH,
            Type05TaiQianJiPiao_TH,
            Type05TaiQianJiPiao,
            Type06HanguoDanBaoHan,
            Type07HanguoJiaji,
            Type08XXTYCLS, //信息同意处理书
            Type09个人申请表 //个人申请表
        }

        /// <summary>
        /// 占位符数量
        /// </summary>
        public static int PlaceHolderNum { get; set; }

        /// <summary>
        /// 默认保存文件名
        /// </summary>
        public static string DefaultName { get; set; }

        /// <summary>
        /// 模板文件名
        /// </summary>
        public static string TemplaceDocFileName { get; set; }

        public DocDocxGenerator()
        {

        }

        public DocDocxGenerator(DocDocxGenerator.DocType type)
        {
            SetDocType(type);
        }

        public void SetDocType(DocDocxGenerator.DocType type)
        {
            if (type == DocDocxGenerator.DocType.Type01JinQiaoList)
            {
                PlaceHolderNum = 44;
                DefaultName = "金桥大名单.docx";
                TemplaceDocFileName = "template_成都金桥大名单_添加占位符1-31.docx";
            }
            if (type == DocDocxGenerator.DocType.Type02WaiLingDanBaohan)
            {
                PlaceHolderNum = 4;
                DefaultName = "外领区人员特别担保函 （国旅四川）.docx";
                TemplaceDocFileName = "template_外领区人员特别担保函 （国旅四川）_添加占位符1-4.docx";
            }
            if (type == DocDocxGenerator.DocType.Type02JinQiaoDanBaoHan)
            {
                PlaceHolderNum = 6;
                DefaultName = "成都金桥担保函.docx";
                TemplaceDocFileName = "template_成都金桥担保函.docx";
            }
            if (type == DocDocxGenerator.DocType.Type03JiPiao)
            {
                PlaceHolderNum = 19;
                DefaultName = "机票（表7）.docx";
                TemplaceDocFileName = "template_机票（表7）.docx";
            }
            if (type == DocDocxGenerator.DocType.Type03JiPiaoBBCH)
            {
                PlaceHolderNum = 19;
                DefaultName = "日本_机票_阪阪川航.docx";
                TemplaceDocFileName = "template_日本_机票_阪阪川航.docx";
            }
            if (type == DocDocxGenerator.DocType.Type03JiPiaoDBCH)
            {
                PlaceHolderNum = 19;
                DefaultName = "日本_机票_东阪川航.docx";
                TemplaceDocFileName = "template_日本_机票_东阪川航.docx";
            }
            if (type == DocDocxGenerator.DocType.Type03JiPiaoDDCH)
            {
                PlaceHolderNum = 19;
                DefaultName = "日本_机票_东东川航.docx";
                TemplaceDocFileName = "template_日本_机票_东东川航.docx";
            }
            if (type == DocDocxGenerator.DocType.Type03JiPiaoDDGH)
            {
                PlaceHolderNum = 19;
                DefaultName = "日本_机票_东东国航.docx";
                TemplaceDocFileName = "template_日本_机票_东东国航.docx";
            }
            if (type == DocDocxGenerator.DocType.Type03JiPiaoDDQRK)
            {
                PlaceHolderNum = 19;
                DefaultName = "日本_机票_东东全日空.docx";
                TemplaceDocFileName = "template_日本_机票_东东全日空.docx";
            }
            if (type == DocDocxGenerator.DocType.Type03JiPiaoXBDH)
            {
                PlaceHolderNum = 19;
                DefaultName = "日本_机票_新北东航.docx";
                TemplaceDocFileName = "template_日本_机票_新北东航.docx";
            }

            
            if (type == DocDocxGenerator.DocType.Type04TaiQianDanBao)
            {
                PlaceHolderNum = 4;
                DefaultName = "泰签担保函.docx";
                TemplaceDocFileName = "template_泰签担保函.docx";
            }
            if (type == DocDocxGenerator.DocType.Type05TaiQianJiPiao)
            {
                PlaceHolderNum = 3;
                DefaultName = "01机票单-泰国.docx";
                TemplaceDocFileName = "template_01机票单-泰国.docx";
            }
            if (type == DocDocxGenerator.DocType.Type05TaiQianJiPiao_DH)
            {
                PlaceHolderNum = 3;
                DefaultName = "01机票单-泰国(东航).docx";
                TemplaceDocFileName = "template_泰国_机票单_东航.docx";
            }
            if (type == DocDocxGenerator.DocType.Type05TaiQianJiPiao_CH)
            {
                PlaceHolderNum = 3;
                DefaultName = "01机票单-泰国(川航).docx";
                TemplaceDocFileName = "template_泰国_机票单_川航.docx";
            }
            if (type == DocDocxGenerator.DocType.Type05TaiQianJiPiao_TH)
            {
                PlaceHolderNum = 3;
                DefaultName = "01机票单-泰国(泰航).docx";
                TemplaceDocFileName = "template_泰国_机票单_泰航.docx";
            }

            if (type == DocDocxGenerator.DocType.Type06HanguoDanBaoHan)
            {
                PlaceHolderNum = 15;
                DefaultName = "韩国担保函模板.docx";
                TemplaceDocFileName = "template_韩国担保函模板.docx";
            }
            if (type == DocDocxGenerator.DocType.Type07HanguoJiaji)
            {
                PlaceHolderNum = 9;
                DefaultName = "韩国加急模板.docx";
                TemplaceDocFileName = "template_韩国加急模板.docx";
            }
            if (type == DocDocxGenerator.DocType.Type08XXTYCLS)
            {
                PlaceHolderNum = 46;
                DefaultName = "信息处理同意书.docx";
                TemplaceDocFileName = "template_信息处理同意书.docx";
            }
            if (type == DocDocxGenerator.DocType.Type09个人申请表)
            {
                PlaceHolderNum = 23;
                DefaultName = "个人赴日本旅游签证申请表.docx";
                TemplaceDocFileName = "template_2017年个人赴日本旅游签证申请表.docx";
            }
        }

        public void Generate(List<string> listWait4Replace)
        {
            if (listWait4Replace.Count > PlaceHolderNum)
            {
                MessageBoxEx.Show("数据量多余所选模板占位符数量:" + PlaceHolderNum);
                return;
            }


            string dstName = GlobalUtils.ShowSaveFileDlg(DefaultName, "Word文档|*.docx");

            // If the file name is not an empty string open it for saving.
            if (!string.IsNullOrEmpty(dstName))
            {
                if (!DocXHandler.BatchReplaceStringByPlaceHolder(GlobalUtils.AppPath + @"\Word\Templates\" + TemplaceDocFileName, dstName, listWait4Replace, true, PlaceHolderNum))
                {
                    MessageBoxEx.Show("生成报表失败，请联系技术人员!");
                    return;
                }
                Process.Start(dstName);
            }

        }

        /// <summary>
        /// 泰国机票报表专用，需要传入一个list
        /// </summary>
        /// <param name="listWait4Replace"></param>
        public void Generate2(List<string> listWait4Replace, List<Model.VisaInfo> visainfos)
        {
            if (listWait4Replace.Count > PlaceHolderNum)
            {
                MessageBoxEx.Show("数据量多余所选模板占位符数量:" + PlaceHolderNum);
                return;
            }


            string dstName = GlobalUtils.ShowSaveFileDlg(DefaultName, "Word文档|*.docx");

            // If the file name is not an empty string open it for saving.
            if (!string.IsNullOrEmpty(dstName))
            {
                if (!DocXHandler.BatchReplaceStringByPlaceHolderAndUseList(GlobalUtils.AppPath + @"\Word\Templates\" + TemplaceDocFileName, dstName, listWait4Replace, true, PlaceHolderNum, visainfos))
                {
                    MessageBoxEx.Show("生成报表失败，请联系技术人员!");
                    return;
                }
                Process.Start(dstName);
            }

        }


        public void GenerateBatch(List<List<string>> listListWait4Replace, string outFolder)
        {
            int success = 0;
            for (int i = 0; i < listListWait4Replace.Count; i++)
            {
                List<string> listWait4Replace = listListWait4Replace[i];
                if (listWait4Replace.Count > PlaceHolderNum)
                {
                    MessageBoxEx.Show("数据量多余所选模板占位符数量:" + PlaceHolderNum + "\n,将跳过当前文档.");
                    continue;
                }


                if (!DocXHandler.BatchReplaceStringByPlaceHolder(GlobalUtils.AppPath + @"\Word\Templates\" + TemplaceDocFileName,
                    outFolder + @"\" + Path.GetFileNameWithoutExtension(DefaultName) + "_" + i + ".docx",
                    listWait4Replace, true, PlaceHolderNum))
                {
                    MessageBoxEx.Show("生成报表失败，请联系技术人员!");
                    continue;
                }
                ++success;
            }
            if (
                MessageBoxEx.Show("成功保存报表:" + success + "份，失败:" + (listListWait4Replace.Count - success) + "份.\n是否打开所在文件夹?", "提示",
                    MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            Process.Start(outFolder);
        }




    }
}
