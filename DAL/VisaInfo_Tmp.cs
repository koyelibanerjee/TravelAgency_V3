using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace TravelAgency.DAL  
{
	 	//VisaInfo_Tmp
		public partial class VisaInfo_Tmp
	{
   		     
		public bool Exists(Guid VisaInfo_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from VisaInfo_Tmp");
			strSql.Append(" where ");
			                                       strSql.Append(" VisaInfo_id = @VisaInfo_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@VisaInfo_id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = VisaInfo_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据,整形自增长返回id,guid返回parameters[0].Value,string返回true or false
		/// </summary>
		      public Guid Add(TravelAgency.Model.VisaInfo_Tmp model)
    		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VisaInfo_Tmp(");			
            strSql.Append("VisaInfo_id,Name,EnglishName,Sex,Birthday,PassportNo,LicenceTime,ExpiryDate,Birthplace,IssuePlace,Types,Country,IssuePlaceEnglish,BirthPlaceEnglish,HasChecked,CheckPerson,EntryTime,District");
			strSql.Append(") values (");
            strSql.Append("@VisaInfo_id,@Name,@EnglishName,@Sex,@Birthday,@PassportNo,@LicenceTime,@ExpiryDate,@Birthplace,@IssuePlace,@Types,@Country,@IssuePlaceEnglish,@BirthPlaceEnglish,@HasChecked,@CheckPerson,@EntryTime,@District");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@VisaInfo_id", SqlDbType.UniqueIdentifier,16) ,            
                        new SqlParameter("@Name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@EnglishName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Sex", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Birthday", SqlDbType.DateTime,3) ,            
                        new SqlParameter("@PassportNo", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@LicenceTime", SqlDbType.DateTime,3) ,            
                        new SqlParameter("@ExpiryDate", SqlDbType.DateTime,3) ,            
                        new SqlParameter("@Birthplace", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@IssuePlace", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Types", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Country", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@IssuePlaceEnglish", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@BirthPlaceEnglish", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@HasChecked", SqlDbType.VarChar,2) ,            
                        new SqlParameter("@CheckPerson", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@EntryTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@District", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = Guid.NewGuid();                        
            parameters[1].Value = model.Name;                        
            parameters[2].Value = model.EnglishName;                        
            parameters[3].Value = model.Sex;                        
            parameters[4].Value = model.Birthday;                        
            parameters[5].Value = model.PassportNo;                        
            parameters[6].Value = model.LicenceTime;                        
            parameters[7].Value = model.ExpiryDate;                        
            parameters[8].Value = model.Birthplace;                        
            parameters[9].Value = model.IssuePlace;                        
            parameters[10].Value = model.Types;                        
            parameters[11].Value = model.Country;                        
            parameters[12].Value = model.IssuePlaceEnglish;                        
            parameters[13].Value = model.BirthPlaceEnglish;                        
            parameters[14].Value = model.HasChecked;                        
            parameters[15].Value = model.CheckPerson;                        
            parameters[16].Value = model.EntryTime;                        
            parameters[17].Value = model.District;                        
			      int rows = DbHelperSQL.ExecuteSql(strSql.ToString(),parameters); 
      if(rows > 0)
      {
        return (Guid)(parameters[0].Value);
      }
      else
      {
          return Guid.Empty;
      }
      			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(TravelAgency.Model.VisaInfo_Tmp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VisaInfo_Tmp set ");
			                        
            strSql.Append(" VisaInfo_id = @VisaInfo_id , ");                                    
            strSql.Append(" Name = @Name , ");                                    
            strSql.Append(" EnglishName = @EnglishName , ");                                    
            strSql.Append(" Sex = @Sex , ");                                    
            strSql.Append(" Birthday = @Birthday , ");                                    
            strSql.Append(" PassportNo = @PassportNo , ");                                    
            strSql.Append(" LicenceTime = @LicenceTime , ");                                    
            strSql.Append(" ExpiryDate = @ExpiryDate , ");                                    
            strSql.Append(" Birthplace = @Birthplace , ");                                    
            strSql.Append(" IssuePlace = @IssuePlace , ");                                    
            strSql.Append(" Types = @Types , ");                                    
            strSql.Append(" Country = @Country , ");                                    
            strSql.Append(" IssuePlaceEnglish = @IssuePlaceEnglish , ");                                    
            strSql.Append(" BirthPlaceEnglish = @BirthPlaceEnglish , ");                                    
            strSql.Append(" HasChecked = @HasChecked , ");                                    
            strSql.Append(" CheckPerson = @CheckPerson , ");                                    
            strSql.Append(" EntryTime = @EntryTime , ");                                    
            strSql.Append(" District = @District  ");            			
			strSql.Append(" where VisaInfo_id=@VisaInfo_id  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@VisaInfo_id", SqlDbType.UniqueIdentifier,16) ,            
                        new SqlParameter("@Name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@EnglishName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Sex", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Birthday", SqlDbType.DateTime,3) ,            
                        new SqlParameter("@PassportNo", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@LicenceTime", SqlDbType.DateTime,3) ,            
                        new SqlParameter("@ExpiryDate", SqlDbType.DateTime,3) ,            
                        new SqlParameter("@Birthplace", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@IssuePlace", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Types", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Country", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@IssuePlaceEnglish", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@BirthPlaceEnglish", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@HasChecked", SqlDbType.VarChar,2) ,            
                        new SqlParameter("@CheckPerson", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@EntryTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@District", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.VisaInfo_id;                        
            parameters[1].Value = model.Name;                        
            parameters[2].Value = model.EnglishName;                        
            parameters[3].Value = model.Sex;                        
            parameters[4].Value = model.Birthday;                        
            parameters[5].Value = model.PassportNo;                        
            parameters[6].Value = model.LicenceTime;                        
            parameters[7].Value = model.ExpiryDate;                        
            parameters[8].Value = model.Birthplace;                        
            parameters[9].Value = model.IssuePlace;                        
            parameters[10].Value = model.Types;                        
            parameters[11].Value = model.Country;                        
            parameters[12].Value = model.IssuePlaceEnglish;                        
            parameters[13].Value = model.BirthPlaceEnglish;                        
            parameters[14].Value = model.HasChecked;                        
            parameters[15].Value = model.CheckPerson;                        
            parameters[16].Value = model.EntryTime;                        
            parameters[17].Value = model.District;                        
            int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(Guid VisaInfo_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VisaInfo_Tmp ");
			strSql.Append(" where VisaInfo_id=@VisaInfo_id ");
						SqlParameter[] parameters = {
					new SqlParameter("@VisaInfo_id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = VisaInfo_id;


			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string VisaInfo_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VisaInfo_Tmp ");
			strSql.Append(" where VisaInfo_id in ("+VisaInfo_idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
				
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TravelAgency.Model.VisaInfo_Tmp GetModel(Guid VisaInfo_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select VisaInfo_id, Name, EnglishName, Sex, Birthday, PassportNo, LicenceTime, ExpiryDate, Birthplace, IssuePlace, Types, Country, IssuePlaceEnglish, BirthPlaceEnglish, HasChecked, CheckPerson, EntryTime, District  ");			
			strSql.Append("  from VisaInfo_Tmp ");
			strSql.Append(" where VisaInfo_id=@VisaInfo_id ");
						SqlParameter[] parameters = {
					new SqlParameter("@VisaInfo_id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = VisaInfo_id;

			
			TravelAgency.Model.VisaInfo_Tmp model=new TravelAgency.Model.VisaInfo_Tmp();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}
		
		
		/// <summary>
		/// DataRow to Object Model
		/// </summary>
		public TravelAgency.Model.VisaInfo_Tmp DataRowToModel(DataRow row)
		{
			TravelAgency.Model.VisaInfo_Tmp model=new TravelAgency.Model.VisaInfo_Tmp();
			if(row != null)
			{
																								if(row["VisaInfo_id"]!=null && row["VisaInfo_id"].ToString()!="")
				{
					model.VisaInfo_id= new Guid(row["VisaInfo_id"].ToString());
				}
																								if(row["Name"]!=null && row["Name"].ToString()!="")
				{
					model.Name= row["Name"].ToString();
				}
																																if(row["EnglishName"]!=null && row["EnglishName"].ToString()!="")
				{
					model.EnglishName= row["EnglishName"].ToString();
				}
																																if(row["Sex"]!=null && row["Sex"].ToString()!="")
				{
					model.Sex= row["Sex"].ToString();
				}
																												if(row["Birthday"]!=null && row["Birthday"].ToString()!="")
				{
					model.Birthday=DateTime.Parse(row["Birthday"].ToString());
				}
																																				if(row["PassportNo"]!=null && row["PassportNo"].ToString()!="")
				{
					model.PassportNo= row["PassportNo"].ToString();
				}
																												if(row["LicenceTime"]!=null && row["LicenceTime"].ToString()!="")
				{
					model.LicenceTime=DateTime.Parse(row["LicenceTime"].ToString());
				}
																																if(row["ExpiryDate"]!=null && row["ExpiryDate"].ToString()!="")
				{
					model.ExpiryDate=DateTime.Parse(row["ExpiryDate"].ToString());
				}
																																				if(row["Birthplace"]!=null && row["Birthplace"].ToString()!="")
				{
					model.Birthplace= row["Birthplace"].ToString();
				}
																																if(row["IssuePlace"]!=null && row["IssuePlace"].ToString()!="")
				{
					model.IssuePlace= row["IssuePlace"].ToString();
				}
																																if(row["Types"]!=null && row["Types"].ToString()!="")
				{
					model.Types= row["Types"].ToString();
				}
																																if(row["Country"]!=null && row["Country"].ToString()!="")
				{
					model.Country= row["Country"].ToString();
				}
																																if(row["IssuePlaceEnglish"]!=null && row["IssuePlaceEnglish"].ToString()!="")
				{
					model.IssuePlaceEnglish= row["IssuePlaceEnglish"].ToString();
				}
																																if(row["BirthPlaceEnglish"]!=null && row["BirthPlaceEnglish"].ToString()!="")
				{
					model.BirthPlaceEnglish= row["BirthPlaceEnglish"].ToString();
				}
																																if(row["HasChecked"]!=null && row["HasChecked"].ToString()!="")
				{
					model.HasChecked= row["HasChecked"].ToString();
				}
																																if(row["CheckPerson"]!=null && row["CheckPerson"].ToString()!="")
				{
					model.CheckPerson= row["CheckPerson"].ToString();
				}
																												if(row["EntryTime"]!=null && row["EntryTime"].ToString()!="")
				{
					model.EntryTime=DateTime.Parse(row["EntryTime"].ToString());
				}
																																if(row["District"]!=null && row["District"].ToString()!="")
				{
					model.District=int.Parse(row["District"].ToString());
				}
																														
				return model;
			}
			else
			{
				return null;
			}
		}
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return GetList(0,strWhere,"");
		}
		
		/// <summary>
		/// 获得前几行数据,top=0则是全部数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" VisaInfo_id, Name, EnglishName, Sex, Birthday, PassportNo, LicenceTime, ExpiryDate, Birthplace, IssuePlace, Types, Country, IssuePlaceEnglish, BirthPlaceEnglish, HasChecked, CheckPerson, EntryTime, District  ");
			strSql.Append(" FROM VisaInfo_Tmp ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
      if(filedOrder.Trim()!="")
			{
        strSql.Append(" order by " + filedOrder);
      }
			return DbHelperSQL.Query(strSql.ToString());
		}
		
		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM VisaInfo_Tmp ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		
		
		/// <summary>
		/// 分页获取数据列表,orderby 必须传(要自己带desc)
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select VisaInfo_id, Name, EnglishName, Sex, Birthday, PassportNo, LicenceTime, ExpiryDate, Birthplace, IssuePlace, Types, Country, IssuePlaceEnglish, BirthPlaceEnglish, HasChecked, CheckPerson, EntryTime, District  ");
			
			strSql.Append(" FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			strSql.Append(")AS Row, T.*  from VisaInfo_Tmp T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}
	}
}

