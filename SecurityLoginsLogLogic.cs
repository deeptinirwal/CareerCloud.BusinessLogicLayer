using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class SecurityLoginsLogLogic : BaseLogic<SecurityLoginsLogPoco>
    {
        public SecurityLoginsLogLogic(IDataRepository<SecurityLoginsLogPoco> repository)
            : base(repository)
        { }


    }
}
