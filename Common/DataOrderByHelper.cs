using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency.Common
{
    public class DataOrderByHelper
    {
        //private Dictionary<string, string> _orderByDict = new Dictionary<string, string>(); //cb的值,实际列名
        //private Dictionary<string, string> _orderDict = new Dictionary<string, string>();

        private List<string> _cbValues = new List<string>();
        private List<string> _tbValues = new List<string>();
        private Action _updateDel;


        public DataOrderByHelper(List<string> cbvalues, List<string> tbvalues, ComboBoxItem cbOrderBy, ComboBoxItem cbOrder ,Action del)
        {
            if (cbvalues.Count != tbvalues.Count)
            {
                throw new Exception("键值对数目不一致!!!");
            }
            this._cbValues = cbvalues;
            this._tbValues = tbvalues;

            InitCommboBox( cbOrderBy,  cbOrder);
            _updateDel = del;
        }


        private void InitCommboBox(ComboBoxItem cbOrderBy,ComboBoxItem cbOrder)
        {
            cbOrderBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbOrder.DropDownStyle = ComboBoxStyle.DropDownList;
            cbOrderBy.Items.Clear();
            cbOrder.Items.Clear();

            foreach (var item in _cbValues)
                cbOrderBy.Items.Add(item);

            cbOrder.Items.Add("降序");
            cbOrder.Items.Add("升序");

            cbOrderBy.SelectedIndex = 0;
            cbOrder.SelectedIndex = 0;

            cbOrderBy.SelectedIndexChanged += OrderChanged;
            cbOrder.SelectedIndexChanged += OrderChanged;

        }

        private void OrderChanged(object sender, EventArgs e)
        {
            _updateDel();
        }

        public string GetOrderByCondition(ComboBoxItem cbOrderBy, ComboBoxItem cbOrder)
        {
            int idx = _cbValues.IndexOf(cbOrderBy.Text);
            string order = cbOrder.Text == "升序" ? " asc" : " desc";
            return _tbValues[idx] + order;
        }



    }
}
