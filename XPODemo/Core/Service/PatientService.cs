using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;
using XPODemo.Core.Models.Domain;
using XPODemo.Core.Models.POCO;
using System.Linq;

namespace XPODemo.Core.Service
{
    public class PatientService
    {
        public int CreatePatient(PatientPOCO patientPOCO)
        {
            int newOid = 0;

            try
            {
                using (var uow = new UnitOfWork())
                {
                    var patient = new Patient(uow) { MRN = patientPOCO.MRN, LastName = patientPOCO.LastName, FirstName = patientPOCO.FirstName, DateOfBirth = patientPOCO.DOB };
                    uow.CommitChanges();
                    newOid = patient.Oid;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }

            return newOid;
        }

        public bool UpdatePatient(PatientPOCO patientPOCO)
        {
            bool successful = true;

            try
            {
                using (var uow = new UnitOfWork())
                {
                    var patient = new XPQuery<Patient>(uow).FirstOrDefault(p => p.Oid == patientPOCO.Oid);

                    if (patient != null)
                    {
                        patient.MRN = patientPOCO.MRN;
                        patient.LastName = patientPOCO.LastName;
                        patient.FirstName = patientPOCO.FirstName;
                        patient.DateOfBirth = patient.DateOfBirth;
                    }

                    uow.CommitChanges();
                }
            }
            catch
            {
                successful = false;
            }

            return successful;
        }

        public bool CancelChanges(int oid, UnitOfWork uow)
        {
            bool successful = true;

            try
            {
                uow.DropIdentityMap();
                uow.FindObject<Patient>(oid);
            }
            catch
            {
                successful = false;
            }

            return successful;
        }
    }
}
