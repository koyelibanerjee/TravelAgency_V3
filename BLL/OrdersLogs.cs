using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using .Model;
namespace .BLL  
{
	 	//OrdersLogs
		public partial class OrdersLogs
	{
   		     
		private readonly .DAL.OrdersLogs dal=new .DAL.OrdersLogs();
		public OrdersLogs()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(.Model.OrdersLogs model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(.Model.OrdersLogs model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public .Model.OrdersLogs GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<.Model.OrdersLogs> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<.Model.OrdersLogs> DataTableToList(DataTable dt)
		{
			List<.Model.OrdersLogs> modelList = new List<.Model.OrdersLogs>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				.Model.OrdersLogs model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new .Model.OrdersLogs();					
													if(dt.Rows[n]["id"].ToString()!="")
				{
					model.id=int.Parse(dt.Rows[n]["id"].ToString());
				}
																																if(dt.Rows[n]["ActType"].ToString()!="")
				{
					model.ActType=int.Parse(dt.Rows[n]["ActType"].ToString());
				}
																																				model.UserName= dt.Rows[n]["UserName"].ToString();
																												if(dt.Rows[n]["OrdersId"].ToString()!="")
				{
					model.OrdersId=int.Parse(dt.Rows[n]["OrdersId"].ToString());
				}
																																if(dt.Rows[n]["EntryTime"].ToString()!="")
				{
					model.EntryTime=DateTime.Parse(dt.Rows[n]["EntryTime"].ToString());
				}
																																				model.WorkId= dt.Rows[n]["WorkId"].ToString();
																																model.OrderNo= dt.Rows[n]["OrderNo"].ToString();
																						
				
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
#endregion
   
	}
}