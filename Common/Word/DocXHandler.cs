using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevComponents.DotNetBar;
using Xceed.Words.NET;

namespace TravelAgency.Common.Word
{
    public class DocXHandler
    {

        public static bool BatchReplaceStringByPlaceHolder(string tempFileName, string outFileName,
            List<string> wait4ReplaceList, bool removeRedundantPlaceHolder, int placeholdernum)
        {
            using (DocX document = DocX.Load(tempFileName))
            {
                for (int i = 0; i < placeholdernum; i++)
                {
                    string src = "{" + (i + 1) + "}";
                    string dst;

                    if (i >= wait4ReplaceList.Count && !removeRedundantPlaceHolder)
                        break;

                    if (i >= wait4ReplaceList.Count && removeRedundantPlaceHolder)
                        dst = "";
                    else
                        dst = wait4ReplaceList[i];

                    document.ReplaceText(src, dst);
                }
                try
                {
                    document.SaveAs(outFileName);

                }
                catch (Exception)
                {
                    MessageBoxEx.Show("保存失败，请检查文件是否占用中!");
                    return false;
                }
                
                return true;
            }
        }

        /// <summary>
        /// 泰国机票报表专用，需要生成一个list
        /// </summary>
        /// <param name="tempFileName"></param>
        /// <param name="outFileName"></param>
        /// <param name="wait4ReplaceList"></param>
        /// <param name="removeRedundantPlaceHolder"></param>
        /// <param name="placeholdernum"></param>
        /// <returns></returns>
        public static bool BatchReplaceStringByPlaceHolderAndUseList(string tempFileName, string outFileName,
    List<string> wait4ReplaceList, bool removeRedundantPlaceHolder, int placeholdernum, List<Model.VisaInfo> visainfos)
        {
            using (DocX document = DocX.Load(tempFileName))
            {
                for (int i = 0; i < placeholdernum; i++)
                {
                    string src = "{" + (i + 1) + "}";
                    string dst;

                    if (i >= wait4ReplaceList.Count && !removeRedundantPlaceHolder)
                        break;

                    if (i >= wait4ReplaceList.Count && removeRedundantPlaceHolder)
                        dst = "";
                    else
                        dst = wait4ReplaceList[i];

                    document.ReplaceText(src, dst);
                }
                AddJipiaoList(document, visainfos);
                document.SaveAs(outFileName);
                return true;
            }
        }

        public static void AddJipiaoList(DocX document, List<Model.VisaInfo> visainfos)
        {
            var numberedList = document.AddList(TextHandler.GetSpecialEnglishName(visainfos[0]), 0, ListItemType.Numbered, 1);
            for (int i = 1; i < visainfos.Count; i++)
            {
                document.AddListItem(numberedList, TextHandler.GetSpecialEnglishName(visainfos[i]));
            }
            document.InsertList(numberedList);
        }


    }
}
