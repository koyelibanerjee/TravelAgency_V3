using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using .Model;
namespace .BLL  
{
	 	//visa_copy
		public partial class visa_copy
	{
   		     
		private readonly .DAL.visa_copy dal=new .DAL.visa_copy();
		public visa_copy()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid Visa_id)
		{
			return dal.Exists(Visa_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(.Model.visa_copy model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(.Model.visa_copy model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(Guid Visa_id)
		{
			
			return dal.Delete(Visa_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public .Model.visa_copy GetModel(Guid Visa_id)
		{
			
			return dal.GetModel(Visa_id);
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
		public List<.Model.visa_copy> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<.Model.visa_copy> DataTableToList(DataTable dt)
		{
			List<.Model.visa_copy> modelList = new List<.Model.visa_copy>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				.Model.visa_copy model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new .Model.visa_copy();					
																									if(dt.Rows[n]["Visa_id"].ToString()!="")
				{
					model.Visa_id= dt.Rows[n]["Visa_id"].ToString();
				}
																								model.GroupNo= dt.Rows[n]["GroupNo"].ToString();
																																model.Name= dt.Rows[n]["Name"].ToString();
																																model.Types= dt.Rows[n]["Types"].ToString();
																																model.Tips= dt.Rows[n]["Tips"].ToString();
																												if(dt.Rows[n]["PredictTime"].ToString()!="")
				{
					model.PredictTime=DateTime.Parse(dt.Rows[n]["PredictTime"].ToString());
				}
																																if(dt.Rows[n]["RealTime"].ToString()!="")
				{
					model.RealTime=DateTime.Parse(dt.Rows[n]["RealTime"].ToString());
				}
																																if(dt.Rows[n]["FinishTime"].ToString()!="")
				{
					model.FinishTime=DateTime.Parse(dt.Rows[n]["FinishTime"].ToString());
				}
																																				model.Satus= dt.Rows[n]["Satus"].ToString();
																																model.Person= dt.Rows[n]["Person"].ToString();
																												if(dt.Rows[n]["Number"].ToString()!="")
				{
					model.Number=int.Parse(dt.Rows[n]["Number"].ToString());
				}
																																if(dt.Rows[n]["Picture"].ToString()!="")
				{
					model.Picture=decimal.Parse(dt.Rows[n]["Picture"].ToString());
				}
																																if(dt.Rows[n]["ListCount"].ToString()!="")
				{
					model.ListCount=decimal.Parse(dt.Rows[n]["ListCount"].ToString());
				}
																																				model.List= dt.Rows[n]["List"].ToString();
																																model.SalesPerson= dt.Rows[n]["SalesPerson"].ToString();
																												if(dt.Rows[n]["Receipt"].ToString()!="")
				{
					model.Receipt=decimal.Parse(dt.Rows[n]["Receipt"].ToString());
				}
																																if(dt.Rows[n]["Quidco"].ToString()!="")
				{
					model.Quidco=decimal.Parse(dt.Rows[n]["Quidco"].ToString());
				}
																																if(dt.Rows[n]["Cost"].ToString()!="")
				{
					model.Cost=decimal.Parse(dt.Rows[n]["Cost"].ToString());
				}
																																if(dt.Rows[n]["OtherCost"].ToString()!="")
				{
					model.OtherCost=decimal.Parse(dt.Rows[n]["OtherCost"].ToString());
				}
																																				model.ExpressNo= dt.Rows[n]["ExpressNo"].ToString();
																																model.Call= dt.Rows[n]["Call"].ToString();
																																								if(dt.Rows[n]["Sale_id"].ToString()!="")
				{
					model.Sale_id= dt.Rows[n]["Sale_id"].ToString();
				}
																																if(dt.Rows[n]["DepartmentId"].ToString()!="")
				{
					model.DepartmentId= dt.Rows[n]["DepartmentId"].ToString();
				}
																				if(dt.Rows[n]["EntryTime"].ToString()!="")
				{
					model.EntryTime=DateTime.Parse(dt.Rows[n]["EntryTime"].ToString());
				}
																																				model.Country= dt.Rows[n]["Country"].ToString();
																																model.Passengers= dt.Rows[n]["Passengers"].ToString();
																																model.WorkId= dt.Rows[n]["WorkId"].ToString();
																																model.Documenter= dt.Rows[n]["Documenter"].ToString();
																												if(dt.Rows[n]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(dt.Rows[n]["Price"].ToString());
				}
																																if(dt.Rows[n]["ConsulateCost"].ToString()!="")
				{
					model.ConsulateCost=decimal.Parse(dt.Rows[n]["ConsulateCost"].ToString());
				}
																																if(dt.Rows[n]["VisaPersonCost"].ToString()!="")
				{
					model.VisaPersonCost=decimal.Parse(dt.Rows[n]["VisaPersonCost"].ToString());
				}
																																if(dt.Rows[n]["MailCost"].ToString()!="")
				{
					model.MailCost=decimal.Parse(dt.Rows[n]["MailCost"].ToString());
				}
																																				model.Tips2= dt.Rows[n]["Tips2"].ToString();
																												if(dt.Rows[n]["SubmitFlag"].ToString()!="")
				{
					model.SubmitFlag=int.Parse(dt.Rows[n]["SubmitFlag"].ToString());
				}
																																if(dt.Rows[n]["GroupPrice"].ToString()!="")
				{
					model.GroupPrice=decimal.Parse(dt.Rows[n]["GroupPrice"].ToString());
				}
																																if(dt.Rows[n]["InvitationCost"].ToString()!="")
				{
					model.InvitationCost=decimal.Parse(dt.Rows[n]["InvitationCost"].ToString());
				}
																																				model.Remark= dt.Rows[n]["Remark"].ToString();
																												if(dt.Rows[n]["SubmitTime"].ToString()!="")
				{
					model.SubmitTime=DateTime.Parse(dt.Rows[n]["SubmitTime"].ToString());
				}
																																if(dt.Rows[n]["InTime"].ToString()!="")
				{
					model.InTime=DateTime.Parse(dt.Rows[n]["InTime"].ToString());
				}
																																if(dt.Rows[n]["OutTime"].ToString()!="")
				{
					model.OutTime=DateTime.Parse(dt.Rows[n]["OutTime"].ToString());
				}
																																				model.client= dt.Rows[n]["client"].ToString();
																																model.DepartureType= dt.Rows[n]["DepartureType"].ToString();
																																model.SubmitCondition= dt.Rows[n]["SubmitCondition"].ToString();
																																model.FetchCondition= dt.Rows[n]["FetchCondition"].ToString();
																																model.TypeInPerson= dt.Rows[n]["TypeInPerson"].ToString();
																																model.CheckPerson= dt.Rows[n]["CheckPerson"].ToString();
																																												if(dt.Rows[n]["IsUrgent"].ToString()!="")
				{
					if((dt.Rows[n]["IsUrgent"].ToString()=="1")||(dt.Rows[n]["IsUrgent"].ToString().ToLower()=="true"))
					{
					model.IsUrgent= true;
					}
					else
					{
					model.IsUrgent= false;
					}
				}
																				model.PeiQianYuan= dt.Rows[n]["PeiQianYuan"].ToString();
																																model.QuQianYuan= dt.Rows[n]["QuQianYuan"].ToString();
																																model.Operator= dt.Rows[n]["Operator"].ToString();
																						
				
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