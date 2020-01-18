using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System;
using System.Configuration;
using XPODemo.Core.Helper;
using XPODemo.Core.Models.Domain;
using XPODemo.Core.Models.POCO;
using XPODemo.Core.Service;

namespace XPODemo
{
    class Program
    {
        static void Main(string[] args)
        {

            XpoDefault.DataLayer = XpoDefault.GetDataLayer(ConfigurationManager.ConnectionStrings["XPODemo"].ConnectionString, AutoCreateOption.DatabaseAndSchema);

            using (var uow = new UnitOfWork())
            {
                var user = uow.FindObject<User>(1);

                if(user == null)
                {
                    user = new User(uow) { LastName = "Admin", FirstName = "Admin" };
                    uow.CommitChanges();
                }

                AppHelper.CurrentUserOid = user.Oid;
            }

            var patientService = new PatientService();

            Console.WriteLine("Create New Patient:");
            Console.Write("Enter Patient's MRN: ");
            string mrn = Console.ReadLine();
            Console.Write("Enter Patient's Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter Patient's First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Patient's Date of Birth: ");
            string dateOfBirth = Console.ReadLine();

            var patientPOCO = new PatientPOCO() { MRN = mrn, LastName = lastName, FirstName = firstName, DOB = Convert.ToDateTime(dateOfBirth) };

            int oid = patientService.CreatePatient(patientPOCO);

            Console.WriteLine($"Oid of this patient is {oid}.");

        }

    }
}
