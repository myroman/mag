﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mag.Business
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Mag")]
	public partial class DataContextDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InserttbSale(tbSale instance);
    partial void UpdatetbSale(tbSale instance);
    partial void DeletetbSale(tbSale instance);
    partial void InserttbInsuranceType(tbInsuranceType instance);
    partial void UpdatetbInsuranceType(tbInsuranceType instance);
    partial void DeletetbInsuranceType(tbInsuranceType instance);
    partial void InserttbAgent(tbAgent instance);
    partial void UpdatetbAgent(tbAgent instance);
    partial void DeletetbAgent(tbAgent instance);
    #endregion
		
		public DataContextDataContext() : 
				base(global::Mag.Business.Properties.Settings.Default.MagConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataContextDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataContextDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataContextDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataContextDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tbSale> tbSales
		{
			get
			{
				return this.GetTable<tbSale>();
			}
		}
		
		public System.Data.Linq.Table<tbInsuranceType> tbInsuranceTypes
		{
			get
			{
				return this.GetTable<tbInsuranceType>();
			}
		}
		
		public System.Data.Linq.Table<tbAgent> tbAgents
		{
			get
			{
				return this.GetTable<tbAgent>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbSales")]
	public partial class tbSale : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _agentId;
		
		private string _reportCode;
		
		private System.DateTime _createDate;
		
		private int _insuranceTypeId;
		
		private System.Nullable<int> _contractsNumber;
		
		private double _premium;
		
		private System.Nullable<int> _paymentsNumber;
		
		private double _paidSum;
		
		private double _feePercent;
		
		private string _comment;
		
		private System.Nullable<double> _addFeePercent;
		
		private EntityRef<tbInsuranceType> _tbInsuranceType;
		
		private EntityRef<tbAgent> _tbAgent;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnagentIdChanging(int value);
    partial void OnagentIdChanged();
    partial void OnreportCodeChanging(string value);
    partial void OnreportCodeChanged();
    partial void OncreateDateChanging(System.DateTime value);
    partial void OncreateDateChanged();
    partial void OninsuranceTypeIdChanging(int value);
    partial void OninsuranceTypeIdChanged();
    partial void OncontractsNumberChanging(System.Nullable<int> value);
    partial void OncontractsNumberChanged();
    partial void OnpremiumChanging(double value);
    partial void OnpremiumChanged();
    partial void OnpaymentsNumberChanging(System.Nullable<int> value);
    partial void OnpaymentsNumberChanged();
    partial void OnpaidSumChanging(double value);
    partial void OnpaidSumChanged();
    partial void OnfeePercentChanging(double value);
    partial void OnfeePercentChanged();
    partial void OncommentChanging(string value);
    partial void OncommentChanged();
    partial void OnaddFeePercentChanging(System.Nullable<double> value);
    partial void OnaddFeePercentChanged();
    #endregion
		
		public tbSale()
		{
			this._tbInsuranceType = default(EntityRef<tbInsuranceType>);
			this._tbAgent = default(EntityRef<tbAgent>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_agentId", DbType="Int NOT NULL")]
		public int agentId
		{
			get
			{
				return this._agentId;
			}
			set
			{
				if ((this._agentId != value))
				{
					if (this._tbAgent.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnagentIdChanging(value);
					this.SendPropertyChanging();
					this._agentId = value;
					this.SendPropertyChanged("agentId");
					this.OnagentIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_reportCode", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string reportCode
		{
			get
			{
				return this._reportCode;
			}
			set
			{
				if ((this._reportCode != value))
				{
					this.OnreportCodeChanging(value);
					this.SendPropertyChanging();
					this._reportCode = value;
					this.SendPropertyChanged("reportCode");
					this.OnreportCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_createDate", DbType="DateTime NOT NULL")]
		public System.DateTime createDate
		{
			get
			{
				return this._createDate;
			}
			set
			{
				if ((this._createDate != value))
				{
					this.OncreateDateChanging(value);
					this.SendPropertyChanging();
					this._createDate = value;
					this.SendPropertyChanged("createDate");
					this.OncreateDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_insuranceTypeId", DbType="Int NOT NULL")]
		public int insuranceTypeId
		{
			get
			{
				return this._insuranceTypeId;
			}
			set
			{
				if ((this._insuranceTypeId != value))
				{
					if (this._tbInsuranceType.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OninsuranceTypeIdChanging(value);
					this.SendPropertyChanging();
					this._insuranceTypeId = value;
					this.SendPropertyChanged("insuranceTypeId");
					this.OninsuranceTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_contractsNumber", DbType="Int")]
		public System.Nullable<int> contractsNumber
		{
			get
			{
				return this._contractsNumber;
			}
			set
			{
				if ((this._contractsNumber != value))
				{
					this.OncontractsNumberChanging(value);
					this.SendPropertyChanging();
					this._contractsNumber = value;
					this.SendPropertyChanged("contractsNumber");
					this.OncontractsNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_premium", DbType="Float NOT NULL")]
		public double premium
		{
			get
			{
				return this._premium;
			}
			set
			{
				if ((this._premium != value))
				{
					this.OnpremiumChanging(value);
					this.SendPropertyChanging();
					this._premium = value;
					this.SendPropertyChanged("premium");
					this.OnpremiumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_paymentsNumber", DbType="Int")]
		public System.Nullable<int> paymentsNumber
		{
			get
			{
				return this._paymentsNumber;
			}
			set
			{
				if ((this._paymentsNumber != value))
				{
					this.OnpaymentsNumberChanging(value);
					this.SendPropertyChanging();
					this._paymentsNumber = value;
					this.SendPropertyChanged("paymentsNumber");
					this.OnpaymentsNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_paidSum", DbType="Float NOT NULL")]
		public double paidSum
		{
			get
			{
				return this._paidSum;
			}
			set
			{
				if ((this._paidSum != value))
				{
					this.OnpaidSumChanging(value);
					this.SendPropertyChanging();
					this._paidSum = value;
					this.SendPropertyChanged("paidSum");
					this.OnpaidSumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_feePercent", DbType="Float NOT NULL")]
		public double feePercent
		{
			get
			{
				return this._feePercent;
			}
			set
			{
				if ((this._feePercent != value))
				{
					this.OnfeePercentChanging(value);
					this.SendPropertyChanging();
					this._feePercent = value;
					this.SendPropertyChanged("feePercent");
					this.OnfeePercentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_comment", DbType="VarChar(300)")]
		public string comment
		{
			get
			{
				return this._comment;
			}
			set
			{
				if ((this._comment != value))
				{
					this.OncommentChanging(value);
					this.SendPropertyChanging();
					this._comment = value;
					this.SendPropertyChanged("comment");
					this.OncommentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_addFeePercent", DbType="Float")]
		public System.Nullable<double> addFeePercent
		{
			get
			{
				return this._addFeePercent;
			}
			set
			{
				if ((this._addFeePercent != value))
				{
					this.OnaddFeePercentChanging(value);
					this.SendPropertyChanging();
					this._addFeePercent = value;
					this.SendPropertyChanged("addFeePercent");
					this.OnaddFeePercentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tbInsuranceType_tbSale", Storage="_tbInsuranceType", ThisKey="insuranceTypeId", OtherKey="id", IsForeignKey=true)]
		public tbInsuranceType tbInsuranceType
		{
			get
			{
				return this._tbInsuranceType.Entity;
			}
			set
			{
				tbInsuranceType previousValue = this._tbInsuranceType.Entity;
				if (((previousValue != value) 
							|| (this._tbInsuranceType.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tbInsuranceType.Entity = null;
						previousValue.tbSales.Remove(this);
					}
					this._tbInsuranceType.Entity = value;
					if ((value != null))
					{
						value.tbSales.Add(this);
						this._insuranceTypeId = value.id;
					}
					else
					{
						this._insuranceTypeId = default(int);
					}
					this.SendPropertyChanged("tbInsuranceType");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tbAgent_tbSale", Storage="_tbAgent", ThisKey="agentId", OtherKey="id", IsForeignKey=true)]
		public tbAgent tbAgent
		{
			get
			{
				return this._tbAgent.Entity;
			}
			set
			{
				tbAgent previousValue = this._tbAgent.Entity;
				if (((previousValue != value) 
							|| (this._tbAgent.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tbAgent.Entity = null;
						previousValue.tbSales.Remove(this);
					}
					this._tbAgent.Entity = value;
					if ((value != null))
					{
						value.tbSales.Add(this);
						this._agentId = value.id;
					}
					else
					{
						this._agentId = default(int);
					}
					this.SendPropertyChanged("tbAgent");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbInsuranceTypes")]
	public partial class tbInsuranceType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private EntitySet<tbSale> _tbSales;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    #endregion
		
		public tbInsuranceType()
		{
			this._tbSales = new EntitySet<tbSale>(new Action<tbSale>(this.attach_tbSales), new Action<tbSale>(this.detach_tbSales));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tbInsuranceType_tbSale", Storage="_tbSales", ThisKey="id", OtherKey="insuranceTypeId")]
		public EntitySet<tbSale> tbSales
		{
			get
			{
				return this._tbSales;
			}
			set
			{
				this._tbSales.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_tbSales(tbSale entity)
		{
			this.SendPropertyChanging();
			entity.tbInsuranceType = this;
		}
		
		private void detach_tbSales(tbSale entity)
		{
			this.SendPropertyChanging();
			entity.tbInsuranceType = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbAgents")]
	public partial class tbAgent : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _email;
		
		private string _passwordHash;
		
		private System.DateTime _regDate;
		
		private string _fullName;
		
		private System.Nullable<bool> _isAdmin;
		
		private EntitySet<tbSale> _tbSales;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OnpasswordHashChanging(string value);
    partial void OnpasswordHashChanged();
    partial void OnregDateChanging(System.DateTime value);
    partial void OnregDateChanged();
    partial void OnfullNameChanging(string value);
    partial void OnfullNameChanged();
    partial void OnisAdminChanging(System.Nullable<bool> value);
    partial void OnisAdminChanged();
    #endregion
		
		public tbAgent()
		{
			this._tbSales = new EntitySet<tbSale>(new Action<tbSale>(this.attach_tbSales), new Action<tbSale>(this.detach_tbSales));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="VarChar(60) NOT NULL", CanBeNull=false)]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_passwordHash", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string passwordHash
		{
			get
			{
				return this._passwordHash;
			}
			set
			{
				if ((this._passwordHash != value))
				{
					this.OnpasswordHashChanging(value);
					this.SendPropertyChanging();
					this._passwordHash = value;
					this.SendPropertyChanged("passwordHash");
					this.OnpasswordHashChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_regDate", DbType="DateTime NOT NULL")]
		public System.DateTime regDate
		{
			get
			{
				return this._regDate;
			}
			set
			{
				if ((this._regDate != value))
				{
					this.OnregDateChanging(value);
					this.SendPropertyChanging();
					this._regDate = value;
					this.SendPropertyChanged("regDate");
					this.OnregDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fullName", DbType="VarChar(400) NOT NULL", CanBeNull=false)]
		public string fullName
		{
			get
			{
				return this._fullName;
			}
			set
			{
				if ((this._fullName != value))
				{
					this.OnfullNameChanging(value);
					this.SendPropertyChanging();
					this._fullName = value;
					this.SendPropertyChanged("fullName");
					this.OnfullNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isAdmin", DbType="Bit")]
		public System.Nullable<bool> isAdmin
		{
			get
			{
				return this._isAdmin;
			}
			set
			{
				if ((this._isAdmin != value))
				{
					this.OnisAdminChanging(value);
					this.SendPropertyChanging();
					this._isAdmin = value;
					this.SendPropertyChanged("isAdmin");
					this.OnisAdminChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tbAgent_tbSale", Storage="_tbSales", ThisKey="id", OtherKey="agentId")]
		public EntitySet<tbSale> tbSales
		{
			get
			{
				return this._tbSales;
			}
			set
			{
				this._tbSales.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_tbSales(tbSale entity)
		{
			this.SendPropertyChanging();
			entity.tbAgent = this;
		}
		
		private void detach_tbSales(tbSale entity)
		{
			this.SendPropertyChanging();
			entity.tbAgent = null;
		}
	}
}
#pragma warning restore 1591
