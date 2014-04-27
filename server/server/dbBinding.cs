using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Data.SqlClient;

namespace server
{
    public class dbBinding:DataContext
    {
        public dbBinding (string connection):base(connection)
        {}

        public System.Data.Linq.Table<Consulters> tConsulters
        {
            get { return this.GetTable<Consulters>(); }
        }

        public System.Data.Linq.Table<consulters_salary> tConsultersSalary
        {
            get { return this.GetTable<consulters_salary>(); }
        }
    }

    [Table]
    public class consulters_salary
    {
        private EntityRef<Consulters> _consulters;
        [Association(Name = "FK_consulter_salary_ToTable", Storage = "_consulters", ThisKey = "consulter_Id", IsForeignKey = true)]
        public Consulters Consult
        {
            get { return this._consulters.Entity; }
            set { this._consulters.Entity = value; }
        }

        [Column(DbType = "INT")]
        public int consulter_Id;
        [Column(DbType = "DATETIME")]
        public DateTime date;
        [Column(DbType="INT")]
        public int overal_salary;

        public consulters_salary() { }
        public consulters_salary(Consulters consulter, DateTime date, int overal_salary)
        {
            this.Consult = consulter;
            this.date = date;
            this.overal_salary = overal_salary;
        }
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

        public Consulters()
        { }

        public Consulters(int id, string login, string password, string firstname, string lastname, int salary)
        {
            this.Id = id;
            this.login = login;
            this.password = password;
            this.firstname = firstname;
            this.lastname = lastname;
            this.salary = salary;
        }
    }

    [Table]
    public class FAQ
    { }

    [Table]
    public class Tarif
    { }

    [Table]
    public class Themes
    { }
}
