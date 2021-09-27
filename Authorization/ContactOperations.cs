using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pmdi.Authorization
{
    public class Constants
    {
        public static readonly string AdministratorsRole = "Admin";
        public static readonly string PatientRole = "Patient";
        public static readonly string DoctorRole = "Doctor";
        public static readonly string ReadOperationName = "ReadData";
        public static readonly string UpdateOperationName = "UpdateData";
        public static readonly string DeleteOperationName = "DeleteData";
    }

    public static class ContactOperations
    {
        public static OperationAuthorizationRequirement Read =
          new OperationAuthorizationRequirement { Name = Constants.ReadOperationName };
        public static OperationAuthorizationRequirement Update =
          new OperationAuthorizationRequirement { Name = Constants.UpdateOperationName };
        public static OperationAuthorizationRequirement Delete =
          new OperationAuthorizationRequirement { Name = Constants.DeleteOperationName };
    }
}
