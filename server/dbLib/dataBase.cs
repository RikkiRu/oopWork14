using System;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace dbLib {
	[DataContract]
	[Database]
	public class dbBind : DataContext {

		[DataMember]
		public System.Data.Linq.Table<Consulters> tConsulters {
			get { return base.GetTable<Consulters>(); }
		}
		[DataMember]
		public System.Data.Linq.Table<consulter_salary> tConsultersSalary {
			get { return base.GetTable<consulter_salary>(); }
		}
		[DataMember]
		public System.Data.Linq.Table<FAQ> tFAQ {
			get { return base.GetTable<FAQ>(); }
		}
		[DataMember]
		public System.Data.Linq.Table<QA> tFQA {
			get { return base.GetTable<QA>(); }
		}
		[DataMember]
		public System.Data.Linq.Table<Tarif> tTarif {
			get { return base.GetTable<Tarif>(); }
		}
		[DataMember]
		public System.Data.Linq.Table<Themes> tThemes {
			get { return base.GetTable<Themes>(); }
		}

		public dbBind(string connection)
			: base(connection) { }
		public string getStringTable<TEntity>(Table<TEntity> table) where TEntity : class {
			string stringTable = typeof(TEntity).Name + Environment.NewLine;
			var columns = this.Mapping.MappingSource
					  .GetModel(typeof(DataContext))
					  .GetMetaType(typeof(TEntity))
					  .DataMembers;
			for (int i = 0; i < columns.Count - 1; ++i) {
				stringTable += columns[i].Name + '~';
			}
			stringTable += Environment.NewLine;
			foreach (var row in table) {
				stringTable += row + Environment.NewLine;
			}
			return stringTable;
		}
		public System.Data.Linq.Table<TEntity> getTable<TEntity>() where TEntity : Table {
			return base.GetTable<TEntity>();
		}
		/*public System.Data.Linq.ITable getTable(Type TEntity){
			return this.getTable(TEntity);
		}*/
	}
	[DataContract]
	public class Table {
		public char concatSymbol = '~';
	}
	[DataContract]
	[Table]
	public class consulter_salary : Table {

		private int consulter_Id;
		private DateTime date;
		private int overal_salary;

		[DataMember]
		[Column(DbType = "INT", Name = "consulter_id")]
		public int ConsulterID {
			set { consulter_Id = value; }
			get { return consulter_Id; }
		}
		[DataMember]
		[Column(DbType = "DATETIME", Name = "date")]
		public DateTime Date {
			set { date = value; }
			get { return date; }
		}
		[DataMember]
		[Column(DbType = "INT", Name = "overal_salary")]
		public int OveralSalary {
			set { overal_salary = value; }
			get { return overal_salary; }
		}

		public consulter_salary() { }
		public consulter_salary(int consulter_Id, DateTime date, int overal_salary) {
			this.consulter_Id = consulter_Id;
			this.date = date;
			this.overal_salary = overal_salary;
		}

	}
	[DataContract]
	[Table]
	public class Consulters : Table {

		private int Id;
		private string login;
		private string password;
		private string firstname;
		private string lastname;
		private int salary;
		private int isBoss;

		[DataMember]
		[Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT", Name = "Id")]
		public int ID {
			set { Id = value; }
			get { return Id; }
		}
		[DataMember]
		[Column(DbType = "NVARCHAR(50)", Name = "login")]
		public string Login {
			set { login = value; }
			get { return login; }
		}
		[DataMember]
		[Column(DbType = "NVARCHAR(50)", Name = "password")]
		public string Password {
			set { password = value; }
			get { return password; }
		}
		[DataMember]
		[Column(DbType = "NVARCHAR(50)", Name = "firstname")]
		public string Firstname {
			set { firstname = value; }
			get { return firstname; }
		}
		[DataMember]
		[Column(DbType = "NVARCHAR(50)", Name = "lastname")]
		public string Lastname {
			set { lastname = value; }
			get { return lastname; }
		}
		[DataMember]
		[Column(DbType = "INT", Name = "salary")]
		public int Salary {
			set { salary = value; }
			get { return salary; }
		}
		[DataMember]
		[Column(DbType = "INT", Name = "isBoss")]
		public int IsBoss {
			set { isBoss = value; }
			get { return isBoss; }
		}

		public Consulters() { }
		public Consulters(string login, string password, string firstname, string lastname, int salary, int IsBoss, int Id = -1) {
			this.Set(login, password, firstname, lastname, salary, IsBoss, Id);
		}
		public void Set(string login, string password, string firstname, string lastname, int salary, int IsBoss, int Id = -1) {
			this.login = login;
			this.password = password;
			this.firstname = firstname;
			this.lastname = lastname;
			this.salary = salary;
			this.isBoss = IsBoss;
			this.Id = Id;
		}
		public override string ToString() {
			return this.Id.ToString() + concatSymbol + this.login + concatSymbol + this.password + concatSymbol + this.firstname + concatSymbol + this.lastname + concatSymbol + this.isBoss;
		}
	}
	[DataContract]
	[Table]
	public class FAQ : Table {

		private int Id;
		private string question;
		private string answer;
		private int theme_id;

		[DataMember]
		[Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT", Name = "Id")]
		public int ID {
			set { Id = value; }
			get { return Id; }
		}
		[DataMember]
		[Column(DbType = "NVARCHAR(MAX)", Name = "question")]
		public string Question {
			set { question = value; }
			get { return question; }
		}
		[DataMember]
		[Column(DbType = "NVARCHAR(MAX)", Name = "answer")]
		public string Answer {
			set { answer = value; }
			get { return answer; }
		}
		[DataMember]
		[Column(DbType = "INT", Name = "theme_id")]
		public int ThemeID {
			set { theme_id = value; }
			get { return theme_id; }
		}

		public FAQ() { }
		public FAQ(string question, string answer, int theme_id, int Id = -1) {
			this.Set(question, answer, theme_id, Id);
		}
		public void Set(string question, string answer, int theme_id, int Id = -1) {
			this.question = question;
			this.answer = answer;
			this.theme_id = theme_id;
			this.Id = Id;
		}
		public override string ToString() {
			return this.Id.ToString() + concatSymbol + this.question + concatSymbol + this.answer + concatSymbol + this.theme_id;
		}
	}
	[DataContract]
	[Table]
	public class QA : Table {

		private int Id;
		private string question;
		public string answer;
		private int theme_id;
		private int consulter_id;
		private DateTime start_time;
		private DateTime end_time;
		private string email;

		[DataMember]
		[Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT", Name = "Id")]
		public int ID {
			set { Id = value; }
			get { return theme_id; }
		}
		[DataMember]
		[Column(DbType = "NVARCHAR(MAX)", Name = "question")]
		public string Question {
			set { question = value; }
			get { return question; }
		}
		[DataMember]
		[Column(DbType = "NVARCHAR(MAX)", Name = "answer")]
		public string Answer {
			set { answer = value; }
			get { return answer; }
		}
		[DataMember]
		[Column(DbType = "INT", Name = "theme_id")]
		public int ThemeID {
			set { theme_id = value; }
			get { return theme_id; }
		}
		[DataMember]
		[Column(DbType = "INT", Name = "consulter_id")]
		public int CounsulterID {
			set { consulter_id = value; }
			get { return consulter_id; }
		}
		[DataMember]
		[Column(DbType = "DATETIME", CanBeNull = true, Name = "start_time")]
		public DateTime StartTime {
			set { start_time = value; }
			get { return start_time; }
		}
		[DataMember]
		[Column(DbType = "DATETIME", CanBeNull = true, Name = "end_time")]
		public DateTime EndTime {
			set { end_time = value; }
			get { return end_time; }
		}
		[DataMember]
		[Column(DbType = "NVARCHAR(MAX)", Name = "email")]
		public string Email {
			set { email = value; }
			get { return email; }
		}

		public QA() { }
		public QA(string question, string answer, int theme_id, int consulter_id, DateTime start_time, DateTime end_time, string email, int Id = -1) {
			this.question = question;
			this.answer = answer;
			this.theme_id = theme_id;
			this.consulter_id = consulter_id;
			this.start_time = start_time;
			this.end_time = end_time;
			this.email = email;
			this.Id = Id;
		}
	}
	[DataContract]
	[Table]
	public class Tarif : Table {
		private int Id;
		private int cost;
		private int multipiller;

		[DataMember]
		[Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT", Name = "Id")]
		public int ID {
			set { Id = value; }
			get { return Id; }
		}
		[DataMember]
		[Column(DbType = "INT", Name = "Cost")]
		public int Cost {
			set { cost = value; }
			get { return cost; }
		}
		[DataMember]
		[Column(DbType = "INT", Name = "multipiller")]
		public int Multipiller {
			set { multipiller = value; }
			get { return multipiller; }
		}

		public Tarif() { }
		public Tarif(int cost, int multipiller, int Id = -1) {
			this.Set(cost, multipiller, Id);
		}
		public void Set(int cost, int multipiller, int Id = -1) {
			this.cost = cost;
			this.multipiller = multipiller;
			this.Id = Id;
		}
		public override string ToString() {
			return this.Id.ToString() + concatSymbol + this.cost + concatSymbol + this.multipiller;
		}
	}
	[DataContract]
	[Table]
	public class Themes : Table {
		private int Id;
		private string theme;
		private int difficulty;
		private int tarif_id;
		private string standart_time;

		[DataMember]
		[Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT", Name = "Id")]
		public int ID {
			set { Id = value; }
			get { return Id; }
		}
		[DataMember]
		[Column(DbType = "NVARCHAR(50)", Name = "Theme")]
		public string Theme {
			set { theme = value; }
			get { return theme; }
		}
		[DataMember]
		[Column(DbType = "INT", Name = "difficulity")]
		public int Difficulty {
			set { difficulty = value; }
			get { return difficulty; }
		}
		[DataMember]
		[Column(DbType = "INT", Name = "tarif_id")]
		public int TarifID {
			set { tarif_id = value; }
			get { return tarif_id; }
		}
		[DataMember]
		[Column(DbType = "NVARCHAR(50)", Name = "standart_time")]
		public string StandartTime {
			set { standart_time = value; }
			get { return standart_time; }
		}

		public Themes() { }
		public Themes(string Theme, int difficulty, int tarif_id, string standart_time, int Id = -1) {
			this.Set(Theme, difficulty, tarif_id, standart_time, Id);
		}
		public void Set(string theme, int difficulty, int tarif_id, string standart_time, int Id = -1) {
			this.theme = theme;
			this.difficulty = difficulty;
			this.tarif_id = tarif_id;
			this.standart_time = standart_time;
			this.Id = Id;
		}
		public override string ToString() {
			return this.Id.ToString() + concatSymbol + this.theme + concatSymbol + this.difficulty + concatSymbol + this.tarif_id;
		}
	}
}
