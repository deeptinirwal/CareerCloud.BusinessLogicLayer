using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository)
            : base(repository)
        { }

        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
   public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (CompanyProfilePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.ContactPhone))
                {
                    exceptions.Add(new ValidationException(601, $"PhoneNumber for SecurityLogin {poco.Id} is required"));
                }
                else
                {
                    var r = new Regex(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$");
                    if ((r.IsMatch(poco.ContactPhone)) == false)
                    {
                        exceptions.Add(new ValidationException(601, $"PhoneNumber for SecurityLogin {poco.Id} is required"));
                    }
                }
                
                if(string.IsNullOrEmpty(poco.CompanyWebsite))
                {
                    exceptions.Add(new ValidationException(600, "Website is not in given  format"));
                }
                    
               else if (poco.CompanyWebsite.EndsWith(".ca") || poco.CompanyWebsite.EndsWith(".biz") ||poco.CompanyWebsite.EndsWith(".com"))
                {
                    
                }
                else
                {
                    exceptions.Add(new ValidationException(600, "Website is not in given  format"));
                }
                   
                if (exceptions.Count > 0)
                {
                    throw new AggregateException(exceptions);
                }
            }
        }


    }
}
