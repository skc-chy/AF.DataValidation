using Architecture.Foundation.Core.Interface.Validation;
using AF.DataValidation.Sample;
using Architecture.Foundation.DataValidator;

namespace AFDataValidation
{
    /// <summary>
    /// Implement interface 'IAFValidation'
    /// Set property 'ValidateOperation' before pass it to Buisness layer for validation
    /// Decorate properties with Validator attribute
    /// Multiple validator can be used for single property
    /// Every validator accept list of operations for which it trigger validation
    /// You can pass hard coded validation message or resource key
    /// </summary>
    public sealed class ValidationEntity : IAFValidation
    {
        //Resource key passed for validation message
        [AFGuidValidator(typeof(Resource), "ID", new[] { ValidateOperations.Add, ValidateOperations.Update })]
        public Guid EmpID { get; set; }

        //Hard coded message passed for validation
        [AFRequiredFieldValidator("Name could not be blank", new[] { ValidateOperations.Add })]
        public string Name { get; set; }

        //Hard coded message passed for validation
        [AFRequiredFieldValidator("Address could not be blank", new[] { ValidateOperations.Add, ValidateOperations.Update })]
        public string Address { get; set; }

        //Hard coded message passed for validation
        [AFRequiredFieldValidator("Email could not be blank", new[] { ValidateOperations.Add, ValidateOperations.Update })]
        [AFRegexValidator(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$",true,"Email format is not correct", new[] {ValidateOperations.Add,ValidateOperations.Update})]
        public string EMail { get; set; }

        //Resource key passed for validation message
        [AFRequiredFieldValidator(typeof(Resource), "Ph", new[] { ValidateOperations.Add, ValidateOperations.Update })]
        
        public string Phone { get; set; }

        public ValidateOperations ValidateOperation { get; set; }
    }
}
