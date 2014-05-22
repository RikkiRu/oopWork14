using System;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace dbLib
{
	[Database]
    public class dbBind : DataContext
    {
        public dbBind(string connection)
			: base(connection) { }

		public System.Data.Linq.Table<Consulters> tConsulters {
			get { return base.GetTable<Consulters>(); }
		}

		public string getStringTable<TEntity>(Table<TEntity> table) where TEntity : class {
			string stringTable = typeof(TEntity).Name + Environment.NewLine;			
			var columns = this.Mapping.MappingSource
					  .GetModel(typeof(DataContext))
					  .GetMetaType(typeof(TEntity))
					  .DataMembers;
			for(int i = 0; i < columns.Count -1 ; ++i) {
				stringTable += columns[i].Name + '~';
			}
			stringTable += Environment.NewLine;
			foreach (var row in table) {
				stringTable += row + Environment.NewLine;
			}
			return stringTable;
		}

        public System.Data.Linq.Table<consulter_salary> tConsultersSalary {
            get { return this.GetTable<consulter_salary>(); }
        }

        public System.Data.Linq.Table<FAQ> tFAQ
        {
            get { return this.GetTable<FAQ>();}
        }

        public System.Data.Linq.Table<QA> tFQA
        {
			get { return this.GetTable<QA>(); }
        }

        public System.Data.Linq.Table<Tarif> tTarif
        {
            get { return this.GetTable<Tarif>(); }
        }

        public System.Data.Linq.Table<Themes> tThemes
        {
            get { return this.GetTable<Themes>(); }
        }
    }
	
	[Serializable]
	public abstract class Table {
		public char concatSymbol = '~';
	}
    
	[Table]
    public class consulter_salary : Table
    {
        [Column(DbType = "INT")]
        public int consulter_Id;
        [Column(DbType = "DATETIME")]
        public DateTime date;
        [Column(DbType = "INT")]
        public int overal_salary;
    }
	
	[Serializable]
    [Table]
    public class Consulters : Table
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT")]
        public int Id;
        [Column(DbType = "NVARCHAR(50)")]
        public string login;
        [Column(DbType = "NVARCHAR(50)")]
        public string password;
        [Column(Name="firstname", DbType = "NVARCHAR(50)")]
		public string firstname;
        [Column(DbType = "NVARCHAR(50)")]
        public string lastname;
        [Column(DbType = "INT")]
        public int salary;
        [Column(DbType = "INT")]
        public int isBoss;

        public Consulters() {}
		public Consulters(string login, string password, string firstname, string lastname, int salary, int IsBoss) {
			this.Set(login, password, firstname, lastname, salary, IsBoss);
		}
		public void Set(string login, string password, string firstname, string lastname, int salary,int IsBoss){
            this.login = login;
            this.password = password;
			this.firstname = firstname;
            this.lastname = lastname;
            this.salary = salary;
            this.isBoss = IsBoss;
		}
		public override string ToString() {
			return this.Id.ToString() + concatSymbol + this.login + concatSymbol + this.password + concatSymbol + this.firstname + concatSymbol + this.lastname + concatSymbol + this.isBoss;
		}
    }

    [Table]
    public class FAQ : Table
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT")]
        public int Id;
        [Column(DbType = "NVARCHAR(MAX)")]
        public string question;
        [Column(DbType = "NVARCHAR(MAX)")]
        public string answer;
        [Column(DbType = "INT")]
        public int theme_id;

		public FAQ() { }
		public FAQ(string question, string answer, int theme_id) {
			this.Set(question, answer, theme_id);
		}
		public void Set(string question, string answer, int theme_id) {
			this.question = question;
			this.answer = answer;
			this.theme_id = theme_id;
		}
		public override string ToString() {
			return this.Id.ToString() + concatSymbol + this.question + concatSymbol + this.answer + concatSymbol + this.theme_id;
		}
    }

    [Table]
    public class QA : Table
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT")]
        public int Id;
        [Column(DbType = "NVARCHAR(MAX)")]
        public string question;
        [Column(DbType = "NVARCHAR(MAX)")]
        public string answer;
        [Column(DbType = "INT")]
        public int theme_id;
        [Column(DbType = "INT")]
        public int consulter_id;
        [Column(DbType = "DATETIME", CanBeNull = true)]
        public DateTime start_time;
        [Column(DbType = "DATETIME", CanBeNull = true)]
        public DateTime end_time;
        [Column(DbType = "NVARCHAR(MAX)")]
        public string email;

		public QA() { }

		public QA(string question, string answer, int theme_id, int consulter_id, DateTime start_time, DateTime end_time, string email) {
			this.question = question;
			this.answer = answer;
			this.theme_id = theme_id;
			this.consulter_id = consulter_id;
			this.start_time = start_time;
			this.end_time = end_time;
			this.email = email;
		}
    }

    [Table]
    public class Tarif : Table
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT")]
        public int Id;
        [Column(DbType = "INT")]
        public int cost;
        [Column(DbType = "INT")]
        public int multipiller;

		public Tarif() { }
		public Tarif(int cost, int multipiller) {
			this.Set(cost, multipiller);
		}
		public void Set(int cost, int multipiller) {
			this.cost = cost;
			this.multipiller = multipiller;
		}
		public override string ToString() {
			return this.Id.ToString() + concatSymbol + this.cost + concatSymbol + this.multipiller;
		}
    }

    [Table]
    public class Themes : Table
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT")]
        public int Id;
        [Column(DbType = "NVARCHAR(50)")]
        public string Theme;
        [Column(DbType = "INT")]
        public int difficulty;
        [Column(DbType = "INT")]
        public int tarif_id;
        [Column(DbType = "NVARCHAR(50)")]
        public string standart_time;

		public Themes() { }
		public Themes(string Theme, int difficulty, int tarif_id, string standart_time) {
			this.Set(Theme, difficulty, tarif_id, standart_time);
		}
		public void Set(string Theme, int difficulty, int tarif_id, string standart_time) {
			this.Theme = Theme;
			this.difficulty = difficulty;
			this.tarif_id = tarif_id;
			this.standart_time = standart_time;
		}

		public override string ToString() {
			return this.Id.ToString() + concatSymbol + this.Theme + concatSymbol + this.difficulty + concatSymbol + this.tarif_id;
		}
    }
}
