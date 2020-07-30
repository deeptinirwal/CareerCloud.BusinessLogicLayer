using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobEducationLogic : BaseLogic<CompanyJobEducationPoco>
    {
        public CompanyJobEducationLogic(IDataRepository<CompanyJobEducationPoco> repository)
            : base(repository)
        { }

        public override void Add(CompanyJobEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(CompanyJobEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        protected override void Verify(CompanyJobEducationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (CompanyJobEducationPoco poco in pocos)
            {
                if (String.IsNullOrEmpty(poco.Major))
                {
                    exceptions.Add(new ValidationException(200, "Major Cannot be empty or less than 3 characters"));
                }
                else if (poco.Major.Length < 2)
                {
                    exceptions.Add(new ValidationException(200, "Major Cannot be empty or less than 3 characters"));
                }

                if (poco.Importance<0)
                {
                    exceptions.Add(new ValidationException(201, "Importance  Cannot be less than 0"));
                }

                if (exceptions.Count > 0)
                {
                    throw new AggregateException(exceptions);
                }
            }
        }


    }
}
