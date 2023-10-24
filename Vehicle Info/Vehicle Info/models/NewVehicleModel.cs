using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Info.models
{
    class NewVehicleModel
    {
        //constructor: default
        public NewVehicleModel() { }
        
        //constructor: Initialize the current model
        public NewVehicleModel(string registrationNo, string modelName, int noOfSeats, HashSet<String> vehicleColorList)
        {
            this.registrationNo = registrationNo;
            this.modelName = modelName;
            this.vehicleColorList = vehicleColorList;
            this.noOfSeats = noOfSeats;
        }

        //properties and validation
        [Required(AllowEmptyStrings =false, ErrorMessage ="registration no must included")]
        [StringLength(10, MinimumLength = 5, ErrorMessage ="registration no must between 5-10 characters" )]
        [RegularExpression(@"^(?>[a-zA-Z]{1,3}|(?!0*-)[0-9]{1,3})-[0-9]{2,4}(?<!0{4})", ErrorMessage ="incorrect format of the registration no.")]
        public String registrationNo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "model name must included")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "model name must between 5-50 characters")]
        [RegularExpression(@"^[A-Za-z0-9\s\-]+$", ErrorMessage = "incorrect format of the model name.")]
        public String modelName { get; set; }

        [Required(ErrorMessage = "no of seats must included")]
        [Range(1, 999, ErrorMessage = "no of seats must between 1-1000")]
        public int noOfSeats { get; set; }

        public HashSet<String> vehicleColorList { get; set; }

        //validate hte Model 
        public string validateObject(NewVehicleModel newVehicleModel)
        {
            //check the validations
            var validationContext = new ValidationContext(newVehicleModel);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(newVehicleModel, validationContext, validationResults, validateAllProperties: true))
            {
                foreach (var validationResult in validationResults)
                {
                    var errorMessage = validationResult.ErrorMessage;
                    return errorMessage;
                }
            }

            //check the color is transparent or null
            if(vehicleColorList == null || vehicleColorList.Count < 1)
            {
                return "add at least one vehicle color";
            }
            return String.Empty;
        }

    }
}
