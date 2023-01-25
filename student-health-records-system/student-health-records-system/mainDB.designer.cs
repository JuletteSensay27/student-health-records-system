﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace student_health_records_system
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Student_Health_Record_System")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Inserttable_activityLog(table_activityLog instance);
    partial void Updatetable_activityLog(table_activityLog instance);
    partial void Deletetable_activityLog(table_activityLog instance);
    partial void Inserttable_adminAccount(table_adminAccount instance);
    partial void Updatetable_adminAccount(table_adminAccount instance);
    partial void Deletetable_adminAccount(table_adminAccount instance);
    partial void Inserttable_studentFile(table_studentFile instance);
    partial void Updatetable_studentFile(table_studentFile instance);
    partial void Deletetable_studentFile(table_studentFile instance);
    partial void Inserttable_studentInfo(table_studentInfo instance);
    partial void Updatetable_studentInfo(table_studentInfo instance);
    partial void Deletetable_studentInfo(table_studentInfo instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::student_health_records_system.Properties.Settings.Default.Student_Health_Record_SystemConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<table_activityLog> table_activityLogs
		{
			get
			{
				return this.GetTable<table_activityLog>();
			}
		}
		
		public System.Data.Linq.Table<table_adminAccount> table_adminAccounts
		{
			get
			{
				return this.GetTable<table_adminAccount>();
			}
		}
		
		public System.Data.Linq.Table<table_studentFile> table_studentFiles
		{
			get
			{
				return this.GetTable<table_studentFile>();
			}
		}
		
		public System.Data.Linq.Table<table_studentInfo> table_studentInfos
		{
			get
			{
				return this.GetTable<table_studentInfo>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspRetrieveStudentFiles")]
		public ISingleResult<uspRetrieveStudentFilesResult> uspRetrieveStudentFiles([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(9)")] string studentID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), studentID);
			return ((ISingleResult<uspRetrieveStudentFilesResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspRetrieveStudentRecords")]
		public ISingleResult<uspRetrieveStudentRecordsResult> uspRetrieveStudentRecords([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(9)")] string studentID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), studentID);
			return ((ISingleResult<uspRetrieveStudentRecordsResult>)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.table_activityLogs")]
	public partial class table_activityLog : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _log_ID;
		
		private string _admin_ID;
		
		private string _log_activity;
		
		private string _student_ID;
		
		private System.DateTime _date_created;
		
		private EntityRef<table_adminAccount> _table_adminAccount;
		
		private EntityRef<table_studentInfo> _table_studentInfo;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onlog_IDChanging(string value);
    partial void Onlog_IDChanged();
    partial void Onadmin_IDChanging(string value);
    partial void Onadmin_IDChanged();
    partial void Onlog_activityChanging(string value);
    partial void Onlog_activityChanged();
    partial void Onstudent_IDChanging(string value);
    partial void Onstudent_IDChanged();
    partial void Ondate_createdChanging(System.DateTime value);
    partial void Ondate_createdChanged();
    #endregion
		
		public table_activityLog()
		{
			this._table_adminAccount = default(EntityRef<table_adminAccount>);
			this._table_studentInfo = default(EntityRef<table_studentInfo>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_log_ID", DbType="VarChar(9) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string log_ID
		{
			get
			{
				return this._log_ID;
			}
			set
			{
				if ((this._log_ID != value))
				{
					this.Onlog_IDChanging(value);
					this.SendPropertyChanging();
					this._log_ID = value;
					this.SendPropertyChanged("log_ID");
					this.Onlog_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_admin_ID", DbType="VarChar(5) NOT NULL", CanBeNull=false)]
		public string admin_ID
		{
			get
			{
				return this._admin_ID;
			}
			set
			{
				if ((this._admin_ID != value))
				{
					if (this._table_adminAccount.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onadmin_IDChanging(value);
					this.SendPropertyChanging();
					this._admin_ID = value;
					this.SendPropertyChanged("admin_ID");
					this.Onadmin_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_log_activity", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string log_activity
		{
			get
			{
				return this._log_activity;
			}
			set
			{
				if ((this._log_activity != value))
				{
					this.Onlog_activityChanging(value);
					this.SendPropertyChanging();
					this._log_activity = value;
					this.SendPropertyChanged("log_activity");
					this.Onlog_activityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_student_ID", DbType="VarChar(9) NOT NULL", CanBeNull=false)]
		public string student_ID
		{
			get
			{
				return this._student_ID;
			}
			set
			{
				if ((this._student_ID != value))
				{
					if (this._table_studentInfo.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onstudent_IDChanging(value);
					this.SendPropertyChanging();
					this._student_ID = value;
					this.SendPropertyChanged("student_ID");
					this.Onstudent_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date_created", DbType="DateTime NOT NULL")]
		public System.DateTime date_created
		{
			get
			{
				return this._date_created;
			}
			set
			{
				if ((this._date_created != value))
				{
					this.Ondate_createdChanging(value);
					this.SendPropertyChanging();
					this._date_created = value;
					this.SendPropertyChanged("date_created");
					this.Ondate_createdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="table_adminAccount_table_activityLog", Storage="_table_adminAccount", ThisKey="admin_ID", OtherKey="admin_ID", IsForeignKey=true)]
		public table_adminAccount table_adminAccount
		{
			get
			{
				return this._table_adminAccount.Entity;
			}
			set
			{
				table_adminAccount previousValue = this._table_adminAccount.Entity;
				if (((previousValue != value) 
							|| (this._table_adminAccount.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._table_adminAccount.Entity = null;
						previousValue.table_activityLogs.Remove(this);
					}
					this._table_adminAccount.Entity = value;
					if ((value != null))
					{
						value.table_activityLogs.Add(this);
						this._admin_ID = value.admin_ID;
					}
					else
					{
						this._admin_ID = default(string);
					}
					this.SendPropertyChanged("table_adminAccount");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="table_studentInfo_table_activityLog", Storage="_table_studentInfo", ThisKey="student_ID", OtherKey="student_ID", IsForeignKey=true)]
		public table_studentInfo table_studentInfo
		{
			get
			{
				return this._table_studentInfo.Entity;
			}
			set
			{
				table_studentInfo previousValue = this._table_studentInfo.Entity;
				if (((previousValue != value) 
							|| (this._table_studentInfo.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._table_studentInfo.Entity = null;
						previousValue.table_activityLogs.Remove(this);
					}
					this._table_studentInfo.Entity = value;
					if ((value != null))
					{
						value.table_activityLogs.Add(this);
						this._student_ID = value.student_ID;
					}
					else
					{
						this._student_ID = default(string);
					}
					this.SendPropertyChanged("table_studentInfo");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.table_adminAccounts")]
	public partial class table_adminAccount : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _admin_ID;
		
		private string _admin_firstName;
		
		private string _admin_middleName;
		
		private string _admin_lastName;
		
		private string _admin_phoneNum;
		
		private string _admin_email;
		
		private string _admin_department;
		
		private string _admin_access;
		
		private string _admin_status;
		
		private System.DateTime _date_created;
		
		private System.DateTime _date_modified;
		
		private EntitySet<table_activityLog> _table_activityLogs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onadmin_IDChanging(string value);
    partial void Onadmin_IDChanged();
    partial void Onadmin_firstNameChanging(string value);
    partial void Onadmin_firstNameChanged();
    partial void Onadmin_middleNameChanging(string value);
    partial void Onadmin_middleNameChanged();
    partial void Onadmin_lastNameChanging(string value);
    partial void Onadmin_lastNameChanged();
    partial void Onadmin_phoneNumChanging(string value);
    partial void Onadmin_phoneNumChanged();
    partial void Onadmin_emailChanging(string value);
    partial void Onadmin_emailChanged();
    partial void Onadmin_departmentChanging(string value);
    partial void Onadmin_departmentChanged();
    partial void Onadmin_accessChanging(string value);
    partial void Onadmin_accessChanged();
    partial void Onadmin_statusChanging(string value);
    partial void Onadmin_statusChanged();
    partial void Ondate_createdChanging(System.DateTime value);
    partial void Ondate_createdChanged();
    partial void Ondate_modifiedChanging(System.DateTime value);
    partial void Ondate_modifiedChanged();
    #endregion
		
		public table_adminAccount()
		{
			this._table_activityLogs = new EntitySet<table_activityLog>(new Action<table_activityLog>(this.attach_table_activityLogs), new Action<table_activityLog>(this.detach_table_activityLogs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_admin_ID", DbType="VarChar(5) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string admin_ID
		{
			get
			{
				return this._admin_ID;
			}
			set
			{
				if ((this._admin_ID != value))
				{
					this.Onadmin_IDChanging(value);
					this.SendPropertyChanging();
					this._admin_ID = value;
					this.SendPropertyChanged("admin_ID");
					this.Onadmin_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_admin_firstName", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string admin_firstName
		{
			get
			{
				return this._admin_firstName;
			}
			set
			{
				if ((this._admin_firstName != value))
				{
					this.Onadmin_firstNameChanging(value);
					this.SendPropertyChanging();
					this._admin_firstName = value;
					this.SendPropertyChanged("admin_firstName");
					this.Onadmin_firstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_admin_middleName", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string admin_middleName
		{
			get
			{
				return this._admin_middleName;
			}
			set
			{
				if ((this._admin_middleName != value))
				{
					this.Onadmin_middleNameChanging(value);
					this.SendPropertyChanging();
					this._admin_middleName = value;
					this.SendPropertyChanged("admin_middleName");
					this.Onadmin_middleNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_admin_lastName", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string admin_lastName
		{
			get
			{
				return this._admin_lastName;
			}
			set
			{
				if ((this._admin_lastName != value))
				{
					this.Onadmin_lastNameChanging(value);
					this.SendPropertyChanging();
					this._admin_lastName = value;
					this.SendPropertyChanged("admin_lastName");
					this.Onadmin_lastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_admin_phoneNum", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string admin_phoneNum
		{
			get
			{
				return this._admin_phoneNum;
			}
			set
			{
				if ((this._admin_phoneNum != value))
				{
					this.Onadmin_phoneNumChanging(value);
					this.SendPropertyChanging();
					this._admin_phoneNum = value;
					this.SendPropertyChanged("admin_phoneNum");
					this.Onadmin_phoneNumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_admin_email", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string admin_email
		{
			get
			{
				return this._admin_email;
			}
			set
			{
				if ((this._admin_email != value))
				{
					this.Onadmin_emailChanging(value);
					this.SendPropertyChanging();
					this._admin_email = value;
					this.SendPropertyChanged("admin_email");
					this.Onadmin_emailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_admin_department", DbType="VarChar(2) NOT NULL", CanBeNull=false)]
		public string admin_department
		{
			get
			{
				return this._admin_department;
			}
			set
			{
				if ((this._admin_department != value))
				{
					this.Onadmin_departmentChanging(value);
					this.SendPropertyChanging();
					this._admin_department = value;
					this.SendPropertyChanged("admin_department");
					this.Onadmin_departmentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_admin_access", DbType="VarChar(3) NOT NULL", CanBeNull=false)]
		public string admin_access
		{
			get
			{
				return this._admin_access;
			}
			set
			{
				if ((this._admin_access != value))
				{
					this.Onadmin_accessChanging(value);
					this.SendPropertyChanging();
					this._admin_access = value;
					this.SendPropertyChanged("admin_access");
					this.Onadmin_accessChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_admin_status", DbType="VarChar(3) NOT NULL", CanBeNull=false)]
		public string admin_status
		{
			get
			{
				return this._admin_status;
			}
			set
			{
				if ((this._admin_status != value))
				{
					this.Onadmin_statusChanging(value);
					this.SendPropertyChanging();
					this._admin_status = value;
					this.SendPropertyChanged("admin_status");
					this.Onadmin_statusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date_created", DbType="DateTime NOT NULL")]
		public System.DateTime date_created
		{
			get
			{
				return this._date_created;
			}
			set
			{
				if ((this._date_created != value))
				{
					this.Ondate_createdChanging(value);
					this.SendPropertyChanging();
					this._date_created = value;
					this.SendPropertyChanged("date_created");
					this.Ondate_createdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date_modified", DbType="DateTime NOT NULL")]
		public System.DateTime date_modified
		{
			get
			{
				return this._date_modified;
			}
			set
			{
				if ((this._date_modified != value))
				{
					this.Ondate_modifiedChanging(value);
					this.SendPropertyChanging();
					this._date_modified = value;
					this.SendPropertyChanged("date_modified");
					this.Ondate_modifiedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="table_adminAccount_table_activityLog", Storage="_table_activityLogs", ThisKey="admin_ID", OtherKey="admin_ID")]
		public EntitySet<table_activityLog> table_activityLogs
		{
			get
			{
				return this._table_activityLogs;
			}
			set
			{
				this._table_activityLogs.Assign(value);
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
		
		private void attach_table_activityLogs(table_activityLog entity)
		{
			this.SendPropertyChanging();
			entity.table_adminAccount = this;
		}
		
		private void detach_table_activityLogs(table_activityLog entity)
		{
			this.SendPropertyChanging();
			entity.table_adminAccount = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.table_studentFiles")]
	public partial class table_studentFile : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _stuFile_ID;
		
		private string _student_ID;
		
		private string _stuFile_name;
		
		private string _stuFile_fileType;
		
		private string _stuFile_recordType;
		
		private string _stuFile_location;
		
		private System.DateTime _date_created;
		
		private System.DateTime _date_modified;
		
		private EntityRef<table_studentInfo> _table_studentInfo;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnstuFile_IDChanging(string value);
    partial void OnstuFile_IDChanged();
    partial void Onstudent_IDChanging(string value);
    partial void Onstudent_IDChanged();
    partial void OnstuFile_nameChanging(string value);
    partial void OnstuFile_nameChanged();
    partial void OnstuFile_fileTypeChanging(string value);
    partial void OnstuFile_fileTypeChanged();
    partial void OnstuFile_recordTypeChanging(string value);
    partial void OnstuFile_recordTypeChanged();
    partial void OnstuFile_locationChanging(string value);
    partial void OnstuFile_locationChanged();
    partial void Ondate_createdChanging(System.DateTime value);
    partial void Ondate_createdChanged();
    partial void Ondate_modifiedChanging(System.DateTime value);
    partial void Ondate_modifiedChanged();
    #endregion
		
		public table_studentFile()
		{
			this._table_studentInfo = default(EntityRef<table_studentInfo>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_stuFile_ID", DbType="VarChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string stuFile_ID
		{
			get
			{
				return this._stuFile_ID;
			}
			set
			{
				if ((this._stuFile_ID != value))
				{
					this.OnstuFile_IDChanging(value);
					this.SendPropertyChanging();
					this._stuFile_ID = value;
					this.SendPropertyChanged("stuFile_ID");
					this.OnstuFile_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_student_ID", DbType="VarChar(9) NOT NULL", CanBeNull=false)]
		public string student_ID
		{
			get
			{
				return this._student_ID;
			}
			set
			{
				if ((this._student_ID != value))
				{
					if (this._table_studentInfo.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onstudent_IDChanging(value);
					this.SendPropertyChanging();
					this._student_ID = value;
					this.SendPropertyChanged("student_ID");
					this.Onstudent_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_stuFile_name", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string stuFile_name
		{
			get
			{
				return this._stuFile_name;
			}
			set
			{
				if ((this._stuFile_name != value))
				{
					this.OnstuFile_nameChanging(value);
					this.SendPropertyChanging();
					this._stuFile_name = value;
					this.SendPropertyChanged("stuFile_name");
					this.OnstuFile_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_stuFile_fileType", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string stuFile_fileType
		{
			get
			{
				return this._stuFile_fileType;
			}
			set
			{
				if ((this._stuFile_fileType != value))
				{
					this.OnstuFile_fileTypeChanging(value);
					this.SendPropertyChanging();
					this._stuFile_fileType = value;
					this.SendPropertyChanged("stuFile_fileType");
					this.OnstuFile_fileTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_stuFile_recordType", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string stuFile_recordType
		{
			get
			{
				return this._stuFile_recordType;
			}
			set
			{
				if ((this._stuFile_recordType != value))
				{
					this.OnstuFile_recordTypeChanging(value);
					this.SendPropertyChanging();
					this._stuFile_recordType = value;
					this.SendPropertyChanged("stuFile_recordType");
					this.OnstuFile_recordTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_stuFile_location", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string stuFile_location
		{
			get
			{
				return this._stuFile_location;
			}
			set
			{
				if ((this._stuFile_location != value))
				{
					this.OnstuFile_locationChanging(value);
					this.SendPropertyChanging();
					this._stuFile_location = value;
					this.SendPropertyChanged("stuFile_location");
					this.OnstuFile_locationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date_created", DbType="DateTime NOT NULL")]
		public System.DateTime date_created
		{
			get
			{
				return this._date_created;
			}
			set
			{
				if ((this._date_created != value))
				{
					this.Ondate_createdChanging(value);
					this.SendPropertyChanging();
					this._date_created = value;
					this.SendPropertyChanged("date_created");
					this.Ondate_createdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date_modified", DbType="DateTime NOT NULL")]
		public System.DateTime date_modified
		{
			get
			{
				return this._date_modified;
			}
			set
			{
				if ((this._date_modified != value))
				{
					this.Ondate_modifiedChanging(value);
					this.SendPropertyChanging();
					this._date_modified = value;
					this.SendPropertyChanged("date_modified");
					this.Ondate_modifiedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="table_studentInfo_table_studentFile", Storage="_table_studentInfo", ThisKey="student_ID", OtherKey="student_ID", IsForeignKey=true)]
		public table_studentInfo table_studentInfo
		{
			get
			{
				return this._table_studentInfo.Entity;
			}
			set
			{
				table_studentInfo previousValue = this._table_studentInfo.Entity;
				if (((previousValue != value) 
							|| (this._table_studentInfo.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._table_studentInfo.Entity = null;
						previousValue.table_studentFiles.Remove(this);
					}
					this._table_studentInfo.Entity = value;
					if ((value != null))
					{
						value.table_studentFiles.Add(this);
						this._student_ID = value.student_ID;
					}
					else
					{
						this._student_ID = default(string);
					}
					this.SendPropertyChanged("table_studentInfo");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.table_studentInfo")]
	public partial class table_studentInfo : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _student_ID;
		
		private string _student_firstName;
		
		private string _student_middleName;
		
		private string _student_lastName;
		
		private string _student_phoneNum;
		
		private string _student_email;
		
		private System.DateTime _date_created;
		
		private System.DateTime _date_modified;
		
		private EntitySet<table_activityLog> _table_activityLogs;
		
		private EntitySet<table_studentFile> _table_studentFiles;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onstudent_IDChanging(string value);
    partial void Onstudent_IDChanged();
    partial void Onstudent_firstNameChanging(string value);
    partial void Onstudent_firstNameChanged();
    partial void Onstudent_middleNameChanging(string value);
    partial void Onstudent_middleNameChanged();
    partial void Onstudent_lastNameChanging(string value);
    partial void Onstudent_lastNameChanged();
    partial void Onstudent_phoneNumChanging(string value);
    partial void Onstudent_phoneNumChanged();
    partial void Onstudent_emailChanging(string value);
    partial void Onstudent_emailChanged();
    partial void Ondate_createdChanging(System.DateTime value);
    partial void Ondate_createdChanged();
    partial void Ondate_modifiedChanging(System.DateTime value);
    partial void Ondate_modifiedChanged();
    #endregion
		
		public table_studentInfo()
		{
			this._table_activityLogs = new EntitySet<table_activityLog>(new Action<table_activityLog>(this.attach_table_activityLogs), new Action<table_activityLog>(this.detach_table_activityLogs));
			this._table_studentFiles = new EntitySet<table_studentFile>(new Action<table_studentFile>(this.attach_table_studentFiles), new Action<table_studentFile>(this.detach_table_studentFiles));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_student_ID", DbType="VarChar(9) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string student_ID
		{
			get
			{
				return this._student_ID;
			}
			set
			{
				if ((this._student_ID != value))
				{
					this.Onstudent_IDChanging(value);
					this.SendPropertyChanging();
					this._student_ID = value;
					this.SendPropertyChanged("student_ID");
					this.Onstudent_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_student_firstName", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string student_firstName
		{
			get
			{
				return this._student_firstName;
			}
			set
			{
				if ((this._student_firstName != value))
				{
					this.Onstudent_firstNameChanging(value);
					this.SendPropertyChanging();
					this._student_firstName = value;
					this.SendPropertyChanged("student_firstName");
					this.Onstudent_firstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_student_middleName", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string student_middleName
		{
			get
			{
				return this._student_middleName;
			}
			set
			{
				if ((this._student_middleName != value))
				{
					this.Onstudent_middleNameChanging(value);
					this.SendPropertyChanging();
					this._student_middleName = value;
					this.SendPropertyChanged("student_middleName");
					this.Onstudent_middleNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_student_lastName", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string student_lastName
		{
			get
			{
				return this._student_lastName;
			}
			set
			{
				if ((this._student_lastName != value))
				{
					this.Onstudent_lastNameChanging(value);
					this.SendPropertyChanging();
					this._student_lastName = value;
					this.SendPropertyChanged("student_lastName");
					this.Onstudent_lastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_student_phoneNum", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string student_phoneNum
		{
			get
			{
				return this._student_phoneNum;
			}
			set
			{
				if ((this._student_phoneNum != value))
				{
					this.Onstudent_phoneNumChanging(value);
					this.SendPropertyChanging();
					this._student_phoneNum = value;
					this.SendPropertyChanged("student_phoneNum");
					this.Onstudent_phoneNumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_student_email", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string student_email
		{
			get
			{
				return this._student_email;
			}
			set
			{
				if ((this._student_email != value))
				{
					this.Onstudent_emailChanging(value);
					this.SendPropertyChanging();
					this._student_email = value;
					this.SendPropertyChanged("student_email");
					this.Onstudent_emailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date_created", DbType="DateTime NOT NULL")]
		public System.DateTime date_created
		{
			get
			{
				return this._date_created;
			}
			set
			{
				if ((this._date_created != value))
				{
					this.Ondate_createdChanging(value);
					this.SendPropertyChanging();
					this._date_created = value;
					this.SendPropertyChanged("date_created");
					this.Ondate_createdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date_modified", DbType="DateTime NOT NULL")]
		public System.DateTime date_modified
		{
			get
			{
				return this._date_modified;
			}
			set
			{
				if ((this._date_modified != value))
				{
					this.Ondate_modifiedChanging(value);
					this.SendPropertyChanging();
					this._date_modified = value;
					this.SendPropertyChanged("date_modified");
					this.Ondate_modifiedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="table_studentInfo_table_activityLog", Storage="_table_activityLogs", ThisKey="student_ID", OtherKey="student_ID")]
		public EntitySet<table_activityLog> table_activityLogs
		{
			get
			{
				return this._table_activityLogs;
			}
			set
			{
				this._table_activityLogs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="table_studentInfo_table_studentFile", Storage="_table_studentFiles", ThisKey="student_ID", OtherKey="student_ID")]
		public EntitySet<table_studentFile> table_studentFiles
		{
			get
			{
				return this._table_studentFiles;
			}
			set
			{
				this._table_studentFiles.Assign(value);
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
		
		private void attach_table_activityLogs(table_activityLog entity)
		{
			this.SendPropertyChanging();
			entity.table_studentInfo = this;
		}
		
		private void detach_table_activityLogs(table_activityLog entity)
		{
			this.SendPropertyChanging();
			entity.table_studentInfo = null;
		}
		
		private void attach_table_studentFiles(table_studentFile entity)
		{
			this.SendPropertyChanging();
			entity.table_studentInfo = this;
		}
		
		private void detach_table_studentFiles(table_studentFile entity)
		{
			this.SendPropertyChanging();
			entity.table_studentInfo = null;
		}
	}
	
	public partial class uspRetrieveStudentFilesResult
	{
		
		private string _fileID;
		
		private string _fileName;
		
		private string _fileType;
		
		private string _fileRecordType;
		
		private string _fileLocation;
		
		public uspRetrieveStudentFilesResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fileID", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string fileID
		{
			get
			{
				return this._fileID;
			}
			set
			{
				if ((this._fileID != value))
				{
					this._fileID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fileName", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string fileName
		{
			get
			{
				return this._fileName;
			}
			set
			{
				if ((this._fileName != value))
				{
					this._fileName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fileType", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string fileType
		{
			get
			{
				return this._fileType;
			}
			set
			{
				if ((this._fileType != value))
				{
					this._fileType = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fileRecordType", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string fileRecordType
		{
			get
			{
				return this._fileRecordType;
			}
			set
			{
				if ((this._fileRecordType != value))
				{
					this._fileRecordType = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fileLocation", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string fileLocation
		{
			get
			{
				return this._fileLocation;
			}
			set
			{
				if ((this._fileLocation != value))
				{
					this._fileLocation = value;
				}
			}
		}
	}
	
	public partial class uspRetrieveStudentRecordsResult
	{
		
		private string _studentID;
		
		private string _studentFName;
		
		private string _studentMName;
		
		private string _studentLName;
		
		private string _studentEmail;
		
		private string _studentPhoneNum;
		
		public uspRetrieveStudentRecordsResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_studentID", DbType="VarChar(9) NOT NULL", CanBeNull=false)]
		public string studentID
		{
			get
			{
				return this._studentID;
			}
			set
			{
				if ((this._studentID != value))
				{
					this._studentID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_studentFName", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string studentFName
		{
			get
			{
				return this._studentFName;
			}
			set
			{
				if ((this._studentFName != value))
				{
					this._studentFName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_studentMName", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string studentMName
		{
			get
			{
				return this._studentMName;
			}
			set
			{
				if ((this._studentMName != value))
				{
					this._studentMName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_studentLName", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string studentLName
		{
			get
			{
				return this._studentLName;
			}
			set
			{
				if ((this._studentLName != value))
				{
					this._studentLName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_studentEmail", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string studentEmail
		{
			get
			{
				return this._studentEmail;
			}
			set
			{
				if ((this._studentEmail != value))
				{
					this._studentEmail = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_studentPhoneNum", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string studentPhoneNum
		{
			get
			{
				return this._studentPhoneNum;
			}
			set
			{
				if ((this._studentPhoneNum != value))
				{
					this._studentPhoneNum = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
