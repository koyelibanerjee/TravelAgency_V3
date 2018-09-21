using System;
using System.Drawing;

namespace TravelAgency.Model
{
    /// <summary>
    /// CustomerBalance:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class CustomerBalance_AuthUser
    {
        public CustomerBalance_AuthUser()
        { }
        #region Model
        private Guid _balanceId;
        private string _customername;
        private decimal _amount;
        private decimal _balanceamount;
        private string _username;
        private DateTime _entrytime = DateTime.Now;
        private string _moneytype;
        private string _activityname;

        public Guid BalanceId
        {
            get { return _balanceId;}
            set { _balanceId = value; }
        }

        public string ActivityName
        {
            get { return _activityname;}
            set { _activityname = value; }
        }

        /// <summary>
        /// 主键
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName
        {
            set { _customername = value; }
            get { return _customername; }
        }
        /// <summary>
        /// 客户电话
        /// </summary>
      
        /// 财务到账金额
        /// </summary>
        public decimal Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 认领后的余额
        /// </summary>
        public decimal BalanceAmount
        {
            set { _balanceamount = value; }
            get { return _balanceamount; }
        }
        /// <summary>
        /// 1表示认领完,0表示未认领
        /// </summary>
       
        /// <summary>
        /// 员工从财务表认领的操作员工号
        /// </summary>
      
        /// <summary>
        /// 
        /// </summary>
        public DateTime EntryTime
        {
            set { _entrytime = value; }
            get { return _entrytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MoneyType
        {
            set { _moneytype = value; }
            get { return _moneytype; }
        }
        #endregion Model

    }
}

