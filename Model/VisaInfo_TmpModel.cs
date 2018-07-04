using System;
using System.CodeDom;
using System.Reflection;

namespace TravelAgency.Model
{
    public partial class VisaInfo_Tmp
    {
        public void CopyToVisaInfo(VisaInfo model)
        {
            model.VisaInfo_id = this.VisaInfo_id;

            //签证扫描仪拿到的部分
            model.Name = this.Name;
            model.EnglishName = this.EnglishName;
            model.Sex = this.Sex;
            model.Birthday = this.Birthday;
            model.PassportNo = this.PassportNo;
            model.LicenceTime = this.LicenceTime;
            model.ExpiryDate = this.ExpiryDate;
            model.Birthplace = this.Birthplace;
            model.IssuePlace = this.IssuePlace;
            model.BirthPlaceEnglish = this.BirthPlaceEnglish;
            model.IssuePlaceEnglish = this.IssuePlaceEnglish;

            //可能会设置的部分
            model.Types = this.Types;
            model.Country = this.Country;
            model.HasChecked = this.HasChecked;
            model.CheckPerson = this.CheckPerson;
            model.EntryTime = this.EntryTime;
        }
    }
}