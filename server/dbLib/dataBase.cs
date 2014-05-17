using System;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace dbLib
{
	public abstract class Table {
		public char concatSymbol = '~';
	}
	[Database]
    public class dbBind : DataContext
    {
        public dbBind(string connection)
			: base(connection) { }

		public System.Data.Linq.Table<Consulters> tConsulters {
			get { return base.GetTable<Consulters>(); }
		}

        public System.Data.Linq.Table<consulter_salary> tConsultersSalary {
            get { return this.GetTable<consulter_salary>(); }
        }

        public System.Data.Linq.Table<FAQ> tFAQ
        {
            get { return this.GetTable<FAQ>(); }
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

    [Table]
    public class consulter_salary : Table
    {
        [Column(DbType = "INT")]
        public int consulter_Id;
        [Column(DbType = "DATETIME")]
        public DateTime date;
        [Column(DbType = "INT")]
        public int overal_salary;

        public consulter_salary() { }
    }

    [Table]
    public class Consulters : Table
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT")]
        public int Id;
        [Column(DbType = "NVARCHAR(50)")]
        public string login;
        [Column(DbType = "NVARCHAR(50)")]
        public string password;
        [Column(DbType = "NVARCHAR(50)")]
        public string firstname;
        [Column(DbType = "NVARCHAR(50)")]
        public string lastname;
        [Column(DbType = "INT")]
        public int salary;
        [Column(DbType = "INT")]
        public int isBoss;

        public Consulters() {}

        public Consulters(int id, string login, string password, string firstname, string lastname, int salary,int IsBoss)
        {
			this.Set(id, login, password, firstname, lastname, salary, IsBoss);
        }
		public void Set(int id, string login, string password, string firstname, string lastname, int salary,int IsBoss){
			this.Id = id;
            this.login = login;
            this.password = password;
            this.firstname = firstname;
            this.lastname = lastname;
            this.salary = salary;
            this.isBoss = IsBoss;
		}
		public override string ToString() {
			return this.Id.ToString() + concatSymbol + this.firstname + concatSymbol + this.lastname + concatSymbol + this.isBoss;
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
    }

    [Table]
    public class Themes : Table
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT")]
        public int Id;
        [Column(DbType = "NVARCHAR(50)")]
        public string Theme;
        [Column(DbType = "INT")]
        public int difficulity;
        [Column(DbType = "INT")]
        public int tarif_id;
        [Column(DbType = "NVARCHAR(50)")]
        public string standart_time;
    }
}
