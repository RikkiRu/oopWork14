using System;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace dbLib
{
    public class dbBind : DataContext
    {
        public dbBind(string connection)
            : base(connection)
        { }

        public System.Data.Linq.Table<Consulters> tConsulters
        {
            get { return this.GetTable<Consulters>(); }
        }

        public System.Data.Linq.Table<consulter_salary> tConsultersSalary
        {
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
    public class consulter_salary
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
    public class Consulters
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

        public Consulters()
        { }

        public Consulters(int id, string login, string password, string firstname, string lastname, int salary,int IsBoss)
        {
            this.Id = id;
            this.login = login;
            this.password = password;
            this.firstname = firstname;
            this.lastname = lastname;
            this.salary = salary;
            this.isBoss = IsBoss;
        }
    }

    [Table]
    public class FAQ
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
    public class QA
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
        [Column(DbType = "DATETIME")]
        public DateTime start_time;
        [Column(DbType = "DATETIME")]
        public DateTime end_time;
        [Column(DbType = "NVARCHAR(MAX)")]
        public string email;
    }

    [Table]
    public class Tarif
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT")]
        public int Id;
        [Column(DbType = "INT")]
        public int cost;
        [Column(DbType = "INT")]
        public int multipiller;
    }

    [Table]
    public class Themes
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
